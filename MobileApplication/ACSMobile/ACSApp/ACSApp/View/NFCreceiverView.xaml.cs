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

namespace ACSApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NFCreceiverView : ContentPage
    {
        public NFCreceiverView()
        {
            InitializeComponent();
            viewModel = new NFCreceiverViewModel(this);
        }

        NFCreceiverViewModel viewModel { get; set; }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            viewModel.initNFC();

        }


        protected override bool OnBackButtonPressed()
        {
            viewModel.TerminateNFC();
            return base.OnBackButtonPressed();
        }
    }
}