using CsharpLibrary.Extensions;
using FluentAssertions;
using NUnit.Framework;

namespace CsharpLibrary.Tests.Extensions
{
    [TestFixture]
    public class EncodingExtensionTests
    {
        [Test]
        public void Should_encoding_encode_work()
        {
            //Arrange
            var text = "client_id:client_secret";

            //Act
            var result = text.ToBase64();

            //Assert
            result.Should().BeEquivalentTo("Y2xpZW50X2lkOmNsaWVudF9zZWNyZXQ=");

        }

        [Test]
        public void Should_encoding_decode_work()
        {
            //Arrange
            var text = "Y2xpZW50X2lkOmNsaWVudF9zZWNyZXQ=";

            //Act
            var result = text.GetStringFromBase64();

            //Assert
            result.Should().BeEquivalentTo("client_id:client_secret");

        }
    }
}
