using ToDoListApi.Constants;
using ToDoListApi.Models.WeatherModel;
using Newtonsoft.Json;

namespace ToDoListApi.Clients
{
    public class WeatherClient
    {
        private readonly string _apikey;
        private readonly string _address;
        private readonly HttpClient _client;
        public WeatherClient()
        {
            _address = Constant.WeatherAddress;
            _apikey = Constant.WeatherApiKey;
            _client = new();
            _client.BaseAddress = new Uri(_address);
        }
        public async Task<WeatherRoot> GetWeatherByCity(string city)
        {
            var responce = await _client.GetAsync($"?q={city}&cnt=1&appid={_apikey}&units=metric");
            var content = responce.Content.ReadAsStringAsync().Result;
            HttpResponseMessage http = responce;
            if (http.IsSuccessStatusCode == false )
            {
                return null;
            }
            else 
            {
                var json = JsonConvert.DeserializeObject<WeatherRoot>(content);
                json.City.Sunset = UnixTimeStampToString(json.City.Sunset);
                json.City.Sunrise = UnixTimeStampToString(json.City.Sunrise);
                return json;
            }
        }
        
        private static string UnixTimeStampToString(string unixTimeStamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(double.Parse(unixTimeStamp)).ToLocalTime();
            return dateTime.ToString().Substring(11);
        }





    }
}
