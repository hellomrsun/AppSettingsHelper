using System;
using CsharpLibrary.AppSettings;
using FluentAssertions;
using NUnit.Framework;

namespace CsharpLibrary.Tests.AppSettings
{
    [TestFixture]
    public class AppSettingsParserTests
    {
        private readonly IAppSettingsParser _appSettingsParser = new AppSettingsParser();

        [Test]
        public void Should_AppSettingsParser_throw_when_key_is_missing()
        {
            //Act
            Action action = () => _appSettingsParser.Get<string>("APPSETTINGS_KEY_MISSING");

            //Assert
            action.Should().Throw<ArgumentException>();
        }

        [Test]
        public void Should_AppSettingsParser_throw_when_value_is_missing()
        {
            //Act
            Action action = () => _appSettingsParser.Get<string>("APPSETTINGS_VALUE_MISSING");

            //Assert
            action.Should().Throw<ArgumentException>();
        }
    }
}
