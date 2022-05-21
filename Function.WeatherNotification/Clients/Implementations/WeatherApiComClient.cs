using Function.WeatherNotification.Clients.Exceptions;
using Function.WeatherNotification.Clients.Implementations.Models;
using Function.WeatherNotification.Clients.Interfaces;
using Function.WeatherNotification.Clients.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace Function.WeatherNotification.Clients.Implementations
{
    /// <summary>
    /// Client for talking to the api of weatherapi.com
    /// </summary>
    public class WeatherApiComClient : IWeatherForecastClient
    {
        private const string _baseUrl = "https://api.weatherapi.com/v1";

        private readonly string _apiKey;

        private readonly HttpClient _httpClient;

        public WeatherApiComClient(HttpClient httpClient, string apiKey)
        {
            _httpClient = httpClient;
            
            _apiKey = apiKey;
        }

        /// <summary>
        /// reach out to the endpoint: http://api.weatherapi.com/v1/forecast.json and get the
        /// forcast from it using the zipcode and daysout.
        /// </summary>
        /// <param name="zipCode">Zipcode to get a forecast for.</param>
        /// <param name="daysOut">How many days to forecast.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<IEnumerable<DailyWeatherForecast>> GetWeatherForeCast(string zipCode, int daysOut)
        {
            List<DailyWeatherForecast> result = new();

            // put the resource onto the base url
            StringBuilder sb = new();
            sb.Append(_baseUrl);
            sb.Append("/forecast.json");
            string url = sb.ToString();

            // make the url and put the query parameters on it.
            UriBuilder uriBuilder = new(url);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["q"] = zipCode;
            query["days"] = daysOut.ToString();

            // create the final url string
            uriBuilder.Query = query.ToString();
            string finalUrl = uriBuilder.ToString();

            HttpRequestMessage requestPayload = new();
            requestPayload.RequestUri = new Uri(finalUrl);
            requestPayload.Method = HttpMethod.Get;
            requestPayload.Headers.Add("key", _apiKey);


            HttpResponseMessage httpResponse = await _httpClient.SendAsync(requestPayload);

            // hopefully we get a success
            if (httpResponse.IsSuccessStatusCode)
            {
                string jsonString = await httpResponse.Content.ReadAsStringAsync();

                WeatherForecastResponseBody responseBody =
                    JsonSerializer.Deserialize<WeatherForecastResponseBody>(jsonString);

                IEnumerable<WeatherForecastDay> weatherForecastDays = responseBody.Forecast.ForecastDays;

                // go through each forcasted day, and convert it into the target model.
                foreach(WeatherForecastDay day in weatherForecastDays)
                {
                    long epochSeconds = day.DateEpoch;

                    DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(epochSeconds);

                    DailyWeatherForecast addMe = new()
                    {
                        DateTime = dateTimeOffset.DateTime,
                        DayOfWeek = dateTimeOffset.DayOfWeek.ToString(),
                        MinimumTemperatureF = day.Day.MinTempF,
                        MaximumTemperatureF = day.Day.MaxTempF
                    };

                    result.Add(addMe);
                }

                return result;
            }
            else
            {
                string message = await httpResponse.Content.ReadAsStringAsync();

                throw new ClientHttpException(httpResponse.StatusCode, message);
            }
        }
    }
}
