using Microsoft.AspNetCore.Mvc;

namespace HealthCheckAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        /// <summary>
        /// Sets up logging.
        /// </summary>
        /// <param name="logger">Ilogger</param>
        /// <param name="configuration">IConfiguration</param>
        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IConfiguration configuration)
        {
            _logger = logger;
            var defaultLogLevel = configuration["Logging:LogLevel:Default"];
        }

        /// <summary>
        /// Gets the weather forecast based on dummy data.
        /// </summary>
        /// <returns>IEnumerable of WeatherForecast containing Date, TemperatureC, Summary</returns>
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}