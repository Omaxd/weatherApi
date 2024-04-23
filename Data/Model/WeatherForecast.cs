namespace Data.Model
{
    public class WeatherForecast
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

        public GeoPlace GeoPlace { get; set; }
    }
}
