using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Service.Dto;
using Service.Interface;

namespace WeatherApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastsController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly IWeatherForecastService _weatherForecastService;
        private readonly IGeoPlaceService _geoPlaceService;

        public WeatherForecastsController(IWeatherForecastService weatherForecastService, IGeoPlaceService geoPlaceService)
        {
            _weatherForecastService = weatherForecastService;
            _geoPlaceService = geoPlaceService;
            _httpClient = new HttpClient();
        }

        [HttpGet("GetAllByGeoPlaceId")]
        public async Task<ActionResult<IEnumerable<WeatherForecastDto>>> GetWeatherForecasts(int? geoPlaceId)
        {
            return _weatherForecastService.GetAll(geoPlaceId).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WeatherForecastDto>> GetWeatherForecast(int id)
        {
            var weatherForecast = await _weatherForecastService.GetAsync(id);

            if (weatherForecast == null)
            {
                return NotFound();
            }

            return weatherForecast;
        }

        [HttpGet("GetNewest")]
        public async Task<ActionResult<WeatherForecastDto>> GetNewestWeatherForecast(int geoPlaceId)
        {
            if (geoPlaceId <= 0)
            {
                return NoContent();
            }

            var geoPlace = await _geoPlaceService.GetAsync(geoPlaceId);

            if (geoPlace == null)
            {
                return NotFound();
            }

            var requestUri = string.Format(
                "https://api.open-meteo.com/v1/forecast?latitude={0}&longitude={1}",
                geoPlace.Latitude,
                geoPlace.Longitude);

            requestUri += "&current=temperature_2m," +
                "relative_humidity_2m," +
                "apparent_temperature," +
                "rain," +
                "snowfall," +
                "cloud_cover," +
                "wind_speed_10m," +
                "wind_direction_10m";

            try
            {
                var httpResponse = await _httpClient.GetAsync(requestUri);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var response = await httpResponse.Content.ReadAsStringAsync();
                    var responseObject = JObject.Parse(response)["current"];
                    var weather = new WeatherForecastDto(responseObject, geoPlaceId);

                    // Check if exist in database
                    var existingWeather = await _weatherForecastService.GetByDateAndGeoPlaceIdAsync(
                        weather.Time,
                        geoPlaceId);

                    if (existingWeather == null)
                    {
                        weather.Id = await _weatherForecastService.AddAsync(weather);

                        return weather;
                    }
                    else
                    {
                        await _weatherForecastService.UpdateAsync(existingWeather.Id, weather);

                        return existingWeather;
                    }
                }
                else
                {
                    throw new Exception();
                }
                
            }
            catch (Exception)
            {
                return NoContent();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeatherForecast(int id)
        {
            var weatherForecast = await _weatherForecastService.GetAsync(id);

            if (weatherForecast == null)
            {
                return NotFound();
            }

            await _weatherForecastService.RemoveAsync(id);

            return NoContent();
        }
    }
}
