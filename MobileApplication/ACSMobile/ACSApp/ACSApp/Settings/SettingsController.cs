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

        public static string getBaseUrl(string update_url)
        {

            Preferences.Set("Base_url", update_url);
            return Preferences.Get("Base_url", "https://localhost:8080/");
        }

        public static string getTokenApi(string update_api)
        {
            Preferences.Set("TokenApi", update_api);
            return Preferences.Get("TokenApi", "/api/validateToken");
        }

    }    
}
