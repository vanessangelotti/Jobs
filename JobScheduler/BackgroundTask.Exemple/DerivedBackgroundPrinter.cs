using BackgroundTask.Exemple.Worker;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundTask.Exemple
{
    public class DerivedBackgroundPrinter : BackgroundService
    {
        private readonly IWorkerFirst _workerFirst;

        public DerivedBackgroundPrinter(IWorkerFirst workerFirst)
        {
            _workerFirst = workerFirst;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _workerFirst.DoWork(stoppingToken);
        }
    }
}
