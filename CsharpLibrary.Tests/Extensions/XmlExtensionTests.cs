using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using CsharpLibrary.Extensions;
using FluentAssertions;
using NUnit.Framework;

namespace CsharpLibrary.Tests.Extensions
{
    [TestFixture]
    public class XmlExtensionTests
    {
        [Test]
        public void Should_XmlExtension_serialize_work()
        {
            //Arrange
            var xmlDoc = new XmlDoc
            {
                Header = new DocumentHeader
                {
                    Name = "Jiangong SUN's Doc",
                    Parameters = new List<string>
                    {
                        "Param 1",
                        "Param 2"
                    }
                },
                Body = new DocumentBody
                {
                    Id = 10001,
                    Paragraphs = new List<Paragraph>
                    {
                        new Paragraph
                        {
                            Title = "Title 1",
                            Content = "Content 1"
                        },
                        new Paragraph
                        {
                            Title = "Title 2",
                            Content = "Content 2"
                        }
                    }
                }
            };
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("big", "header.name.space.1");
            namespaces.Add("green", "body.name.space.1");

            //Act
            var result = xmlDoc.SerializeToString(namespaces);

            //Assert
            result.Should().Contain("header.name.space.1");
        }

        [Test]
        public void Should_XmlExtension_deserialize_string_to_object_ok()
        {
            //Arrange
            var input =
                "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<Document xmlns:big=\"header.name.space.1\" xmlns:green=\"body.name.space.1\" xmlns=\"doc.name.space.1\">\r\n  <big:Header>\r\n    <big:Name>Jiangong SUN's Doc</big:Name>\r\n    <big:Parameters>\r\n      <big:Parameter>Param 1</big:Parameter>\r\n      <big:Parameter>Param 2</big:Parameter>\r\n    </big:Parameters>\r\n  </big:Header>\r\n  <green:Body>\r\n    <green:Id>10001</green:Id>\r\n    <green:Paragraphs>\r\n      <green:Paragraph>\r\n        <green:Title>Title 1</green:Title>\r\n        <green:Content>Content 1</green:Content>\r\n      </green:Paragraph>\r\n      <green:Paragraph>\r\n        <green:Title>Title 2</green:Title>\r\n        <green:Content>Content 2</green:Content>\r\n      </green:Paragraph>\r\n    </green:Paragraphs>\r\n  </green:Body>\r\n</Document>";

            //Act
            var result = XmlExtension.DeserializeFromObject<XmlDoc>(input);

            //Assert
            result.Header.Name.Should().Be("Jiangong SUN's Doc");
        }
    }

    [Serializable]
    [XmlRoot(ElementName = "Document", Namespace = "doc.name.space.1")]
    public class XmlDoc
    {
        [XmlElement(ElementName = "Header", Namespace = "header.name.space.1")]
        public DocumentHeader Header { get; set; }

        [XmlElement(ElementName = "Body", Namespace = "body.name.space.1")]
        public DocumentBody Body { get; set; }
    }

    [Serializable]
    public class DocumentHeader
    {
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }

        [XmlArray(ElementName = "Parameters")]
        [XmlArrayItem(typeof(string), ElementName = "Parameter")]
        public List<string> Parameters { get; set; }
    }

    [Serializable]
    public class DocumentBody
    {
        [XmlElement(ElementName = "Id")]
        public int Id { get; set; }

        [XmlArray(ElementName = "Paragraphs")]
        [XmlArrayItem(ElementName = "Paragraph")]
        public List<Paragraph> Paragraphs { get; set; }
    }

    public class Paragraph
    {
        [XmlElement(ElementName = "Title")]
        public string Title { get; set; }

        [XmlElement(ElementName = "Content")]
        public string Content { get; set; }
    }
}