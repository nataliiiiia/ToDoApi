using Newtonsoft.Json;
using ToDoListApi.Constants;
using ToDoListApi.Models.WordOfDayModel;

namespace ToDoListApi.Clients
{
	public class WordOfDayClient
	{
		private readonly string _apikey;
		private readonly string _address;
		private readonly HttpClient _client;
		public WordOfDayClient()
        {
			_address = Constant.WordOfDayAddress;
			_apikey = Constant.WordOfDayApiKey;
			_client = new();
			_client.BaseAddress = new Uri(_address);
			_client.DefaultRequestHeaders.Add("X-RapidAPI-Host", _address.Substring(8));
			_client.DefaultRequestHeaders.Add("X-RapidAPI-Key", _apikey);
			
		}
		public async Task<WordOfDayRoot> GetRandomWord()
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
				var json = JsonConvert.DeserializeObject<WordOfDayRoot>(content);
				return json;
			}
		}
	}
	
}
