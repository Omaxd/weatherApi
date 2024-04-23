using Data.Model;
using Data.Repository;

namespace UnitTests.Repository
{
    internal class GeoPlaceRepositoryTest
    {
        [Test]
        public void GeoPlaceRepositoryTest_AddNewGeoPlaceSuccessfully()
        {
            var dbContextMock = new WeatherContextMock();
            var geoPlaceRepository = new GeoPlaceRepository(dbContextMock);

            var expectedSum = 3;
            var expectedName = "test3";
            var expectedLongitude = 1;
            var expectedLatitude = 2;

            var newGeoPlace = new GeoPlace()
            {
                Name = expectedName,
                Longitude = expectedLongitude,
                Latitude = expectedLatitude
            };

            geoPlaceRepository.Add(newGeoPlace);

            Assert.AreEqual(expectedSum, dbContextMock.GeoPlaces.Count());
            Assert.AreEqual(expectedName, dbContextMock.GeoPlaces.Last().Name);
            Assert.AreEqual(expectedLongitude, dbContextMock.GeoPlaces.Last().Longitude);
            Assert.AreEqual(expectedLatitude, dbContextMock.GeoPlaces.Last().Latitude);

            dbContextMock.Database.EnsureDeleted();
        }

        [Test]
        public void GeoPlaceRepositoryTest_GetGeoPlaces()
        {
            var dbContextMock = new WeatherContextMock();
            var geoPlaceRepository = new GeoPlaceRepository(dbContextMock);

            var expectedSum = 2;

            var currentCount = geoPlaceRepository.GetAll().Count();

            Assert.AreEqual(expectedSum, currentCount);

            dbContextMock.Database.EnsureDeleted();
        }

        [Test]
        public async Task GeoPlaceRepositoryTest_RemoveGeoPlaceAsync()
        {
            var dbContextMock = new WeatherContextMock();
            var geoPlaceRepository = new GeoPlaceRepository(dbContextMock);

            var expectedSum = 1;
            var expectedId = 2;

            await geoPlaceRepository.RemoveAsync(1);

            Assert.AreEqual(expectedSum, dbContextMock.GeoPlaces.Count());
            Assert.AreEqual(expectedId, dbContextMock.GeoPlaces.First().Id);

            dbContextMock.Database.EnsureDeleted();
        }
    }
}
