using Azure.Data.Tables;
using Function.WeatherNotification.Models;
using Function.WeatherNotification.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Function.WeatherNotification
{
    public class WeatherNotificationFunction
    {
        private readonly IWeatherNotificationService _weatherNotificationService;

        private readonly TableClient _tableClient;

        public WeatherNotificationFunction(IWeatherNotificationService weatherNotificationService,
            TableClient tableClient)
        {
            _weatherNotificationService = weatherNotificationService;

            _tableClient = tableClient;
        }

        [FunctionName("WeatherNotificationFunction")]
        public async Task Run([QueueTrigger("%QueueName%", Connection = "ConnectionString")] string myQueueItem,
            ILogger log)
        {
            log.LogInformation($"WeatherNotificationFunction started with payload: {myQueueItem}");

            try
            {
                ForecastRequestModel request = JsonSerializer.Deserialize<ForecastRequestModel>(myQueueItem,
                    new JsonSerializerOptions()
                    {
                        PropertyNameCaseInsensitive = true,
                    });

                await _weatherNotificationService.ProcessForecastRequest(request);

                log.LogInformation($"Notification sent to PhoneNumber: {request.NotificationPhoneNumber}");
            }
            catch (Exception ex)
            {
                string eMessage = ex.Message;

                log.LogError("An Exception occured while getting the weather forecast: {eMessage}", eMessage);

                TableEntity exceptionDetails = new();
                exceptionDetails.PartitionKey = "ExceptionDetails";
                exceptionDetails.RowKey = Guid.NewGuid().ToString();
                exceptionDetails.Add("ExceptionMesssage", eMessage);
                exceptionDetails.Add("QueueMessage", myQueueItem);

                await _tableClient.AddEntityAsync(exceptionDetails);
            }
        }
    }
}
