using CoreQuartzExemple.Models;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreQuartzExemple.Service
{
    public class JobReminders: IJob
    {

        //Processamento do Job a ser executado
        public JobReminders()
        {

        }

        public Task Execute(IJobExecutionContext context)
        {
            Common.Logs($"JobReminders at {DateTime.Now.ToString("dd-MM-yyyy")} ", $"JobReminders_{DateTime.Now.ToString("dd-MM-yyyy")}");


            return Task.CompletedTask;
        }
    }
}
