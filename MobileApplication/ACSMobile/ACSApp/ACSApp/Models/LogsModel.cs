using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ACSApp.Models
{
    public class LogsModel
    {
        public int id { get; set; }
        public int userId { get; set; }
        public int sensorId { get; set; }
        public DateTime dateTime { get; set; }

        public override string ToString()
        {
            return id+";"+userId+";";
        }
    }
}
