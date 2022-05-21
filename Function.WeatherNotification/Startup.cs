using Azure.Data.Tables;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

[assembly: FunctionsStartup(typeof(Function.WeatherNotification.Startup))]
namespace Function.WeatherNotification
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddLogging();

            builder.Services.AddSingleton<TableClient>((serviceProvider) =>
            {
                string storageUri = serviceProvider.GetService<IConfiguration>()["StorageUri"];
                string tableName = serviceProvider.GetService<IConfiguration>()["StorageTableName"];
                string storageAccountName = serviceProvider.GetService<IConfiguration>()["StorageAccountName"];
                string storageAccountKey = serviceProvider.GetService<IConfiguration>()["StorageAccountKey"];

                return new TableClient(new Uri(storageUri), tableName,
                    new TableSharedKeyCredential(storageAccountName, storageAccountKey)
                    );
            });
        }
    }
}
