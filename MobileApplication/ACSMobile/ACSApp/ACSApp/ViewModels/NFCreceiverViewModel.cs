using ACSApp.Settings;
using ACSApp.View;
using Plugin.NFC;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace ACSApp.ViewModels
{
    public class NFCreceiverViewModel : NFCBaseViewModel
    {
        
        public NFCreceiverViewModel(ContentPage page)
        {
            _page = page;
        }

        public override void SubscribeEvents()
        {
            if (eventsAlreadySubscribed) { CrossNFC.Current.OnMessageReceived -= Current_OnMessageReceived; CrossNFC.Current.OnMessageReceived += Current_OnMessageReceived; return; }
            eventsAlreadySubscribed = true;

            CrossNFC.Current.OnMessageReceived += Current_OnMessageReceived;

           // if (isDeviceiOS)
             //  CrossNFC.Current.OniOSReadingSessionCancelled += Current_OniOSReadingSessionCancelled;
        }

        public override void UnsubscribeEvents()
        {
            CrossNFC.Current.OnMessageReceived -= Current_OnMessageReceived;

        }

        public async override void initNFC()
        {
            checkNFC();
            SubscribeEvents();
            Console.WriteLine("Starting to listening");
            await StartListeningIfNotiOS();
        }

        public override void TerminateNFC()
        {
            UnsubscribeEvents();
            CrossNFC.Current.StopListening();
        }
        void Current_OnMessageReceived(ITagInfo tagInfo)
        {
            
            if (tagInfo == null) {
                Console.WriteLine("No tag found");
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
        }
    }
}
