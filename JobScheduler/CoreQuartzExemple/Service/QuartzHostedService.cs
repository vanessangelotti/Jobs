using CoreQuartzExemple.Models;
using Microsoft.Extensions.Hosting;
using Quartz;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CoreQuartzExemple.Service
{
    public class QuartzHostedService: IHostedService
    {

        //Configuração do Serviço Quartz, sobe uma unica vez, quando inicia a aplicação.
        private readonly ISchedulerFactory _schedulerFactory;
        private readonly IJobFactory _jobFactory;
        private readonly IEnumerable<MyJob> _myJobs;

        public QuartzHostedService(ISchedulerFactory schedulerFactory, IJobFactory jobFactory, IEnumerable<MyJob> myJobs)
        {
            _schedulerFactory = schedulerFactory;
            _jobFactory = jobFactory;
            _myJobs = myJobs;
        }

        public IScheduler Scheduler { get; set; }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Common.Logs($"StartAsync at {DateTime.Now.ToString("dd-MM-yyyy")} ", $"StartAsync_{DateTime.Now.ToString("dd-MM-yyyy")}");


            Scheduler = await _schedulerFactory.GetScheduler(cancellationToken);
            Scheduler.JobFactory = _jobFactory;

            foreach (var myJob in _myJobs)
            {
                var job = CreateJob(myJob);
                var trigger = CreateTrigger(myJob);

                await Scheduler.ScheduleJob(job, trigger, cancellationToken);

            }

            await Scheduler.Start(cancellationToken);


        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            Common.Logs($"StopAsync at {DateTime.Now.ToString("dd-MM-yyyy")} ", $"StopAsync_{DateTime.Now.ToString("dd-MM-yyyy")}");

            await Scheduler?.Shutdown(cancellationToken);

        }

        private static IJobDetail CreateJob(MyJob myJob)
        {
            var type = myJob.Type;
            return JobBuilder.Create(type).WithIdentity(type.FullName).WithDescription(type.Name).Build();
        }

        private static ITrigger CreateTrigger(MyJob myJob)
        {
            var type = myJob.Type;
            return TriggerBuilder.Create().WithIdentity($"{myJob.Type.FullName}.trigger").WithCronSchedule(myJob.Expression).WithDescription(myJob.Expression).Build();
        }
    }
}
