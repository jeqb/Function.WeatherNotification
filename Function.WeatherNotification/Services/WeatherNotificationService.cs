using Function.WeatherNotification.Clients.Interfaces;
using Function.WeatherNotification.Clients.Models;
using Function.WeatherNotification.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Function.WeatherNotification.Services
{
    public class WeatherNotificationService : IWeatherNotificationService
    {
        private readonly IWeatherForecastClient _weatherForecastClient;

        public WeatherNotificationService(IWeatherForecastClient weatherForecastClient)
        {
            _weatherForecastClient = weatherForecastClient;
        }

        public async Task ProcessForecastRequest(ForecastRequestModel forecastRequestModel)
        {
            string postalCode = forecastRequestModel.PostalCode;
            int daysOut = forecastRequestModel.DaysOut;
            string notificationPhoneNumber = forecastRequestModel.NotificationPhoneNumber;

            double? minTemp = forecastRequestModel.MinimumTemperature;
            double? maxTemp = forecastRequestModel.MaximumTemperature;

            IEnumerable<DailyWeatherForecast> corecast = await _weatherForecastClient.GetWeatherForeCast(postalCode,
                daysOut);

            // TODO: maybe store in a table what dates a phone number has been notified of already so 
            // it does not send notification about a date that's already been sent out.

            throw new NotImplementedException();
        }
    }
}
