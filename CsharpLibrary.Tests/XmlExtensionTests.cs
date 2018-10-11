using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using FluentAssertions;
using NUnit.Framework;

namespace CsharpLibrary.Tests
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
                    Name = "Dylan SUN Doc",
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
