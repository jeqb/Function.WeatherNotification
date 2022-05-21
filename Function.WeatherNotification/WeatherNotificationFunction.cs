using Azure.Data.Tables;
using Function.WeatherNotification.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Function.WeatherNotification
{
    public class WeatherNotificationFunction
    {
        private readonly TableClient _tableClient;

        public WeatherNotificationFunction(TableClient tableClient)
        {
            _tableClient = tableClient;
        }

        [FunctionName("WeatherNotificationFunction")]
        public async Task Run([QueueTrigger("weather-notification-request-queue", Connection = "ConnectionString")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"WeatherNotificationFunction started with payload: {myQueueItem}");

            try
            {
                ForecaseRequestModel request = JsonSerializer.Deserialize<ForecaseRequestModel>(myQueueItem,
                    new JsonSerializerOptions()
                    {
                        PropertyNameCaseInsensitive = true,
                    });

                // TODO: STUFF GOES HERE

                // TODO: LOG THAT STUFF HAPPENED
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
