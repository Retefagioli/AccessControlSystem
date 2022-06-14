using DataAccess.DatabaseAccess;
using DataAccess.Models;

namespace DataAccess.Data
{
    public class GroupData : IGroupData
    {
        private readonly ISQLDataAccess _dataBase;
        public GroupData(ISQLDataAccess dataBase) { _dataBase = dataBase; }

        public Task<IEnumerable<GroupModel>> GetGroups()
        {
            return _dataBase.LoadData<GroupModel, dynamic>("dbo.getGroups", new { });
        }

        public async Task<CreateGroupModel?> GetGroup(int id)
        {
            var results = await _dataBase.LoadData<CreateGroupModel, dynamic>("dbo.getGroupById", new { Id = id });
            return results.FirstOrDefault();
        }

        public async Task<GroupModel?> GetGroupByName(string name)
        {
            var results = await _dataBase.LoadData<GroupModel, dynamic>("dbo.getGroupByName", new { Name = name });
            return results.FirstOrDefault();
        }

        public Task InsertGroup(CreateGroupModel group)
        {
            return _dataBase.SaveData("dbo.insertGroup", group);
        }
        public Task UpdateGroup(GroupModel group)
        {
            return _dataBase.SaveData("dbo.updateGroup", group);
        }

        public Task DeleteGroup(int id)
        {
            return _dataBase.SaveData("dbo.deleteGroup", new { Id = id });
        }
    }
}
