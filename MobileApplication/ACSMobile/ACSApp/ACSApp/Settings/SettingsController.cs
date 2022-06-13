using ACSApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace ACSApp.Settings
{
    static class SettingsController
    {
        public static string isAutenticated()
        {
            return Preferences.Get("Autentication", "false");
        }
        public static void setAutentication()
        {
            Preferences.Set("Autentication", "true");
        }

        public static void disableAutentication()
        {
            Preferences.Remove("Autentication");
        }

        public static void renewConfig()
        {
            string auth = Preferences.Get("Autentication", "false");
            Preferences.Set("Autentication", auth);
        }

        public static void saveUserData(string stringa)
        {
            Preferences.Set("UserData", stringa);
        }

        public static UserModel getUserData()
        {
            string x = Preferences.Get("UserData", "");
            Console.WriteLine(x);
            return UserModel.fromString(x);
        }

        public static void setUserId(int id)
        {
            Preferences.Set("UserId", id);
        }

        public static int getUserId()
        {
            return Preferences.Get("UserId", -1);
        }
    }


}
