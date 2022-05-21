using Function.WeatherNotification.Clients.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Function.WeatherNotification.Clients.Interfaces
{
    /// <summary>
    /// Client to reach out to external systems to retrieve weather forecast.
    /// </summary>
    public interface IWeatherForecastClient
    {
        /// <summary>
        /// Given a zipcode, and an integer, get the weather forecast
        /// </summary>
        /// <param name="zipCode">US zipcode of where to get the forecast</param>
        /// <param name="daysOut">how many days into the future you want to forecast</param>
        /// <returns>Weather Forecast for each day in the daysOut</returns>
        public Task<IEnumerable<DailyWeatherForecast>> GetWeatherForeCast(string zipCode, int daysOut);
    }
}
