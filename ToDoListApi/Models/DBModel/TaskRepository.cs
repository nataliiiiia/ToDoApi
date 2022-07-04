using Newtonsoft.Json;

namespace ToDoListApi.Models.DBModel
{
    public class TaskRepository
    {
        [JsonProperty("UID")]
        public string UID { get; set; }

        [JsonProperty("task")]
        public string Task { get; set; }
    }
    

}
