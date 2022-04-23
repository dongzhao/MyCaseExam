
using Autofac;
using CaseAnalyzer.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CaseAnalyzerUnitTestProject
{
    [TestClass]
    public class CaseFileServiceUnitTest : BaseServiceTest
    {
        private IFileService filesService;

        [TestInitialize]
        public void Init()
        {
            this.filesService = container.Resolve<IFileService>();
        }

        [TestMethod]
        public void TestIsValidFile()
        {
        }

        [TestMethod]
        public void TestGetApplicationNumber()
        {
        }

        [TestMethod]
        public void TestExtractFile()
        {
        }
    }
}
