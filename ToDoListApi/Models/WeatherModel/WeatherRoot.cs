using Newtonsoft.Json;
namespace ToDoListApi.Models.WeatherModel
{
    public class WeatherRoot
    {
        [JsonProperty("list")]
        public List<List> List { get; set; }

        [JsonProperty("city")]
        public City City { get; set; }
    }
}
