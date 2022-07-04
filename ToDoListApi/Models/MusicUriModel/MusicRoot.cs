using Newtonsoft.Json;
namespace ToDoListApi.Models.MusicUriModel
{
    public class MusicRoot
    {
        [JsonProperty("results")]
        public List<Result> Results { get; set; }
    }
}
