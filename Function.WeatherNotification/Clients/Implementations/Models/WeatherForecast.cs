using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Function.WeatherNotification.Clients.Implementations.Models
{
    public class WeatherForecast
    {
        [JsonPropertyName("forecastday")]
        public IEnumerable<WeatherForecastDay> ForecastDays { get; set; }
    }
}
