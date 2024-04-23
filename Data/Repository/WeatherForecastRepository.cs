using Data.Interface;
using Data.Model;

namespace Data.Repository
{
    public class WeatherForecastRepository : BaseRepository<WeatherForecast>, IWeatherForecastRepository
    {
        public WeatherForecastRepository(WeatherContext weatherContext) 
            : base(weatherContext)
        {
        }

        public IQueryable<WeatherForecast> GetAllForGeoPlace(int geoPlace)
        {
            if (geoPlace <= 0)
            {
                return new List<WeatherForecast>().AsQueryable();
            }

            return weatherContext.WeatherForecasts
                .Where(w => w.GeoPlaceId == geoPlace)
                .AsQueryable();
        }
    }
}
