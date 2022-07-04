using Newtonsoft.Json;

namespace ToDoListApi.Models.TrackOfDayModel
{
    public class TrackRoot
    {
        [JsonProperty("tracks")]
        public Tracks Tracks { get; set; }
    }
}
