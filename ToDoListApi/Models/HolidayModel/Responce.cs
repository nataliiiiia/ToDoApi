using Newtonsoft.Json;

namespace ToDoListApi.Models.Holiday
{
    public class Responce
    {
        [JsonProperty("holidays")]
        public List<Holiday> Holidays { get; set; }
    }
}
