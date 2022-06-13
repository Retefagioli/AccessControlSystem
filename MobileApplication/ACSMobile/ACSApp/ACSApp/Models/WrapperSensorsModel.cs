using System;
using System.Collections.Generic;
using System.Text;

namespace ACSApp.Models
{
    public class WrapperSensorsModel
    {
        public List<SensorModel> value { get; set; }
        public int statusCode { get; set; }
        public string contentType { get; set; }
    }
}
