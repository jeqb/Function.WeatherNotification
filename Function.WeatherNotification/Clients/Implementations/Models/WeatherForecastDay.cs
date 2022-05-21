using System.Text.Json.Serialization;

namespace Function.WeatherNotification.Clients.Implementations.Models
{
    public class WeatherForecastDay
    {
        [JsonPropertyName("date_epoch")]
        public long DateEpoch { get; set; }

        [JsonPropertyName("day")]
        public Day Day { get; set; }
    }
}
