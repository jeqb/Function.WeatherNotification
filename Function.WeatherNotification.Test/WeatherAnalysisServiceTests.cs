using Function.WeatherNotification.Clients.Models;
using Function.WeatherNotification.Services;

namespace Function.WeatherNotification.Test
{
    public class WeatherAnalysisServiceTests
    {
        private readonly IEnumerable<DailyWeatherForecast> _testWeatherForecasts;

        public WeatherAnalysisServiceTests()
        {
            DateTime saturday = DateTime.Parse("5/21/2022 2:13:12 PM");

            _testWeatherForecasts = new List<DailyWeatherForecast>()
            {
                new DailyWeatherForecast()
                {
                    DateTime = saturday,
                    DayOfWeek = "Saturday",
                    MinimumTemperatureF = 75,
                    MaximumTemperatureF = 100
                },
                new DailyWeatherForecast()
                {
                    DateTime = saturday.AddDays(1),
                    DayOfWeek = "Sunday",
                    MinimumTemperatureF = 90,
                    MaximumTemperatureF = 115
                },
                new DailyWeatherForecast()
                {
                    DateTime = saturday.AddDays(2),
                    DayOfWeek = "Monday",
                    MinimumTemperatureF = 60,
                    MaximumTemperatureF = 90
                },
            };
        }

        [Fact]
        public async Task AnalyzeForecastAsync_GivenMaxvalue_ReturnsForecastsGreaterThanOrEqualToMaxValue()
        {
            // Arrange

            WeatherAnalysisService target = new();

            double maxTemp = 110;


            // Act

            IEnumerable<DailyWeatherForecast> result = await target.AnalyzeForecastAsync(null,
                                                                maxTemp, _testWeatherForecasts);

            IEnumerable<double> maximumTemps = result
                                                .Where(r => r.MaximumTemperatureF >= maxTemp)
                                                .Select(r => r.MaximumTemperatureF)
                                                .ToList();


            // Assert
            // should only have the 115 temp in it.
            Assert.True(maximumTemps.Count() == 1);
        }

        [Fact]
        public async Task AnalyzeForecastAsync_GivenMinValue_ReturnsForecastsLessThanOrEqualToMinValue()
        {
            // Arrange

            WeatherAnalysisService target = new();

            double minTemp = 75;

            // Act

            IEnumerable<DailyWeatherForecast> result = await target.AnalyzeForecastAsync(minTemp,
                                                                null, _testWeatherForecasts);

            IEnumerable<double> minimumTemps = result
                                                .Where(r => r.MinimumTemperatureF <= minTemp)
                                                .Select(r => r.MinimumTemperatureF)
                                                .ToList();


            // Assert

            Assert.True(minimumTemps.Count() == 2);
        }
    }
}
