using System;
using System.Collections.Generic;
using System.Text;

namespace ACSApp.Models
{
    public class TokenModel
    {
        public int id { get; set; }
        public string Token { get; set; }
        public int userid { get; set; }

        public override string ToString()
        {
            return id + ";" + Token + ";" + userid+";";
        }
    }
}
