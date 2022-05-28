using ACSApp.Autenticazione;
using ACSApp.Settings;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ACSApp.ViewModels
{
    public class LoadingPageViewModel
    {
        static int cnt;
        public LoadingPageViewModel()
        {
                
        }

        public async Task Init()
        {

            if (cnt++ != 0) return;
            Console.WriteLine("Autentication Phase");
            Console.WriteLine(SettingsController.isAutenticated());

            if (SettingsController.isAutenticated() == "true")
            {
                SettingsController.disableAutentication();
                await Shell.Current.GoToAsync("///main");
                
            }else
            {
                Console.WriteLine("The User is not autenticated");
                await Shell.Current.GoToAsync("///login");
            }
        }

    }
}
