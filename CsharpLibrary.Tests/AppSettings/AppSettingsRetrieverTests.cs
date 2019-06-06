using System;
using CsharpLibrary.AppSettings;
using CsharpLibrary.Enums;
using NUnit.Framework;

namespace CsharpLibrary.Tests.AppSettings
{
    [TestFixture]
    public class AppSettingsRetrieverTests
    {
        private IAppSettingsRetriever _target;

        [Test]
        public void Should_get_string_typed_value()
        {
            //Arrange
            var appSettingsParser = new AppSettingsParser();
            _target = new AppSettingsRetriever(appSettingsParser);

            //Assert
            Assert.AreEqual("Hello", _target.StringValue);
        }

        [Test]
        public void Should_get_int_typed_value()
        {
            //Arrange
            var appSettingsParser = new AppSettingsParser();
            _target = new AppSettingsRetriever(appSettingsParser);

            //Assert
            Assert.AreEqual(101, _target.IntValue);
        }

        [Test]
        public void Should_get_date_typed_value()
        {
            //Arrange
            var appSettingsParser = new AppSettingsParser();
            _target = new AppSettingsRetriever(appSettingsParser);

            //Assert
            Assert.AreEqual(new DateTime(2019, 6, 4), _target.DateValue);
        }

        [Test]
        public void Should_get_enum_typed_value()
        {
            //Arrange
            var appSettingsParser = new AppSettingsParser();
            _target = new AppSettingsRetriever(appSettingsParser);

            //Assert
            Assert.AreEqual(Furniture.Table, _target.EnumValue);
        }

    }


}
