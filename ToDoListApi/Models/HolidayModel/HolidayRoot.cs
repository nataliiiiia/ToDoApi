using Newtonsoft.Json;
using ToDoListApi.Models.Holiday;

namespace ToDoListApi.Models.Holiday
{
    public class HolidayRoot
    {
        [JsonProperty("response")]
        public Responce Response { get; set; }
    }
}
