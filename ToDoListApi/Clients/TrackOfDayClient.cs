using Newtonsoft.Json;
using ToDoListApi.Constants;
using ToDoListApi.Models.TrackOfDayModel;
namespace ToDoListApi.Clients
    
{
    public class TrackOfDayClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _address;
        public TrackOfDayClient()
        {
            _httpClient = new HttpClient();
            _apiKey = Constant.MusicApiKey;
            _address = Constant.MusicAddress;
            _httpClient.BaseAddress = new Uri(_address);
        }
        public async Task<TrackRoot> GetFirstChartTrack()
        {
            var responce = await _httpClient.GetAsync($"?method=chart.gettoptracks&api_key={_apiKey}&format=json&limit=3");
            HttpResponseMessage http = responce;
            if (http.IsSuccessStatusCode == false)
            {
                return null;
            }
            else
            {
                var content = responce.Content.ReadAsStringAsync().Result;
                var json = JsonConvert.DeserializeObject<TrackRoot>(content);
                return json;
            }
        }
    }
}
