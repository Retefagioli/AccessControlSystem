using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACSApp.Models
{
    public class UserModel
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public int groupId { get; set; }
        public int id { get; set; }

        public static string toString(UserModel user)
        {
            return JsonConvert.SerializeObject(user);

        }

        public static UserModel fromString(string formattedString)
        { 
            return JsonConvert.DeserializeObject<UserModel>(formattedString);
        }

    }
}