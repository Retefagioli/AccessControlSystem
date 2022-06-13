using ACSApp.Autenticazione;
using ACSApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace ACSApp.ViewModels
{
    public class LogsPageViewModel
    {

        
        public HttpServices service;
        public LogsPageViewModel()
        {
            service = new HttpServices();
        }


        public async Task<List<LogsModel>> updateLogs()
        {
            return await service.getLogs();
        }
        public async Task<List<SensorModel>> updateSensors()
        {
            return await service.getSensors();
        }
    }
}
