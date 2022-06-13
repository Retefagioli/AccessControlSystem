using ACSApp.Models;
using ACSApp.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ACSApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageContent : ContentPage
    {
        public MainPageContent()
        {
            
            
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            initWelcome();
            base.OnAppearing();
        }

        public void initWelcome()
        { 
            var newer = SettingsController.getUserData();
            //welcomeText.Text = "Benvenuto " + newer.name + " " + newer.surname + " !";
        }
    }
}