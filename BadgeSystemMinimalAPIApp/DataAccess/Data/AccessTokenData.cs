using DataAccess.DatabaseAccess;
using DataAccess.Models;

namespace DataAccess.Data
{
    public class AccessTokenData : IAccessTokenData
    {
        private readonly ISQLDataAccess _dataBase;
        public AccessTokenData(ISQLDataAccess dataBase) { _dataBase = dataBase; }

        public Task<IEnumerable<AccessTokenModel>> GetAccessTokens()
        {
            return _dataBase.LoadData<AccessTokenModel, dynamic>("dbo.getAccessTokens", new { });
        }

        public async Task<CreateAccessTokenModel?> GetAccessTokenById(int id)
        {
            var results = await _dataBase.LoadData<CreateAccessTokenModel, dynamic>("dbo.getAccessTokenById", new { Id = id });
            return results.FirstOrDefault();
        }

        public async Task<AccessTokenModel?> GetAccessTokenByToken(string token)
        {
            var results = await _dataBase.LoadData<AccessTokenModel, dynamic>("dbo.getAccessTokenByToken", new { Token = token });
            return results.FirstOrDefault();
        }

        public Task InsertAccessToken(CreateAccessTokenModel token)
        {
            return _dataBase.SaveData("dbo.insertAccessToken", token);
        }
        public Task UpdateAccessToken(AccessTokenModel token)
        {
            return _dataBase.SaveData("dbo.updateAccessToken", token);
        }

        public Task DeleteAccessToken(int id)
        {
            return _dataBase.SaveData("dbo.deleteAccessToken", new { Id = id });
        }
    }
}
