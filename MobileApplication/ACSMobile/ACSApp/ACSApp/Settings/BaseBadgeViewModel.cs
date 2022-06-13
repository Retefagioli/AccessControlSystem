using ACSApp.Autenticazione;
using Plugin.NFC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ACSApp.Settings
{
    public abstract class BaseBadgeViewModel : INotifyPropertyChanged
    {
        public bool isDeviceIOS { get; set; } = false;
        public const string ALERT_TITLE = "NFC";
        public const string MIME_TYPE = "application/com.retefagioli.nfcsample";
        public HttpServices services = new HttpServices();
        public bool eventsAlreadySubscribed { get; set; } = false;


        public bool DeviceIsListening
        {
            get => _deviceIsListening;
            set
            {
                _deviceIsListening = value;
                OnPropertyChanged(nameof(DeviceIsListening));
            }
        }
        private bool _deviceIsListening;
        public ContentPage _page { set; get; }

        public event PropertyChangedEventHandler PropertyChanged;


        void OnPropertyChanged(string name) =>
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public BaseBadgeViewModel()
        { 
        
        }

        public async void checkNFC()
        {
            CrossNFC.Legacy = true;
            if (!CrossNFC.IsSupported) { await _page.DisplayAlert("Warning", "This device doesn't support NFC technology", "Close"); return; };
            if (!CrossNFC.Current.IsEnabled) { await _page.DisplayAlert("Attention", "The NFC is not enable", "Close"); return; };
            if (!CrossNFC.Current.IsAvailable) { await _page.DisplayAlert("Attention", "The NFC is not available", "Close"); return; };
            if (Device.RuntimePlatform == Device.iOS) isDeviceIOS = true;
        }

        public abstract void SubscribeEvents();

        public abstract void UnsubscribeEvents();

        public abstract void TerminateNFC();
        public abstract void initNFC();

        public async void displayMessage(string Message, string title)
        {
           await _page.DisplayAlert(string.IsNullOrWhiteSpace(title) ? ALERT_TITLE : title, Message, "chiudi");
        }
        
        public string GetMessage(NFCNdefRecord record)
        {
            var x = record.Message;
            //services.sendTagNfc(x);
            var message = $"Message: {x}";
            message += Environment.NewLine;
            message += $"RawMessage: {Encoding.UTF8.GetString(record.Payload)}";
            message += Environment.NewLine;
            message += $"Type: {record.TypeFormat}";

            if (!string.IsNullOrWhiteSpace(record.MimeType))
            {
                message += Environment.NewLine;
                message += $"MimeType: {record.MimeType}";
            }

            return message;
        }

        public async Task StartListeningIfNotiOS()
        {
            if (isDeviceIOS)
                return;
            await BeginListening();
        }
        public async Task BeginListening()
        {
            try
            {
                CrossNFC.Current.StartListening();
            }
            catch (Exception ex)
            {
                displayMessage(ex.Message, "");
            }
        }

        async Task StopListening()
        {
            try
            {
                CrossNFC.Current.StopListening();
            }
            catch (Exception ex)
            {
                displayMessage(ex.Message, "");
            }
        }
    }
}
