using AutoMapper;
using Data.Interface;
using Data.Model;
using Service.Dto;
using Service.Interface;
using System.Linq.Expressions;

namespace Service
{
    public class WeatherForecastService : BaseService<WeatherForecast, WeatherForecastDto>, IWeatherForecastService
    {
        public WeatherForecastService(
            IMapper mapper,
            IWeatherForecastRepository weatherForecastRepository)
            : base(
                mapper, 
                weatherForecastRepository)
        {
        }

        public IEnumerable<WeatherForecastDto> GetAll(int? geoPlaceId)
        {
            var result = base.GetAll();

            if (geoPlaceId != null)
            {
                result = result
                    .Where(w => w.GeoPlaceId == geoPlaceId);
            }

            return result;
        }

        public WeatherForecastDto? GetByDateAndGeoPlaceId(DateTime time, int geoPlaceId)
        {
            Expression<Func<WeatherForecast, bool>> predicate = 
                w => w.GeoPlaceId == geoPlaceId && w.Time == time;

            var result = base.FirstOrDefault(predicate);

            return result;
        }

        public async Task<WeatherForecastDto?> GetByDateAndGeoPlaceIdAsync(DateTime time, int geoPlaceId)
        {
            Expression<Func<WeatherForecast, bool>> predicate =
                w => w.GeoPlaceId == geoPlaceId && w.Time == time;

            var result = await base.FirstOrDefaultAsync(predicate);

            return result;
        }
    }
}
