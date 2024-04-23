using Data.Interface;
using NSubstitute;

namespace ServiceUnitTests
{
    public class RepositoryMocks
    {
        public void GetGeoPlaceRepositoryMock()
        {
            var geoPlaceRepositoryMock = Substitute.For<IGeoPlaceRepository>();

        }
    }
}