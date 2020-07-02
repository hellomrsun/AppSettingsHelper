using System;
using System.IO;
using log4net.Config;
using LogAdatper;
using NUnit.Framework;

namespace CsharpLibrary.Tests.LogAdapter
{
    [TestFixture]
    public class LoggerTests
    {
        [SetUp]
        public void Setup()
        {
            var d = Path.GetDirectoryName(TestContext.CurrentContext.TestDirectory);
            XmlConfigurator.Configure(new FileInfo(Path.Combine(d, @"Debug\log4net.config")));
        }

        [Test]
        public void Should_logger_log()
        {
            LoggerConfigurator.Instance.Info("hello");
            LoggerConfigurator.Instance.Error("error", new ArgumentNullException("null argument"));
        }
    }
}
