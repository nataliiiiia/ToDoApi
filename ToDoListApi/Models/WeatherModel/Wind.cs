using Newtonsoft.Json;

namespace ToDoListApi.Models.WeatherModel
{
    public class Wind
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }
    }
}
