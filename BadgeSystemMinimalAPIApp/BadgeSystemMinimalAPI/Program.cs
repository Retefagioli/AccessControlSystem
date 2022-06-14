using DataAccess.DatabaseAccess;
using DataAccess.Data;
using BadgeSystemMinimalAPI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ISQLDataAccess, SQLDataAccess>();
builder.Services.AddSingleton<IUserData, UserData>();
builder.Services.AddSingleton<ISensorData, SensorData>();
builder.Services.AddSingleton<IGroupData, GroupData>();
builder.Services.AddSingleton<IBadgeData, BadgeData>();
builder.Services.AddSingleton<ILogData, LogData>();
builder.Services.AddSingleton<IAccessTokenData, AccessTokenData>();

builder.Services.AddRazorPages();

var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();
app.ConfigureAPI();

app.MapRazorPages();

app.Run();