using Function.WeatherNotification.Clients.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Function.WeatherNotification.Services
{
    public interface IWeatherAnalysisService
    {
        public Task<IEnumerable<DailyWeatherForecast>> AnalyzeForecastAsync(double? minTemp, double? maxTemp,
            IEnumerable<DailyWeatherForecast> weatherForecasts);
    }
}
