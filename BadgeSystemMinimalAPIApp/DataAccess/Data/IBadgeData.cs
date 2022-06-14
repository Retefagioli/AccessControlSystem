using DataAccess.Models;

namespace DataAccess.Data
{
    public interface IBadgeData
    {
        Task DeleteBadge(int id);
        Task<CreateBadgeModel?> GetBadge(int id);
        Task<BadgeModel?> GetBadgeByNFCTag(string nfcTag);
        Task<IEnumerable<BadgeModel>> GetBadges();
        Task InsertBadge(CreateBadgeModel badge);
        Task UpdateBadge(BadgeModel badge);
    }
}