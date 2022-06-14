using DataAccess.DatabaseAccess;
using DataAccess.Models;

namespace DataAccess.Data
{
    public class BadgeData : IBadgeData
    {
        private readonly ISQLDataAccess _dataBase;
        public BadgeData(ISQLDataAccess dataBase) { _dataBase = dataBase; }

        public Task<IEnumerable<BadgeModel>> GetBadges()
        {
            return _dataBase.LoadData<BadgeModel, dynamic>("dbo.getBadges", new { });
        }

        public async Task<CreateBadgeModel?> GetBadge(int id)
        {
            var results = await _dataBase.LoadData<CreateBadgeModel, dynamic>("dbo.getBadgeById", new { Id = id });
            return results.FirstOrDefault();
        }

        public async Task<BadgeModel?> GetBadgeByNFCTag(string nfcTag)
        {
            var results = await _dataBase.LoadData<BadgeModel, dynamic>("dbo.getBadgeByNFCTag", new { NFCTag = nfcTag }); ;
            return results.FirstOrDefault();
        }

        public Task InsertBadge(CreateBadgeModel badge)
        {
            return _dataBase.SaveData("dbo.insertBadge", badge);
        }
        public Task UpdateBadge(BadgeModel badge)
        {
            return _dataBase.SaveData("dbo.updateBadge", badge);
        }

        public Task DeleteBadge(int id)
        {
            return _dataBase.SaveData("dbo.deleteBadge", new { Id = id });
        }
    }
}
