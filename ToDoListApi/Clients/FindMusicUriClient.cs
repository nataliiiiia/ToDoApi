using ToDoListApi.Constants;
using ToDoListApi.Models.MusicUriModel;
using Newtonsoft.Json;
namespace ToDoListApi.Clients
{
    public class FindMusicUriClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _address;
        private readonly string _apiKey;
        public FindMusicUriClient()
        {
            _apiKey = Constant.FindMusicApiKey;
            _httpClient = new HttpClient();
            _address = Constant.FindMusicAddress;
            _httpClient.BaseAddress = new Uri(_address);
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", _address.Substring(8));
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", _apiKey);
        }
        public async Task<MusicRoot> GetMusicUriAsync(string song)
        {
            var responce = await _httpClient.GetAsync($"/search?query={song}&safesearch=false");
            HttpResponseMessage http = responce;
            if (http.IsSuccessStatusCode == false)
            {
                return null;
            }
            else
            {
                var content = responce.Content.ReadAsStringAsync().Result;
                var json = JsonConvert.DeserializeObject<MusicRoot>(content);
                return json;
            }
        }
    }
}
