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

        private readonly IWeatherAnalysisService _weatherAnalysisService;

        private readonly ISmsPayloadCreator _smsPayloadCreator;

        public WeatherNotificationService(IWeatherForecastClient weatherForecastClient,
            IWeatherAnalysisService weatherAnalysisService, ISmsPayloadCreator smsPayloadCreator)
        {
            _weatherForecastClient = weatherForecastClient;

            _weatherAnalysisService = weatherAnalysisService;

            _smsPayloadCreator = smsPayloadCreator;
        }

        public async Task ProcessForecastRequest(ForecastRequestModel forecastRequestModel)
        {
            // TODO: Add validator class to validate ForecastRequestModel

            // request data points
            string notificationPhoneNumber = forecastRequestModel.NotificationPhoneNumber;

            string postalCode = forecastRequestModel.PostalCode;
            int daysOut = forecastRequestModel.DaysOut;

            double? minTemp = forecastRequestModel.MinimumTemperature;
            double? maxTemp = forecastRequestModel.MaximumTemperature;


            // get the forecast data 
            IEnumerable<DailyWeatherForecast> forecast = await _weatherForecastClient.GetWeatherForeCast(postalCode,
                                                                daysOut);


            // analyze the forecast given the inputs
            IEnumerable<DailyWeatherForecast> analysis = await _weatherAnalysisService.AnalyzeForecastAsync(minTemp,
                                                                maxTemp, forecast);


            // TODO: maybe store in a table what dates a phone number has been notified of already so 
            // it does not send notification about a date that's already been sent out.

            throw new NotImplementedException();
        }
    }
}
