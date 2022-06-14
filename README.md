
<h3>Database</h3>
```sh
dbo
├── Tables
└── StoredProcedures
```

---

Il campo `GroupId` contenuto nelle tabelle [User]() e [Sensor]() permette di identificare i permessi di accesso degli utenti.
La tabella [Group]() rappresenta i permessi del sistema.
```SQL
CREATE TABLE [dbo].[Group] (
    [id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [name] NVARCHAR (MAX) NOT NULL
);

CREATE TABLE [dbo].[User]
(
    [id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [name] NVARCHAR (MAX) NOT NULL,
    [surname] NVARCHAR (MAX) NOT NULL,
    [phone] NVARCHAR (MAX) NOT NULL,
    [email] NVARCHAR (MAX) NOT NULL,
    [gender] NVARCHAR (MAX),
    [group_id] INT NOT NULL # FOREIN KEY
);

CREATE TABLE [dbo].[Sensor]
(
    [id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [name] NVARCHAR (MAX) NOT NULL,
    [group_id] INT NOT NULL, # FOREIN KEY
    [nfc_tag] NVARCHAR (MAX) NOT NULL
);


```

I campi `UserId` e `NFC_Tag` della tabella [Badge]() consentono di ottenere, tramite le apposite API, i record degli utenti e sensori coinvolti nella comunicazione.
```SQL
CREATE TABLE [dbo].[Badge] (
    [id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [user_id] INT NOT NULL,
    [nfc_tag] NVARCHAR(MAX) NOT NULL
);
```

La tabella [Log]() permette di tenere traccia di tutti gli accessi effettuati nel sistema.
```SQL
CREATE TABLE [dbo].[Log]
(
    [id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [user_id] INT NOT NULL,
    [sensor_id] INT NOT NULL,
    [date_time] DATETIME NOT NULL
)
```

La tabella [AccessToken]() contiene il campo `Token`, consente l’accesso parametro di accesso dell’applicazione mobile.
```SQL
CREATE TABLE [dbo].[AccessToken]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
	[token] NVARCHAR (MAX) NOT NULL, # Chiave di acesso Mobile Application
	[userId] INT NOT NULL
)
```

```sh
Tables
├── AccessToken.sql
├── Badge.sql
├── Group.sql
├── Log.sql
├── Sensor.sql
└── User.sql
```

IL database è stato realizzato tramite il BDMS [Microsoft SQL Server](https://docs.microsoft.com/it-it/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16), i [Server Data Tools for Visual Studio](https://docs.microsoft.com/it-it/sql/ssdt/download-sql-server-data-tools-ssdt?view=sql-server-ver16) ed il linguaggio [Transact-SQL](https://docs.microsoft.com/it-it/sql/t-sql/language-reference?view=sql-server-ver16)

Oltre agli script di creazione ed eliminazione del Database e delle Tabelle, rispettivamente [CREATE]() e [DELETE](), vengono implementate le [Stored Procedures]() per le operazioni [CRUD]().
```SQL
# Esempi:
CREATE PROCEDURE [dbo].[insertUser]
	@Name NVARCHAR (MAX),
	@Surname NVARCHAR (MAX),
	@Phone NVARCHAR (MAX),
	@Email NVARCHAR (MAX),
	@Gender NVARCHAR (MAX),
	@GroupId INT
AS
BEGIN
	INSERT INTO [User]
	([name], [surname], [phone], [email], [gender], [group_id])
	VALUES 
	(@Name, @Surname, @Phone, @Email, @Gender, @GroupId);
END

CREATE PROCEDURE [dbo].[deleteGroup]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM [Group]
	WHERE [id] = @Id;
END
```

```sh
Stored Procedures
├── deleteAccessToken.sql
├── deleteBadge.sql
├── deleteGroup.sql
├── deleteLog.sql
├── deleteSensor.sql
├── deleteUser.sql
├── getAccessTokenById.sql
├── getAccessTokenByToken.sql
├── getAccessTokens.sql
├── getBadgeById.sql
├── getBadgeByNFCTag.sql
├── getBadges.sql
├── getGroupById.sql
├── getGroupByName.sql
├── getGroups.sql
├── getLogById.sql
├── getLogs.sql
├── getLogsByDateTime.sql
├── getLogsBySensorId.sql
├── getLogsByUserId.sql
├── getSensorById.sql
├── getSensorByNFCTag.sql
├── getSensors.sql
├── getUserById.sql
├── getUsers.sql
├── insertAccessToken.sql
├── insertBadge.sql
├── insertGroup.sql
├── insertLog.sql
├── insertSensor.sql
├── insertUser.sql
├── updateAccessToken.sql
├── updateBadge.sql
├── updateGroup.sql
├── updateLog.sql
├── updateSensor.sql
└── updateUser.sql
```

L’interfaccia [ISQLDataAccess]() tramite i metodi [LoadData] e [SavaData], permette di accedere al database.
```cs
public class SQLDataAccess : ISQLDataAccess
{
    private readonly IConfiguration _configuration;
    public SQLDataAccess(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public async Task<IEnumerable<T>> LoadData<T, U>(stringstoredProcedure, U parameters, string connectionId = "Default")
    {
        using DbConnection connection = new SqlConnectio(_configuration.GetConnectionString(connectionId));
        return await connection.QueryAsync<T>(storedProcedure,parameters, commandType: CommandType.StoredProcedure);
    }
    public async Task SaveData<T>(string storedProcedure, Tparameters, string connectionId = "Default")
    {
        using DbConnection connection = new SqlConnectio(_configuration.GetConnectionString(connectionId));
        await connection.ExecuteAsync(storedProcedure, parameters,commandType: CommandType.StoredProcedure);
    }
}
```
I metodi accettano come parametri:
- `Nome della Stored Procedure` 
- `Parametri della Stored Procedure`
- `ConnectionString al Database`

La comunicazione con il database avviene mediante le [Stored Procedures] che consentono al framework [Draper]() di realizzare metodi per la gestione delle operazione [CRUD].

[Tabelle presenti nel database]() vengono rappresentate dai loro singoli [Modelli]().
I [DataModel]() implementano i metodi: { `get`, `getAll`, `insert`, `update`, `delete` } per le operazioni [CRUD]. Ogni DataModel presenta una propria Interfaccia [IDataModel]() che lavora sul [Model]() ad esso associato.
```cs
    # Esempio Modello:
    public class UserModel : CreateUserModel
    {
        public int Id { get; set; }
    }

    public class CreateUserModel
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Gender{ get; set; }
        public int GroupId { get; set; }
    }

# DataModel implementa la propria Interfaccia
public class UserData : IUserData
{
    private readonly ISQLDataAccess _dataBase;
    public UserData(ISQLDataAccess dataBase) { _dataBase = dataBase; }
    public Task<IEnumerable<UserModel>> GetUsers()
    {
        return _dataBase.LoadData<UserModel, dynamic>("dbo.getUsers",new { });
    }
    public async Task<CreateUserModel?> GetUser(int id)
    {
        var results = await _dataBase.LoadData<CreateUserModel,dynamic>("dbo.getUserById", new { Id = id });
        return results.FirstOrDefault();
    }
    public Task InsertUser(CreateUserModel user)
    {
        return _dataBase.SaveData("dbo.insertUser", user);
    }
    public Task UpdateUser(UserModel user)
    {
        return _dataBase.SaveData("dbo.updateUser", user);
    }
    public Task DeleteUser(int id)
    {
        return _dataBase.SaveData("dbo.deleteUser", new { Id = id });
    }
}
```

In `Program.cs`
```cs
builder.Services.AddSingleton<ISQLDataAccess, SQLDataAccess>();
builder.Services.AddSingleton<IModelData, ModelData>();

...
```
# MINIMAL REST APIs
![Swagger UI]()

Realizzazione delle API mediante l'[Open API (Swagger)]()
Documentazione delle API mediante [Swagger UI]()

Nel metodo `ConfigureAPI` si specifica il tipo di [Richiesta HTTP](), si associa l’`URL` della richiesta ed il `Metodo di Callback` da eseguire.
```cs
app.Method(URL, CallbackMethod);
```

Le API vengono gestite nella classe [API]():
```cs
private static readonly string _apiBaseUrl = "/api";
public static void ConfigureAPI(this WebApplication app)
{
    app.MapGet(_apiBaseUrl + "/Users", GetUsers);
    app.MapGet(_apiBaseUrl + "/Users/{id}", GetUser);
    app.MapPost(_apiBaseUrl + "/Users", InsertUser);
    app.MapPut(_apiBaseUrl + "/Users", UpdateUser);
    app.MapDelete(_apiBaseUrl + "/Users", DeleteUser);
    .
    .
    .
}
```

In `Program.cs`
```cs
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

...

app.UseSwagger(); 
app.UseSwaggerUI();  

app.UseHttpsRedirection();
app.ConfigureAPI();

...

app.Run();
```





