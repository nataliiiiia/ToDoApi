using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Microsoft.AspNetCore.Mvc;
using ToDoListApi.Clients;
using ToDoListApi.Models.DBModel;
using ToDoListApi.Constants;
namespace ToDoListApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DBController : ControllerBase
    {
        public TaskClient _client { get; set; }
        private readonly ILogger<DBController> _logger;
        public DBInfoClient _dBInfoClient { get; set; }
        
        public DBController(ILogger<DBController> logger, TaskClient client, DBInfoClient dBInfoClient)
        {
            _logger = logger;
            _client = client;
            _dBInfoClient = dBInfoClient;

        }
        [HttpPost("PostTask")]
        public async Task<ActionResult> PostNote([FromBody] TaskRepository todo)
        {
            var data = new TaskRepository
            {
                UID = todo.UID,
                Task = todo.Task,
            };
            var result = await _client.PostNote(data);
            if (result == false)
            {
                return BadRequest("Something went wrong");
            }
            return Ok();
        }
        [HttpDelete("DeleteTask")]
        public async Task<ActionResult> DeleteNote([FromBody] TaskRepository todo)
        {
            var data = new TaskRepository
            {
                UID = todo.UID,
                Task = todo.Task,
            };
            var result = await _client.DeleteNote(data);
            if (result == false)
            {
                return BadRequest("Something went wrong") ;
            }
            return Ok();
        }
        [HttpGet("GetAllTasks")]
        public async Task<List<Dictionary<string, AttributeValue>>> GetNotes(string id)
        {
            
            var result = await _client.GetAllNotes(id);
            
            return result;

        }
        [HttpPost("PostInfo")]
        public async Task<ActionResult> PostInfo([FromBody] InfoModel infoModel)
        {
            var data = new InfoModel
            {
                UID = infoModel.UID,
                City = infoModel.City,
                Country = infoModel.Country,
            };
            var result = await _dBInfoClient.PostInfo(data);
            if (result == false)
            {
                return BadRequest("Something went wrong");
            }
            return Ok();
        }

        [HttpGet("GetInfo")]
        public async Task<InfoModel> GetInfo(string id)
        {
            var result = await _dBInfoClient.GetInfo(id);
            return result;
        }
        [HttpDelete("DeleteInfo")]
        public async Task<ActionResult> DeleteInfo([FromBody] InfoModel infoModel)
        {
            var data = new InfoModel
            {
                UID = infoModel.UID
            };
            var result = await _dBInfoClient.DeleteInfo(data);
            if (result == false)
            {
                return BadRequest("Something went wrong");
            }
            return Ok();
        }




    }
}

    


