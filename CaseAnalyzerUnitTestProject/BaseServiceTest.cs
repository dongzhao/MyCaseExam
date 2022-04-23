using Autofac;
using CaseAnalyzer.Config;
using CaseAnalyzer.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CaseAnalyzerUnitTestProject
{
    [TestClass]
    public abstract class BaseServiceTest
    {
        protected Autofac.IContainer container;

        [TestInitialize]
        public void Setup()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<EmailConfig>().As<IEmailConfig>();
            builder.RegisterType<CaseFileService>().As<IFileService>();
            builder.RegisterType<SmtpEmailService>().As<IEmailService>();

            container = builder.Build();
        }
    }
}
