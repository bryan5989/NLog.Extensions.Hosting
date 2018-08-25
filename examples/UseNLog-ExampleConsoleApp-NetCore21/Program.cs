using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;
using NLog.Extensions.Hosting;
using NLog.Extensions.Hosting.Examples;

namespace UseNLogExample
{
    internal static class Program
    {
        private static async Task Main()
        {
            // To log messages during host setup
            var setupLogger = LogManager.LoadConfiguration("NLog.config").GetCurrentClassLogger();

            setupLogger.Trace("Loggining has Started...");

            var hostBuilder = new HostBuilder();

            hostBuilder
                .ConfigureServices(services => { services.AddHostedService<UsefulService>(); })
                .UseNLog();

            await hostBuilder.RunConsoleAsync();

            Console.ReadKey();
        }
    }
}