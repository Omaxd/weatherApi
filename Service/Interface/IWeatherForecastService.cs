using Data.Model;
using Service.Dto;

namespace Service.Interface
{
    public interface IWeatherForecastService : IBaseService<WeatherForecast, WeatherForecastDto>
    {
        IEnumerable<WeatherForecastDto> GetAll(int? geoPlaceId);
        WeatherForecastDto? GetByDateAndGeoPlaceId(DateTime time, int geoPlaceId);
        Task<WeatherForecastDto?> GetByDateAndGeoPlaceIdAsync(DateTime time, int geoPlaceId);
    }
}
