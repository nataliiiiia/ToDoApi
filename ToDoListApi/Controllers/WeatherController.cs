using Microsoft.AspNetCore.Mvc;
using ToDoListApi.Models.WeatherModel;
using ToDoListApi.Clients;

namespace ToDoListApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly ILogger<WeatherController> _logger;
        private readonly WeatherClient _client;
        public WeatherController(ILogger<WeatherController> logger, WeatherClient client)
        {
            _logger = logger;
            _client = client;
        }
        [HttpGet("GetWeather")]
        public async Task<WeatherRoot> GetWeatherByCity(string city)
        {
            var weather = await _client.GetWeatherByCity(city);
            return weather;
        }
        
        
    }
}
