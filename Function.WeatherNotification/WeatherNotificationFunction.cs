using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Function.WeatherNotification
{
    public class WeatherNotificationFunction
    {
        [FunctionName("WeatherNotificationFunction")]
        public void Run([QueueTrigger("weather-notification-request-queue", Connection = "ConnectionString")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
