using DataAccess.DatabaseAccess;
using DataAccess.Models;

namespace DataAccess.Data {
    public class UserData : IUserData
    {
        private readonly ISQLDataAccess _dataBase;
        public UserData(ISQLDataAccess dataBase) { _dataBase = dataBase; }

        public Task<IEnumerable<UserModel>> GetUsers()
        {
            return _dataBase.LoadData<UserModel, dynamic>("dbo.getUsers", new { });
        }

        public async Task<CreateUserModel?> GetUser(int id)
        {
            var results = await _dataBase.LoadData<CreateUserModel, dynamic>("dbo.getUserById", new { Id = id });
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
}