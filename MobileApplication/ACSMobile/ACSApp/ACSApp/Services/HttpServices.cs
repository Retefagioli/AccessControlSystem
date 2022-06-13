using ACSApp.Models;
using ACSApp.Settings;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ACSApp.Autenticazione
{
    public class HttpServices
    {

        private int UserId { get; set; } = SettingsController.getUserId();
        string base_url = "https://datain-stage.azurewebsites.net/api";
        HttpClient client;
        public HttpServices()
        {
            initHttpClient();
        }


        public async Task<bool> validateToken(string token)
        {

           
            HttpResponseMessage message = await client.GetAsync(base_url + "/AccessToken/Token/" + token);
            if (message.IsSuccessStatusCode)
            {
                string stringa = await message.Content.ReadAsStringAsync();
                Console.WriteLine(stringa);
                if (string.IsNullOrEmpty(stringa)) return false;
                TokenModel new_token = JsonConvert.DeserializeObject<TokenModel>(stringa);
                if (new_token.Token == token)
                {
                    Console.WriteLine("Lo user id is: "+ new_token.userid);
                    saveUserInfo(new_token.userid);
                    SettingsController.setUserId(new_token.userid);
                    return true;
                }
                else return false;
            } else
            {
                return false;
            }


        }

        public async void saveUserInfo(int id_user)
        {
            HttpResponseMessage response = await client.GetAsync(base_url + "/Users/" + id_user+"");
            if (response.IsSuccessStatusCode)
            {
                var stringa = await response.Content.ReadAsStringAsync();
                Console.WriteLine(stringa);
                SettingsController.saveUserData(stringa);
                Console.WriteLine("UserDataGotten");
            }
            
        }

        private void initHttpClient()
        {

            client = new HttpClient();
            client.BaseAddress = new Uri(base_url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public async Task<List<LogsModel>> getLogs() {
            HttpResponseMessage response = await client.GetAsync(base_url + "/Logs/by-user/?userId=" + UserId);
            Console.WriteLine("Entered Log function");
            Console.WriteLine(UserId);
            if (response.IsSuccessStatusCode)
            {
                var stringa = await response.Content.ReadAsStringAsync();
                Console.WriteLine("LETSGOOOO");
                Console.WriteLine(stringa);
                
                List<LogsModel>logs = JsonConvert.DeserializeObject<List<LogsModel>>(stringa);
                return logs;
            }
            else 
            {
                return null;
            }
            
        
        }
        public async Task<List<SensorModel>> getSensors() {
            HttpResponseMessage response = await client.GetAsync(base_url + "/Sensors");
            Console.WriteLine("Enter sensors function");
            if (response.IsSuccessStatusCode)
            {
                var stringa = await response.Content.ReadAsStringAsync();
                
                var sensor = JsonConvert.DeserializeObject<WrapperSensorsModel>(stringa);
                Console.WriteLine(stringa);
                var sensor2 = sensor.value;
                return sensor2;
            }
            else {
                return null;
            }
        }

        public async void sendTagNfc(string tagNFC)
        {
            Console.WriteLine("PLEASE WORKA");
            BadgeModel badge = new BadgeModel();
            badge.userId = UserId;
            badge.nfcTag = tagNFC;
            Console.WriteLine(badge.userId);
            Console.WriteLine(badge.nfcTag);
            var badgeJson = JsonConvert.SerializeObject(badge, Formatting.Indented);
            Console.WriteLine(badgeJson);
            var payload = new StringContent(badgeJson, Encoding.UTF8, "application/json");
            HttpResponseMessage reponse = await client.PostAsync(base_url+"/Badges", payload);
            reponse.EnsureSuccessStatusCode();

        }
    }
}
