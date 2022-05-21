using System.Text.Json.Serialization;

namespace Function.WeatherNotification.Clients.Implementations.Models
{
    public class WeatherForecastResponseBody
    {
        [JsonPropertyName("forecast")]
        public WeatherForecast Forecast { get; set; }
    }
}
