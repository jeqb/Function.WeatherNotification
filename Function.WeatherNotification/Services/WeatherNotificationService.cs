using Function.WeatherNotification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Function.WeatherNotification.Services
{
    public class WeatherNotificationService : IWeatherNotificationService
    {
        public WeatherNotificationService()
        {

        }

        public async Task ProcessForecastRequest(ForecaseRequestModel forecaseRequestModel)
        {
            throw new NotImplementedException();
        }
    }
}
