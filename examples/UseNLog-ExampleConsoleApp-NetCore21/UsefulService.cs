using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace UseNLogExample
{
    class UsefulService : IHostedService, IDisposable
    {
        private ILogger _logger;
        private Timer _timer;

        public UsefulService(ILogger<UsefulService> logger)
        {
            _logger = logger;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Here's me loggining in the init");
            _timer = new Timer(DoAThing, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

        private void DoAThing(object state)
        {
            _logger.LogInformation("Logging from the worker");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Here's me stopping");
            _timer.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}