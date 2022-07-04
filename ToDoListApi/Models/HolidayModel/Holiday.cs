using Newtonsoft.Json;

namespace ToDoListApi.Models.Holiday
{
    public class Holiday
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("date")]
        public Date Date { get; set; }
    
    }
}
