using DataAccess.DatabaseAccess;
using DataAccess.Models;

namespace DataAccess.Data
{
    public class LogData : ILogData
    {
        private readonly ISQLDataAccess _dataBase;
        public LogData(ISQLDataAccess dataBase) { _dataBase = dataBase; }

        public Task<IEnumerable<LogModel>> GetLogs()
        {
            return _dataBase.LoadData<LogModel, dynamic>("dbo.getLogs", new { });
        }


        public Task<IEnumerable<LogModel>> GetLogsByDateTime(DateTime dateTime)
        {
            return _dataBase.LoadData<LogModel, dynamic>("dbo.getLogsByDateTime", new { DateTime = dateTime });
        }

        public Task<IEnumerable<LogModel>> GetLogsBySensorId(int sensorId)
        {
            return _dataBase.LoadData<LogModel, dynamic>("dbo.getLogsBySensorId", new { sensorId = sensorId });
        }



        public Task<IEnumerable<LogModel>> GetLogsByUserId(int userId)
        {
            return _dataBase.LoadData<LogModel, dynamic>("dbo.getLogsByUserId", new { UserId = userId });
        }

        public async Task<CreateLogModel?> GetLog(int id)
        {
            var results = await _dataBase.LoadData<CreateLogModel, dynamic>("dbo.getLogById", new { Id = id });
            return results.FirstOrDefault();
        }

        public Task InsertLog(CreateLogModel log)
        {
            return _dataBase.SaveData("dbo.insertLog", log);
        }
        public Task UpdateLog(LogModel log)
        {
            return _dataBase.SaveData("dbo.updateLog", log);
        }

        public Task DeleteLog(int id)
        {
            return _dataBase.SaveData("dbo.deleteLog", new { Id = id });
        }
    }
}