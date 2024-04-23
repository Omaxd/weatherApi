using Data.Model;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Repository
{
    internal class WeatherForecastRepositoryTest
    {
        [Test]
        public void WeatherForecastRepositoryTest_AddNewGeoPlaceAsyncSuccessfully()
        {
            var dbContextMock = new WeatherContextMock();
            var weatherForecastRepository = new WeatherForecastRepository(dbContextMock);

            var expectedSum = dbContextMock.WeatherForecasts.Count() + 1;
            var expectedApparentTemperature = 5;
            var expectedTemperature = 6;
            var expectedWindSpeed = 0;
            var expectedWindDirection = 0;
            var expectedTime = new DateTime(2024, 1, 3);

            var newWeatherForecast = new WeatherForecast
            {
                ApparentTemperature = expectedApparentTemperature,
                Temperature = expectedTemperature,
                WindSpeed = expectedWindSpeed,
                WindDirection = expectedWindDirection,
                Time = expectedTime
            };

            weatherForecastRepository.Add(newWeatherForecast);

            Assert.AreEqual(expectedSum, dbContextMock.WeatherForecasts.Count());
            Assert.AreEqual(expectedApparentTemperature, dbContextMock.WeatherForecasts.Last().ApparentTemperature);
            Assert.AreEqual(expectedTemperature, dbContextMock.WeatherForecasts.Last().Temperature);
            Assert.AreEqual(expectedWindSpeed, dbContextMock.WeatherForecasts.Last().WindSpeed);
            Assert.AreEqual(expectedWindDirection, dbContextMock.WeatherForecasts.Last().WindDirection);
            Assert.AreEqual(expectedTime, dbContextMock.WeatherForecasts.Last().Time);
        }

        [Test]
        public void WeatherForecastRepositoryTest_RemoveWeatherForecast()
        {
            var dbContextMock = new WeatherContextMock();
            var weatherForecastRepository = new WeatherForecastRepository(dbContextMock);

            var expectedSum = dbContextMock.WeatherForecasts.Count() - 1;

            weatherForecastRepository.RemoveAsync(1);

            Assert.AreEqual(expectedSum, dbContextMock.WeatherForecasts.Count());
        }
    }
}
