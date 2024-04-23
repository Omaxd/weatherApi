using Newtonsoft.Json.Linq;

namespace Service.Dto
{
    public class WeatherForecastDto
    {
        public int Id { get; set; }
        public int GeoPlaceId { get; set; }

        public DateTime Time { get; set; }
        public float Temperature { get; set; }
        public float ApparentTemperature { get; set; }
        public float Humidity { get; set; }
        public float CloudCover { get; set; }
        public float WindSpeed { get; set; }
        public float WindDirection { get; set; }
        public float Rain { get; set; }
        public float Snow { get; set; }

        public WeatherForecastDto() { }

        public WeatherForecastDto(JToken token, int geoPlaceId)
        {
            GeoPlaceId = geoPlaceId;
            Time = token["time"].Value<DateTime>();
            Temperature = token["temperature_2m"].Value<float>();
            ApparentTemperature = token["apparent_temperature"].Value<float>();
            Rain = token["rain"].Value<float>();
            Snow = token["snowfall"].Value<float>();
            WindSpeed = token["wind_speed_10m"].Value<float>();
            WindDirection = token["wind_direction_10m"].Value<float>();
            CloudCover = token["cloud_cover"].Value<float>();
            Humidity = token["relative_humidity_2m"].Value<float>();
        }
    }
}
