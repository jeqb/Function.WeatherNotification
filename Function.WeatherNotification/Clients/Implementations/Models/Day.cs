using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Function.WeatherNotification.Clients.Implementations.Models
{
    public class Day
    {
        [JsonPropertyName("mintemp_f")]
        public double MinTempF { get; set; }

        [JsonPropertyName("maxtemp_f")]
        public double MaxTempF { get; set; }

        /// <summary>
        /// "condition": {
        ///     "text": "Sunny",
        ///     "icon": "//cdn.weatherapi.com/weather/64x6/day/113.png",
        ///     "code": 1000
        /// }
        /// </summary>
        [JsonPropertyName("condition")]
        public Dictionary<string, object> Condition { get; set; }
    }
}
