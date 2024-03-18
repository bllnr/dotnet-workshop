using Microsoft.AspNetCore.Mvc;

namespace SampleApiCallApp.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

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

    // Example request: <LocalHostBaseUrl>/WeatherForecast/DailyForecast?date=2022-12-05
    [HttpGet()]
    [Route("DailyForecast")]
    public IEnumerable<WeatherForecast> GetDailyForecast(DateTime date)
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(date),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }

    [HttpGet()]
    [Route("DailyLocationForecast")]
    public IEnumerable<WeatherForeCastWithLocation> GetDailyForecastByLocation(DateTime date,
        string latitiude, string longitude)
    {
        //TODO: Implement logic 
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route("ExternalDailyForecast")]
    public IEnumerable<WeatherForecast> GetExternalDailyForecast(DateTime date, string latitiude)
    {
        //TODO: Implement a external api call to 
        // https://learn.microsoft.com/en-us/rest/api/maps/weather/get-daily-forecast?view=rest-maps-2023-06-01&tabs=HTTP
        // use this API as the actual api unless you have an Azure account: https://open-meteo.com/
        //TODO: return bad request if date is in the past
        throw new NotImplementedException();
    }
}