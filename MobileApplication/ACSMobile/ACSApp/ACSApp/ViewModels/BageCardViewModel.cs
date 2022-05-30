using ACSApp.Settings;
using ACSApp.View;
using Plugin.NFC;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ACSApp.ViewModels
{
    public class BageCardViewModel : BaseBadgeViewModel
    {

        NFCNdefTypeFormat _type = NFCNdefTypeFormat.WellKnown;
        public BageCardViewModel() { }
        public BageCardViewModel(ContentPage page)
        {
            _page = page;
        }

        public override void SubscribeEvents()
        {
            if (eventsAlreadySubscribed) {
                CrossNFC.Current.OnMessageReceived -= Current_OnMessageReceived;
                CrossNFC.Current.OnMessageReceived += Current_OnMessageReceived;
                CrossNFC.Current.OnTagDiscovered -= Current_OnTagDiscovered;
                CrossNFC.Current.OnTagDiscovered += Current_OnTagDiscovered;
                Debug.WriteLine("RESUBSCRIBE EVENTS", "RESUBSCRIBER");
               
                return; }
            eventsAlreadySubscribed = true;

            CrossNFC.Current.OnMessageReceived += Current_OnMessageReceived;
            CrossNFC.Current.OnTagDiscovered += Current_OnTagDiscovered;

            
        }

        
        public override void UnsubscribeEvents()
        {
            CrossNFC.Current.OnMessageReceived -= Current_OnMessageReceived;

        }

        public async override void initNFC()
        {
            checkNFC();
            SubscribeEvents();
            //Debug.WriteLine("Start Listening", "CrossNFC");
            //await StartListeningIfNotiOS();
        }

        public override void TerminateNFC()
        {
            UnsubscribeEvents();
            CrossNFC.Current.StopListening();
        }
        public void Current_OnMessageReceived(ITagInfo tagInfo)
        {

           
            if (tagInfo == null)
            {
                Debug.WriteLine("No tag found", "crossNFC");
                return;
            }
            var identifier = tagInfo.Identifier;
            var serialNumber = NFCUtils.ByteArrayToHexString(identifier, ":");
            var title = !string.IsNullOrWhiteSpace(serialNumber) ? $"Tag [{serialNumber}]" : "Tag Info";

            if (!tagInfo.IsSupported)
            {
                displayMessage("Unsupported tag", title);

            }
            else if (tagInfo.IsEmpty)
            {
                displayMessage("Empty tag", title);
            }
            else
            {
                var first = tagInfo.Records[0];
                displayMessage(GetMessage(first), title);
            }
            Debug.WriteLine("ON MESSAAGE RECEIVED ACTIVATED", "DEBUGDEMON PT 2");
        }


        public ICommand OnWriteRequest => new Command(OnWriteButtonClicked);
        public ICommand OnListenRequest => new Command(async () => await BeginListening());

        async void OnWriteButtonClicked() {
            Debug.WriteLine("THIS IS THE ON WRITE BUTTON CLICKED", "XDXDXDDXDX");
            await StartListeningIfNotiOS();
            try
            {
                CrossNFC.Current.StartPublishing();
            }
            catch (Exception e)
            {
                displayMessage(e.Message, ALERT_TITLE);
            }
        }

        private void Current_OnTagDiscovered(ITagInfo tagInfo, bool format)
        {
            if (!CrossNFC.Current.IsWritingTagSupported)
            {
                displayMessage("Writing tag is not supported on this device", "Error");
                return;
            }

            try
            {
                NFCNdefRecord record = new NFCNdefRecord
                {
                    TypeFormat = _type,
                    MimeType = MIME_TYPE,
                    Payload = NFCUtils.EncodeToByteArray("Funziona"),
                    LanguageCode = "en"

                };


                tagInfo.Records = new[] { record };
                CrossNFC.Current.PublishMessage(tagInfo);
            }
            catch (Exception e)
            {
                displayMessage(e.Message, "Error");
            }
        }

    }
}
