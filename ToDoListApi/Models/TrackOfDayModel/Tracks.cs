using Newtonsoft.Json;

namespace ToDoListApi.Models.TrackOfDayModel
{
    public class Tracks
    {
        [JsonProperty("track")]
        public List<Track> Track { get; set; }
    }
}
