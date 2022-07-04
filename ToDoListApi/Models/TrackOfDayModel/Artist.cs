using Newtonsoft.Json;

namespace ToDoListApi.Models.TrackOfDayModel
{
    public class Artist
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
