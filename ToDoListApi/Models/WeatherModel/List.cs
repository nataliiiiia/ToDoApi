using Newtonsoft.Json;
namespace ToDoListApi.Models.WeatherModel

{
    public class List
    {
        [JsonProperty("main")]
        public Main Main { get; set; }

        [JsonProperty("weather")]
        public List<Weather> Weather { get; set; }

        [JsonProperty("wind")]
        public Wind Wind { get; set; }


    }
}
