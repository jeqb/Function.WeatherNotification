using System;

namespace Function.WeatherNotification.Clients.Models
{
    public class DailyWeatherForecast
    {
        public DateTimeOffset DateTime { get; set; }

        public string DayOfWeek { get; set; }

        public double MinimumTemperatureF { get; set; }

        public double MaximumTemperatureF { get; set; }
    }
}
