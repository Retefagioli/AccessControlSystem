using ACSApp.Models;
using ACSApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ACSApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogsView : ContentPage
    {

        public ObservableCollection<UpdatedLogsModel> logs { get; set; } = new ObservableCollection<UpdatedLogsModel>();
        public List<LogsModel> baiter = new List<LogsModel>();
        public List<SensorModel> sensorModels { get; set; } = new List<SensorModel>();
        

        
        LogsPageViewModel viewModel;
        public LogsView()
        {
            InitializeComponent();
            this.BindingContext = this;
            viewModel = new LogsPageViewModel();
            ListViewItems.ItemsSource = logs;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            
            baiter = await viewModel.updateLogs();
            sensorModels = await viewModel.updateSensors();
            for (int i = baiter.Count - 1; i >= 0; i--)
            {
                string p = "";
                foreach(var y in sensorModels)
                {
                    if (y.id == baiter[i].sensorId)
                    {
                        p = y.name;
                    }
                }
                var k = new UpdatedLogsModel
                (
                    baiter[i].id,
                    baiter[i].userId,
                    p,
                    baiter[i].dateTime
                );
                logs.Add(k);
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            logs = new ObservableCollection<UpdatedLogsModel>();
            ListViewItems.ItemsSource = logs;
        }
    }
}