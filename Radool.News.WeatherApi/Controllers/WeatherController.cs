using Microsoft.AspNetCore.Mvc;
using radool.news.weatherapi.Services;
using radool.news.weatherapi.Domain;
using radool.news.weatherapi.Abstractions;
[ApiController]
[Route("api/[controller]")]
public class WeatherController : ControllerBase
{
    private readonly IServiceWeather _serviceWeather;

    public WeatherController(IServiceWeather serviceWeather)
    {
        _serviceWeather = serviceWeather;
    }

    [HttpGet("/Weather")] // Attributo HttpGet per gestire le richieste GET
    public async Task<IActionResult> GetWeather()
    {
        try
        {
            WeatherModel weatherData = await _serviceWeather.GetWeatherRealTime();
            return Ok(weatherData);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Errore durante la richiesta dei dati meteorologici: {ex.Message}");
        }
    }
}
