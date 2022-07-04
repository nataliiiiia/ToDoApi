using Newtonsoft.Json;

namespace ToDoListApi.Models.WeatherModel
{
    public class City
    {
        [JsonProperty("sunrise")]
        public string Sunrise { get; set; }

        [JsonProperty("sunset")]
        public string Sunset { get; set; }
    }
}
