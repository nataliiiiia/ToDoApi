using Newtonsoft.Json;
namespace ToDoListApi.Models.WeatherModel
{
    public class Weather
    {
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
