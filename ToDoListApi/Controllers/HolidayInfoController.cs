using Microsoft.AspNetCore.Mvc;
using ToDoListApi.Models.Holiday;
using ToDoListApi.Clients;

namespace ToDoListApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HolidayInfoController : ControllerBase
    {
        private readonly ILogger<HolidayInfoController> _logger;
        private readonly HolidayClient _client;
        public HolidayInfoController(ILogger<HolidayInfoController> logger, HolidayClient client)
        {
            _logger = logger;
            _client = client;
        }
        [HttpGet("GetHolidayInfo")]
        public async Task<HolidayRoot> GetHolidayByTheDate(string country, string year, string month, string day)
        {
            var holiday = await _client.GetHolidayByDate(country, year, month, day);
            return holiday;
        }
    }
}
