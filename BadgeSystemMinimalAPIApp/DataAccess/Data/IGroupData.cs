using DataAccess.Models;

namespace DataAccess.Data
{
    public interface IGroupData
    {
        Task DeleteGroup(int id);
        Task<CreateGroupModel?> GetGroup(int id);
        Task<GroupModel?> GetGroupByName(string name);
        Task<IEnumerable<GroupModel>> GetGroups();
        Task InsertGroup(CreateGroupModel group);
        Task UpdateGroup(GroupModel group);
    }
}