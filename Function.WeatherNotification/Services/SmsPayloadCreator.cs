using Function.WeatherNotification.Clients.Models;
using Function.WeatherNotification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Function.WeatherNotification.Services
{
    public class SmsPayloadCreator : ISmsPayloadCreator
    {
        public async Task<SmsModel> CreatePayloadFromForecasts(IEnumerable<DailyWeatherForecast> weatherForecasts)
        {
            throw new NotImplementedException();
        }
    }
}
