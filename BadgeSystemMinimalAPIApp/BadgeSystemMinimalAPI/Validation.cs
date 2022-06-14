using DataAccess.Data;
using DataAccess.Models;
using Newtonsoft;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace BadgeSystemMinimalAPI
{
    static public class Validation
    {
        static readonly string LOG_API = "/api/logs/";
        static readonly string BASE_URL = "/device";
        static readonly string ACCESS_API = "api/access";

        static readonly string USERS_API = "/api/users/";
        static readonly string SENSORS_API = "/api/sensors/by-nfcTag/";

        static async Task<UserModel?> GetUserAsync(string id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(USERS_API + id);
            UserModel? root = null;

            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                root = JsonConvert.DeserializeObject<UserModel>(jsonString);
            }

            return root;
        }

        static async Task<SensorModel?> GetSensorAsync(string nfcTag)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(SENSORS_API + nfcTag);
            SensorModel? root = null;

            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                root = JsonConvert.DeserializeObject<SensorModel>(jsonString);
                Console.WriteLine(root.Name);
            }

            return root;
        }

        static public async void validation(CreateBadgeModel badge, IBadgeData data)
        {

            string? userId = badge.UserId.ToString();
            string? sensorNFCTag = badge.NFCTag;

            UserModel? _user = await GetUserAsync(userId);
            SensorModel? _sensor = await GetSensorAsync(sensorNFCTag);

            string message = _user.GroupId == _sensor.GroupId ? "True" : "False";
            Console.WriteLine(message);

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BASE_URL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            StringContent content = new StringContent(message);
            HttpResponseMessage response2 = await client.PostAsync(BASE_URL + ACCESS_API, content);


            CreateLogModel log = new CreateLogModel { UserId = int.Parse(userId), SensorId = _sensor.Id, DateTime = DateTime.Now };

            client = new HttpClient();
            client.BaseAddress = new Uri(LOG_API);
            var response = client.PostAsJsonAsync(LOG_API, log);
        }
    }
}
