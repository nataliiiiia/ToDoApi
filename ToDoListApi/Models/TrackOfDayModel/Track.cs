using Newtonsoft.Json;

namespace ToDoListApi.Models.TrackOfDayModel
{
    public class Track
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("artist")]
        public Artist Artist { get; set; }
    }
}
