using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreQuartzExemple.Models
{
    public class MyJob
    {

        //Configurações do Job
        public MyJob(Type type, string expression)
        {
            Common.Logs($"MyJob at {DateTime.Now.ToString("dd-MM-yyyy")} ", $"MyJob_{DateTime.Now.ToString("dd-MM-yyyy")}");

            Type = type;
            Expression = expression;
        }

        public Type Type { get; }
        public string Expression { get; }


    }
}
