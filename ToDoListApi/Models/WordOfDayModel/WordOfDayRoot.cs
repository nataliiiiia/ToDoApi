using Newtonsoft.Json;

namespace ToDoListApi.Models.WordOfDayModel
{
    public class WordOfDayRoot
    {
        [JsonProperty("word")]
        public string Word { get; set; }
    }
}
