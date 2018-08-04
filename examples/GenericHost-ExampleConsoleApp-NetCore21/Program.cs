using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GenericHostExample
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = new HostBuilder()
                // Configure Host level settings here
                .ConfigureHostConfiguration(configHost =>
                {
                    // Do nifty things here like set the BasePath, etc.
                    // You can also read in json settings, environment variables, and/or command line args.
                    // Duplicate settings are overriden in the order configured.
                    // Can be called multiple times
                })
                // Configure App level settings here
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    // Much like before, here you can configure app level settings
                    // Can also be called multiple times
                    config.AddJsonFile("appsettings.json", true);
                    config.AddEnvironmentVariables();

                    if (args != null) config.AddCommandLine(args);
                })
                // Now configure the services for this continer (via Dependency Injection)
                .ConfigureServices((hostContext, services) =>
                {
                    // This can be called multiple times

                    // Enabling options support for all services
                    services.AddOptions();

                    // This performs a binding of a particular config file section to a Model class
                    // and adds it to the IOptions chain, so you can read it from within the service
                    services.Configure<MyServiceConfigSection>(
                        hostContext.Configuration.GetSection("MyServiceConfigSection"));

                    // If service implements IHostedService use this:
                    services.AddHostedService<MyService>();

                    // Alternatively, use AddSingleton, specifying the service type and the implementation
                    //services.AddSingleton<IHostedService, MyService>();
                })
                // Finally configure the ILoggingBuilder in a global way
                .ConfigureLogging((hostingContext, logging) =>
                {
                    // Configuring inside this delegate should apply consistent logging options for the whole application
                    // since it does it through the ILoggingBuilder interface. But if you configure Another ILogger as a service
                    // in the section above, these settings may not be honored.
                    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    logging.AddConsole();
                });

            // Normally, you'd call .build() on the builder, but I'll use a helper that implies it
            // var host = builder.Build();

            // Generically you'd call await host.RunAsync() at this point, essentially executing your actual main thread
            // But since we want a console, this helper enables the support, builds the host, and runs it.
            // Added bonus: Also supports Ctrl-C aka SIGTERM for the win.
            await builder.RunConsoleAsync();

            // uncomment if you want to pause after .StopAsync() is called on the host
            // press any key to quit
#if DEBUG
            Console.ReadKey();
#else
//Console.ReadKey();
#endif
        }
    }
}