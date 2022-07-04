using ToDoListApi.Constants;
using Newtonsoft.Json;
using ToDoListApi.Models.Holiday;
namespace ToDoListApi.Clients
{
    public class HolidayClient
    {
        private readonly string _address;
        private readonly string  _apikey;
        private readonly HttpClient _client;
        public HolidayClient()
        {
            _address = Constant.HolidayAddress;
            _apikey = Constant.HolidayApiKey;
            _client = new ();
            _client.BaseAddress = new Uri(_address);
        }
        public async Task<HolidayRoot> GetHolidayByDate(string country, string year, string month, string day)
        {
            
            var responce = await _client.GetAsync($"/api/v2/holidays?&api_key={_apikey}&country={country}&year={year}&month={month}&day={day}");
            HttpResponseMessage http = responce;
            if (http.IsSuccessStatusCode == false)
            {
                return null;
            }
            else
            {
                var content = responce.Content.ReadAsStringAsync().Result;
                var json = JsonConvert.DeserializeObject<HolidayRoot>(content);
                return json;
            }
        }
        
    }
    
}
