using Autofac;
using CaseAnalyzer.Config;
using CaseAnalyzer.Model;
using CaseAnalyzer.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CaseAnalyzerUnitTestProject
{
    [TestClass]
    public class SmtpEmailServiceUnitTest : BaseServiceTest
    {

        private IEmailConfig cfg;
        private IEmailService emailService;

        [TestInitialize]
        public void Init()
        {
            this.cfg = container.Resolve<IEmailConfig>();
            this.emailService = container.Resolve<IEmailService>();
        }

        [TestMethod]
        public void TestSendEmail()
        {
            var dto = new MailDto()
            {
                Subject = "Hello",
                Body = "Hello",
            };
            dto.ToList.Add("test@abc.com");

            emailService.Send(dto);
        }
    }
}
