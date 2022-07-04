using Microsoft.AspNetCore.Mvc;
using ToDoListApi.Clients;
using ToDoListApi.Models.RandomFactModel;

namespace ToDoListApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RandomFactController : ControllerBase
    {
        private readonly ILogger<RandomFactController> _logger;
        private readonly RandomFactClient _client;
        public RandomFactController(ILogger<RandomFactController> logger, RandomFactClient client)
        {
            _logger = logger;
            _client = client;
        }
        [HttpGet("GetRandomFact")]
        public async Task<RandomFactRoot> GetRandomFact()
        {
            var fact = await _client.GetRandomFact();
            return fact;
        }
    }
}
