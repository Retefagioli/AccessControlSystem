using DataAccess.Models;

namespace DataAccess.Data
{
    public interface IAccessTokenData
    {
        Task DeleteAccessToken(int id);
        Task<CreateAccessTokenModel?> GetAccessTokenById(int id);
        Task<AccessTokenModel?> GetAccessTokenByToken(string token);
        Task<IEnumerable<AccessTokenModel>> GetAccessTokens();
        Task InsertAccessToken(CreateAccessTokenModel token);
        Task UpdateAccessToken(AccessTokenModel token);
    }
}