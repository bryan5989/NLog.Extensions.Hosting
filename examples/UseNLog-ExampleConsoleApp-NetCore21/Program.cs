using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;
using NLog.Extensions.Hosting;
using NLog.Extensions.Hosting.Examples;

namespace UseNLogExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // To log messages during host setup
            var setupLogger = LogManager.LoadConfiguration("NLog.config").GetCurrentClassLogger();

            var hostBuilder = new HostBuilder();

            hostBuilder
                .ConfigureServices(services => { services.AddHostedService<UsefulService>(); })
                .UseNLog();

            await hostBuilder.RunConsoleAsync();

            Console.ReadKey();
        }
    }
}
