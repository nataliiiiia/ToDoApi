using ToDoListApi.Models.DBModel;


namespace ToDoListApi.Clients
{
    public interface ITaskClient
    {
        public Task<List<TaskRepository>> GetAllNotes { get; set; }
        public Task PostNote { get; set; }
        public Task DeleteNote { get; set; }
        
    }
}
