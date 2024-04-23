using Microsoft.AspNetCore.Mvc;
using Service.Dto;
using Service.Interface;

namespace WeatherApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeoPlacesController : ControllerBase
    {
        private readonly IGeoPlaceService _service;

        public GeoPlacesController(IGeoPlaceService service)
        {
            _service = service;
        }

        [HttpGet("GetAllGeoPlaces")]
        public ActionResult<IEnumerable<GeoPlaceDto>> GetGeoPlaces()
        {
            return _service.GetAll().ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GeoPlaceDto>> GetGeoPlaceById(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var geoPlace = await _service.GetAsync(id);

            if (geoPlace == null)
            {
                return NotFound();
            }

            return geoPlace;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutGeoPlace(int id, GeoPlaceDto geoPlace)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            await _service.UpdateAsync(id, geoPlace);

            return NoContent();
        }

        [HttpPost("AddNewGeoPlace")]
        public async Task<ActionResult<GeoPlaceDto>> PostGeoPlace(GeoPlaceDto geoPlace)
        {
            geoPlace.Id = await _service.AddAsync(geoPlace);

            return geoPlace;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGeoPlace(int id)
        {
            var geoPlace = await _service.GetAsync(id);

            if (geoPlace == null)
            {
                return NotFound();
            }

            await _service.RemoveAsync(id);

            return NoContent();
        }
    }
}
