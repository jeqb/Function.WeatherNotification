using Function.WeatherNotification.Models;
using System.Threading.Tasks;

namespace Function.WeatherNotification.Services
{
    public interface IWeatherNotificationService
    {
        public Task ProcessForecastRequest(ForecastRequestModel forecastRequestModel);
    }
}
