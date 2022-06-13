using System;
using System.Collections.Generic;
using System.Text;

namespace ACSApp.Models
{
    public class SensorModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public int groupId { get; set; }

        public string nfcTag { get; set; }

        public override string ToString()
        { 
            return id+";"+name+";"+groupId;
        }
    }
}
