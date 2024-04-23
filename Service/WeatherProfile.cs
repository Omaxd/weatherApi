using AutoMapper;
using Data.Model;
using Service.Dto;

namespace Service
{
    public class WeatherProfile : Profile
    {
        public WeatherProfile() 
        {
            // Data to DTO
            CreateMap<GeoPlace, GeoPlaceDto>();
            CreateMap<WeatherForecast, WeatherForecastDto>();

            // DTO to Data
            CreateMap<GeoPlaceDto, GeoPlace>();
            CreateMap<WeatherForecastDto, WeatherForecast>();
        }
    }
}
