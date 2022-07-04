using Newtonsoft.Json;

namespace ToDoListApi.Models.MusicUriModel
{
    public class Result
    {

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
