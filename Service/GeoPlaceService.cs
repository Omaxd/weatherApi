using AutoMapper;
using Data.Interface;
using Data.Model;
using Service.Dto;
using Service.Interface;

namespace Service
{
    public class GeoPlaceService : BaseService<GeoPlace, GeoPlaceDto>, IGeoPlaceService
    {
        private readonly IWeatherForecastRepository _weatherForecastRepository;

        public GeoPlaceService(IMapper mapper,
            IGeoPlaceRepository geoPlaceRepository,
            IWeatherForecastRepository weatherForecastRepository)
            : base(mapper, geoPlaceRepository)
        {
            _weatherForecastRepository = weatherForecastRepository;
        }

        public override void Remove(int id)
        {
            // Remove weathers
            var connectedWeathers = _weatherForecastRepository
                .GetAllForGeoPlace(id);

            foreach (var connectedWeather in connectedWeathers)
            {
                _weatherForecastRepository.Remove(connectedWeather.Id);
            }

            // remove place
            base.Remove(id);
        }

        public override async Task RemoveAsync(int id)
        {
            // Remove weathers
            var connectedWeathers = _weatherForecastRepository
                .GetAllForGeoPlace(id);

            foreach (var connectedWeather in connectedWeathers)
            {
                await _weatherForecastRepository.RemoveAsync(connectedWeather.Id);
            }

            // remove place
            await base.RemoveAsync(id);
        }
    }
}
