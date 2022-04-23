using Autofac;
using CaseAnalyzer.Config;
using CaseAnalyzer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseAnalyzer.Inject
{
    public class Injector
    {
        public static IContainer Register()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<EmailConfig>().As<IEmailConfig>();
            builder.RegisterType<FileConfig>().As<IFileConfig>();
            builder.RegisterType<CaseFileService>().As<IFileService>();
            builder.RegisterType<SmtpEmailService>().As<IEmailService>();
            builder.RegisterType<Analyzer>().As<IAnalyzer>();
            return builder.Build();
        }
    }
}
