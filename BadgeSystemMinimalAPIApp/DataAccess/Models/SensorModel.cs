namespace DataAccess.Models {
    public class SensorModel : CreateSensorModel
    {
        public int Id { get; set; }
    }

    public class CreateSensorModel
    {
        public string? Name { get; set; }
        public int GroupId { get; set; }
        public string? NFCTag { get; set; }
    }
}