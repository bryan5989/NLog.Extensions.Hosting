using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;

namespace GenericHostExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // If you wish to log container set up events, you must create an extra logger instance
            // before configuring the host and containers
            var logger = LogManager.LoadConfiguration("NLog.config").GetCurrentClassLogger();

            var host = new HostBuilder();
            host.ConfigureServices(services =>
            {
                services.AddSingleton(new LoggerFactory().AddNLog());

                // If you didn't load the nlog configuration above, you may want to do so now
                //LogManager.LoadConfiguration("NLog.config");

                services.AddHostedService<UsefulService>();
            });

            await host.RunConsoleAsync();

            Console.ReadKey();
        }
    }
}
