using Data.Model;

namespace Data.Interface
{
    public interface IWeatherForecastRepository : IBaseRepository<WeatherForecast>
    {
        IQueryable<WeatherForecast> GetAllForGeoPlace(int geoPlace);
    }
}
