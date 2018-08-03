using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace NLogExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Star a new ServiceCollection
            var serviceCollection = new ServiceCollection();
            
            // Enable logging services for the collection
            serviceCollection.AddLogging();

            //  Turn it into a service provider
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Using the concrete service provider, get the the LoggerFactory
            var loggerFactory = serviceProvider.GetService<ILoggerFactory>();

            // Use NLog's extention method to register NLog as a new logger for the service provider 
            loggerFactory.AddNLog();

            // Access NLog's static configuration and configure it using the usual xml file
            NLog.LogManager.LoadConfiguration("NLog.config");

            // Now that Nlog is registered and configured, get the service provider's Logging Interface
            var logger = serviceProvider.GetService<ILogger<Program>>();

            // Finally, log to your heart's content.
            logger.LogInformation("Look! a log message");

            Console.ReadKey();
        }
    }
}
