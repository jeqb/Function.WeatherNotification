using Function.WeatherNotification.Clients.Implementations;

namespace Function.WeatherNotification.Test
{
    public class WeatherApiComClientTests
    {
        private readonly string _apiKey;

        private readonly HttpClient _httpClient;
        
        public WeatherApiComClientTests()
        {
            _apiKey = "";

            _httpClient = new();
        }

        [Fact]
        public async Task GetWeatherForeCast_ReturnsResponse_GivenZipcodeAndDays()
        {
            // Arrange

            WeatherApiComClient target = new(_httpClient, _apiKey);


            // Act

            var result = await target.GetWeatherForeCast("85308", 3);


            // Assert
        }
    }
}
