using Newtonsoft.Json;

namespace ToDoListApi.Models.Holiday
{
    public class Date
    {
        [JsonProperty("iso")]
        public string Iso { get; set; }

    }
}
