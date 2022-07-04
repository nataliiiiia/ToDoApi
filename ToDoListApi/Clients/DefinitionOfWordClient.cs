using Newtonsoft.Json;
using ToDoListApi.Constants;
using ToDoListApi.Models.DefinitionOfWordModel;
using ToDoListApi.Models.WordOfDayModel;
namespace ToDoListApi.Clients
{
    public class DefinitionOfWordClient
    {
        private readonly string _apikey;
        private readonly string _address;
        private readonly HttpClient _httpClient;
        public DefinitionOfWordClient()
        {
            _address = Constant.DefAddress;
            _apikey = Constant.DefApiKey;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_address);
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", _address.Substring(8));
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", _apikey);
        }
        public async Task<DefinitionRoot> GetDefinitionOfWordAsync(string word)
        {
            var responce = await _httpClient.GetAsync($"{word}");
            HttpResponseMessage http = responce;
            if (http.IsSuccessStatusCode == false)
            {
                return null;
            }
            else
            {
                var content = responce.Content.ReadAsStringAsync().Result;
                var json = JsonConvert.DeserializeObject<DefinitionRoot>(content);
                return json;
            }
        }
    }
}
