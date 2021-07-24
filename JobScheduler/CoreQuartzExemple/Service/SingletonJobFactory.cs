using CoreQuartzExemple.Models;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreQuartzExemple.Service
{
    public class SingletonJobFactory: IJobFactory
    {
        //Pattern para instanciar e retornar o job

        private readonly IServiceProvider _serviceProvider;

        public SingletonJobFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            Common.Logs($"NewJob at {DateTime.Now.ToString("dd-MM-yyyy")} ", $"NewJob_{DateTime.Now.ToString("dd-MM-yyyy")}");

            return _serviceProvider.GetRequiredService(bundle.JobDetail.JobType) as IJob;
        }

        public void ReturnJob(IJob job)
        {


        }
    }
}
