using System;
using System.Collections.Generic;
using System.Text;

namespace ACSApp.Models
{
    public class UpdatedLogsModel
    {
        public int id { get; set; }
        public int userId { get; set; }
        public String sensorName { get; set; }
        public DateTime dateTime { get; set; }

        public UpdatedLogsModel(int id, int userId, string sensorName, DateTime dateTime)
        {
            this.id = id;
            this.userId = userId;
            this.sensorName = sensorName;
            this.dateTime = dateTime;
        }
    }
}
