using Autofac;
using CaseAnalyzer.Inject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseAnalyzer
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            var container = Injector.Register();
            var analyzer = container.Resolve<IAnalyzer>();

            // To do: to implement a CRON expression scheduler to run the process by using Quartz.NET
            analyzer.StartProcess();
        }
    }
}
