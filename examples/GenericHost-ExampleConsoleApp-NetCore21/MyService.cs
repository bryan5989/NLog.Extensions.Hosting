using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace GenericHostExample
{
    internal class MyService : IHostedService, IDisposable
    {
        private readonly ILogger<MyService> _logger;
        // ReSharper disable once NotAccessedField.Local
        private readonly IOptions<MyServiceConfigSection> _serviceOptions;
        // ReSharper disable once NotAccessedField.Local
        private readonly string _someSettingFromConfig;
        private Timer _timer;

        public MyService(ILogger<MyService> logger, IOptions<MyServiceConfigSection> serviceOptions)
        {
            // Set up service with non-throwing methods
            _logger = logger;
            _serviceOptions = serviceOptions;
            _someSettingFromConfig = serviceOptions.Value.SomeSetting;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            // Finish setting up the service if not completed in the constructor
            // Also call throwable methods from here (try-catch)
            _logger.LogInformation($"{nameof(MyService)} is starting...");

            // finally, call the main method asynchronously or use a timer or similar
            _timer = new Timer(AsyncProcess, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

            // return a "completed" Task
            // In this context, completed means that the process has completed startup...
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            // This method is called by the host
            // Insert any necessary cleanup for graceful close
            _logger.LogInformation($"{nameof(MyService)} is stopping...");
            _timer?.Change(Timeout.Infinite, 0);

            // Like StartAsync counterpart, return a completed task, indicating service has stopped
            return Task.CompletedTask;
        }

        private void AsyncProcess(object state)
        {
            // Do some work here
            _logger.LogInformation("Doing some work asynchronously...");
        }
    }
}