using AutoMapper;
using Data;
using Data.Interface;
using Data.Repository;
using Service;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApi.Controllers;

namespace ControllerIntegrationTests.Controllers
{
    internal class WeatherForecastControllerTests
    {
        WeatherForecastsController _weatherForecastController = new WeatherForecastController();

        [SetUp]
        public void Setup()
        {
            // Data
            WeatherContext context = new WeatherContext();
            IWeatherForecastRepository weatherForecastRepository = new WeatherForecastRepository(context);
            IGeoPlaceRepository repository = new GeoPlaceRepository(context);

            // Service
            IMapper mapper = new WeatherProfile();
            IWeatherForecastService weatherForecastService = new WeatherForecastService();
            IGeoPlaceService geoPlaceService = new GeoPlaceService();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}
