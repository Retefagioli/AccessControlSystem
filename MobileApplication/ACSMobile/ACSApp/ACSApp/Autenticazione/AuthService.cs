using ACSApp.Models;
using ACSApp.Settings;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ACSApp.Autenticazione
{
    public class AuthService
    {

        string base_url = "https://datain-stage.azurewebsites.net/";
        HttpClient client;
        public AuthService()
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
                    return true;
                }
                else return false;
            } else
            {
                return false;
            }


        }

        public async void saveUserInfo(int id_group)
        {
            HttpResponseMessage response = await client.GetAsync(base_url + "/Users/" + id_group+"");
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
        
    }
}
