using DataAccess.Models;

namespace DataAccess.Data
{
    public interface ISensorData
    {
        Task DeleteSensor(int id);
        Task<SensorModel?> GetSensorById(int id);
        Task<SensorModel?> GetSensorByNFCTag(string nfcTag);
        Task<IEnumerable<SensorModel>> GetSensors();
        Task InsertSensor(CreateSensorModel sensor);
        Task UpdateSensor(SensorModel sensor);
    }
}