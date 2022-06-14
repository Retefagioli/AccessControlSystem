using DataAccess.Models;

namespace DataAccess.Data
{
    public interface ILogData
    {
        Task DeleteLog(int id);
        Task<CreateLogModel?> GetLog(int id);
        Task<IEnumerable<LogModel>> GetLogs();
        Task<IEnumerable<LogModel>> GetLogsByDateTime(DateTime dateTime);
        Task<IEnumerable<LogModel>> GetLogsBySensorId(int id);
        Task<IEnumerable<LogModel>> GetLogsByUserId(int id);
        Task InsertLog(CreateLogModel log);
        Task UpdateLog(LogModel log);
    }
}