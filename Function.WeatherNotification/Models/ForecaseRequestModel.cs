namespace Function.WeatherNotification.Models
{
    public class ForecastRequestModel
    {
        public string PostalCode { get; set; } = string.Empty;

        public string NotificationPhoneNumber { get; set; } = string.Empty;

        // in Fahrenheit
        public double? MinimumTemperature { get; set; }

        // in Fahrenheit
        public double? MaximumTemperature { get; set; }

        public int DaysOut { get; set; }
    }
}
