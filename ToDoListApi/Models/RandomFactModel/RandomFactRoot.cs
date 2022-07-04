using Newtonsoft.Json;

namespace ToDoListApi.Models.RandomFactModel
{
    public class RandomFactRoot
    {
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
