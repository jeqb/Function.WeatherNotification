using Function.WeatherNotification.Clients.Interfaces;
using Function.WeatherNotification.Models;
using System;
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

        public async Task ProcessForecastRequest(ForecaseRequestModel forecaseRequestModel)
        {
            throw new NotImplementedException();
        }
    }
}
