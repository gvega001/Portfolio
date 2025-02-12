using System.Text.Json.Serialization;

namespace Portfolio.Web
{
    public class OpenMeteoResponse
    {
        [JsonPropertyName("latitude")]
        public double? Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double? Longitude { get; set; }

        [JsonPropertyName("hourly")]
        public HourlyData? Hourly { get; set; }
    }

    public class HourlyData
    {
        [JsonPropertyName("time")]
        public List<string>? Time { get; set; }

        [JsonPropertyName("temperature_2m")]
        public List<double>? Temperature2m { get; set; }
    }
}
