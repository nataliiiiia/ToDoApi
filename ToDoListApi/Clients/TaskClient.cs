using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using ToDoListApi.Models.DBModel;
using ToDoListApi.Constants;
namespace ToDoListApi.Clients
{
    public class TaskClient : ITaskClient
    {
        public string _tableName;
        private readonly IAmazonDynamoDB _amazonDB;
        public TaskClient(IAmazonDynamoDB dynamoDB)
        {
            _amazonDB = dynamoDB;
            _tableName = "ToDoList";
        }

        public async Task<bool> PostNote(TaskRepository task)
        {
            var request = new PutItemRequest
            {
                TableName = _tableName,
                Item = new Dictionary<string, AttributeValue>()
                {
                    {"task", new AttributeValue{S = task.Task } },
                    {"UID", new AttributeValue{S = task.UID } }
                },
            };
            var response = await _amazonDB.PutItemAsync(request);
            return response.HttpStatusCode == System.Net.HttpStatusCode.OK;
        }
        public async Task<bool> DeleteNote(TaskRepository task)
        {
            var request = new DeleteItemRequest
            {
                TableName = _tableName,
                Key = new Dictionary<string, AttributeValue>()
                {
                    { "task", new AttributeValue {S = task.Task } },
                    {"UID", new AttributeValue{S = task.UID } }
                }
            };
            var response = await _amazonDB.DeleteItemAsync(request);
            return (response.HttpStatusCode == System.Net.HttpStatusCode.OK);
        }
        public async Task<List<Dictionary<string, AttributeValue>>> GetAllNotes(string id)
        {
            var request = new ScanRequest
            {
                TableName = _tableName
            };
            List<Dictionary<string, AttributeValue>> result = new();
            var response = await _amazonDB.ScanAsync(request);
            foreach(Dictionary<string, AttributeValue> d in response.Items)
            {
                if(d["UID"].S == id)
                {
                    result.Add(d);
                }
                
            }
            
            return result;
        }
        
        Task<List<TaskRepository>> ITaskClient.GetAllNotes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        Task ITaskClient.PostNote { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        Task ITaskClient.DeleteNote { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
