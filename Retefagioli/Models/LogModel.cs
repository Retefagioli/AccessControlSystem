using System.Text.Json.Serialization;

namespace Retefagioli.Models
{
    public class LogModel
    {
        public LogModel()
        {

        }
        public LogModel(int id, int userId, int sensorId, DateTime dateTime)
        {
            Id = id;
            UserId = userId;
            SensorId = sensorId;
            DateTime = dateTime;
        }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("userId")]
        public int UserId{ get; set; }

        [JsonPropertyName("sensorId")]
        public int SensorId{ get; set; }

        [JsonPropertyName("dateTime")]
        public DateTime DateTime { get; set; }

        public override string ToString()
        {
            return Id + " " + UserId + " " + SensorId + " " + DateTime;
        }
    }
}
