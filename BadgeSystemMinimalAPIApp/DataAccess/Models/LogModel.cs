using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    public class LogModel : CreateLogModel
    {

        public int Id { get; set; }
    }

    public class CreateLogModel
    {
        public int UserId { get; set; }
        public int SensorId { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}
