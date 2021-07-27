using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundTask.Exemple.Worker
{
    public class Worker : IWorker
    {
        private readonly ILogger<Worker> _logger;
        private int number = 0;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        public async Task DoWork(CancellationToken cancelationToken)
        {

            while (!cancelationToken.IsCancellationRequested)
            {
                Interlocked.Increment(ref number);
                _logger.LogInformation($"Worker number {number}");
                await Task.Delay(1000 * 5);
            }
        }

    }
}
