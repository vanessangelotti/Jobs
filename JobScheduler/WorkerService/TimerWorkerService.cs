using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WorkerService
{
    internal sealed class TimerWorkerService : IHostedService, IDisposable
    {
        private readonly ILogger<TimerWorkerService> _logger;
        private Timer _timer;
        public TimerWorkerService(ILogger<TimerWorkerService> logger)
        {
            _logger = logger;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("StartAsync sendo executado");

            _timer = new Timer(OnTimer, cancellationToken, TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(5));
            return Task.CompletedTask;

        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("StopAsync sendo executado");
            _timer.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;

        }

        private void OnTimer(object state)
        {
            _logger.LogInformation("OnTimer sendo executado");
        }

        public void Dispose()
        {
            _logger.LogInformation("Dispose sendo executado");
            _timer?.Dispose();
        }
    }
}
