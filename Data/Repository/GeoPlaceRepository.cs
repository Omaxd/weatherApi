using Data.Interface;
using Data.Model;

namespace Data.Repository
{
    public class GeoPlaceRepository : BaseRepository<GeoPlace>, IGeoPlaceRepository
    {
        public GeoPlaceRepository(WeatherContext weatherContext)
            : base(weatherContext)
        {
        }
    }
}
