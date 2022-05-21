using Function.WeatherNotification.Clients.Models;
using Function.WeatherNotification.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Function.WeatherNotification.Services
{
    public interface ISmsPayloadCreator
    {
        public Task<SmsModel> CreatePayloadFromForecasts(IEnumerable<DailyWeatherForecast> weatherForecasts);
    }
}
