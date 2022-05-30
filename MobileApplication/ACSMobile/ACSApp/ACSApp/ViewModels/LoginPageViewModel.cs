using ACSApp.Autenticazione;
using ACSApp.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ACSApp.ViewModels
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {

        public ICommand OnLoginCommand => new Command(OnLoginSystem);
        public string LoginToken { get => loginToken; set { loginToken = value; OnPropertyChanged(nameof(LoginToken)); } }
        public string loginToken;
        public string ErrorMessage { get => errorMessage; set { errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); } }
        public string errorMessage;

        public event PropertyChangedEventHandler PropertyChanged;


        void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        private async void OnLoginSystem()
        {
            //new AuthService().getAuthTokenResult(LoginToken);
            if (LoginToken == "Alessandro")
            {
                Debug.WriteLine("Autentication is completed", "Autentication System");
                SettingsController.setAutentication();
                await Shell.Current.GoToAsync("///main");
            }
            else {
                ErrorMessage = "Password non corretta";
                Debug.WriteLine($"La password e' sbagliata {ErrorMessage}", "Autentication System");
                LoginToken = "";
            }

        }
    }
    
}
