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
        //Gerenciamento do Job através do BackgroundService, onde será executado pelo método ExecuteAsync
        private readonly IWorker _workerFirst;

        public DerivedBackgroundPrinter(IWorker workerFirst)
        {
            _workerFirst = workerFirst;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _workerFirst.DoWork(stoppingToken);
        }
    }
}
