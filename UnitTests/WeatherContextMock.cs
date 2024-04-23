using Data;
using Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Windows.Markup;

namespace UnitTests
{
    public class WeatherContextMock : WeatherContext
    {
        public WeatherContextMock() 
            : base(new DbContextOptionsBuilder<WeatherContext>()
                .UseInMemoryDatabase(databaseName: "localTest")
                .Options)
        {
            FillGeoPlaces();
            FillWeatherForecasts();
        }

        public void FillGeoPlaces()
        {
            GeoPlaces.Add(new GeoPlace
            {
                Name = "Test1",
                Longitude = 10,
                Latitude = 10
            });

            GeoPlaces.Add(new GeoPlace
            {
                Name = "Test2",
                Longitude = 5,
                Latitude = 5
            });

            base.SaveChanges();
        }

        public void FillWeatherForecasts()
        {
            WeatherForecasts.Add(new WeatherForecast
            {
                GeoPlaceId = 1,
                ApparentTemperature = 12,
                Temperature = 15,
                WindSpeed = 2,
                WindDirection = 3,
                Time = new DateTime(2024, 1, 1)
            });

            WeatherForecasts.Add(new WeatherForecast
            {
                GeoPlaceId = 2,
                ApparentTemperature = 15,
                Temperature = 14,
                WindSpeed = 0,
                WindDirection = 0,
                Time = new DateTime(2024, 1, 2)
            });

            base.SaveChanges();
        }
    }
}
