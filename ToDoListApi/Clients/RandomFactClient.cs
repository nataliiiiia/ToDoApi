using Newtonsoft.Json;
using ToDoListApi.Constants;
using ToDoListApi.Models.RandomFactModel;

namespace ToDoListApi.Clients
{
    public class RandomFactClient
    {      
        private readonly string _address;
        private readonly HttpClient _client;
        public RandomFactClient()
        {
            _address = Constant.RandomFactAddress;
            _client = new();
            _client.BaseAddress = new Uri(_address);
        }
        public async Task<RandomFactRoot> GetRandomFact()
        {
            var responce = await _client.GetAsync("");
            HttpResponseMessage http = responce;
            if (http.IsSuccessStatusCode == false)
            {
                return null;
            }
            else
            {
                var content = responce.Content.ReadAsStringAsync().Result;
                var json = JsonConvert.DeserializeObject<RandomFactRoot>(content);
                return json;
            }
        }
    }
}
