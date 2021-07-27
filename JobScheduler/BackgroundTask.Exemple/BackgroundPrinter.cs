using BackgroundTask.Exemple.Worker;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundTask.Exemple
{
    public class BackgroundPrinter: IHostedService
    {
        //Gerenciamento do Job, onde será executado pelos métodos Start and StopAsync
        private ILogger<BackgroundPrinter> _logger;
        private readonly IWorker _workerFist;

        public BackgroundPrinter(ILogger<BackgroundPrinter> logger, IWorker workerFist)
        {
            this._logger = logger;
            _workerFist = workerFist;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _workerFist.DoWork(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Finalizando meu Job (Stop)");
            return Task.CompletedTask;
        }
    }
}
