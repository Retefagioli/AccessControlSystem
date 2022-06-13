using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACSApp.ViewModels;
using ACSApp.Settings;
using Xamarin.Forms;
using Plugin.NFC;
using Xamarin.Forms.Xaml;
using Rg.Plugins.Popup.Extensions;
using System.Diagnostics;

namespace ACSApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BadgeCardView : ContentPage
    {
        public BadgeCardView()
        {
            InitializeComponent();
            imageWave.Source = ImageSource.FromResource("ACSApp.Resources.Images.nonodude.gif");

            viewModel = new BadgeCardViewModel(this);
        }

        BadgeCardViewModel viewModel { get; set; }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.initNFC();

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }


        protected override bool OnBackButtonPressed()
        {
            viewModel.TerminateNFC();
            Debug.WriteLine("WHAT HAPPEND", "ONBACKBUTTONPRESSED");
            return base.OnBackButtonPressed();
        }
    }
}