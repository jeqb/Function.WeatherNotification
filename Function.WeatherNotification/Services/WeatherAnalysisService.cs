using Function.WeatherNotification.Clients.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Function.WeatherNotification.Services
{
    /// <summary>
    /// Given the parameters of the original request, look at the weather forecast data, and determine if
    /// any of the days in the forecast are something the requester wants to know about.
    /// </summary>
    public class WeatherAnalysisService : IWeatherAnalysisService
    {
        /// <summary>
        /// Analyze the weather forecast
        /// </summary>
        /// <param name="minTemp">If the forecast is less than or equal to this number, let me know!</param>
        /// <param name="maxTemp">If the forecast is greater than or equal to this number, let me know!</param>
        /// <param name="weatherForecasts"></param>
        /// <returns></returns>
        public async Task<IEnumerable<DailyWeatherForecast>> AnalyzeForecastAsync(double? minTemp, double? maxTemp,
            IEnumerable<DailyWeatherForecast> weatherForecasts)
        {
            List<DailyWeatherForecast> result = new();

            // if either is null, set them to their min and max values so the if statements
            // in the forloop will pass over them.
            minTemp ??= double.MinValue;
            maxTemp ??= double.MaxValue;

            foreach (DailyWeatherForecast forecast in weatherForecasts)
            {
                DailyWeatherForecast? possibleResult = null;

                // does it trigger the minimum threshold?
                if (forecast.MinimumTemperatureF <= minTemp)
                {
                    possibleResult ??= new();
                    possibleResult.DateTime = forecast.DateTime;
                    possibleResult.DayOfWeek = forecast.DayOfWeek;
                    possibleResult.MinimumTemperatureF = forecast.MinimumTemperatureF;
                }

                // does it trigger the maximum threshold?
                if (forecast.MaximumTemperatureF >= maxTemp)
                {
                    possibleResult ??= new();
                    possibleResult.DateTime = forecast.DateTime;
                    possibleResult.DayOfWeek = forecast.DayOfWeek;
                    possibleResult.MaximumTemperatureF = forecast.MaximumTemperatureF;
                }

                // if it did, add it to the results!
                if (possibleResult != null)
                {
                    result.Add(possibleResult);
                }
            }

            return await Task.FromResult(result);
        }
    }
}
