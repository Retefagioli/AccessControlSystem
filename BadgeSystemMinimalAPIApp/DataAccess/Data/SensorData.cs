using DataAccess.DatabaseAccess;
using DataAccess.Models;

namespace DataAccess.Data {
    public class SensorData : ISensorData
    {
        private readonly ISQLDataAccess _dataBase;
        public SensorData(ISQLDataAccess dataBase) { _dataBase = dataBase; }

        public Task<IEnumerable<SensorModel>> GetSensors()
        {
            return _dataBase.LoadData<SensorModel, dynamic>("dbo.getSensors", new { });
        }
        public async Task<SensorModel?> GetSensorById(int id)
        {
            var results = await _dataBase.LoadData<SensorModel, dynamic>("dbo.getSensorById", new { Id = id });
            return results.FirstOrDefault();
        }

        public async Task<SensorModel?> GetSensorByNFCTag(string nfcTag)
        {
            var results = await _dataBase.LoadData<SensorModel, dynamic>("dbo.getSensorByNFCTag", new { NFCTag = nfcTag });
            return results.FirstOrDefault();
        }

        public Task InsertSensor(CreateSensorModel sensor)
        {
            return _dataBase.SaveData("dbo.insertSensor", new { sensor.Name, sensor.GroupId, sensor.NFCTag });
        }
        public Task UpdateSensor(SensorModel sensor)
        {
            if (sensor is null)
            {
                throw new ArgumentNullException(nameof(sensor));
            }

            return _dataBase.SaveData("dbo.updateSensor", sensor);
        }

        public Task DeleteSensor(int id)
        {
            return _dataBase.SaveData("dbo.deleteSensor", new { Id = id });
        }
    }
}