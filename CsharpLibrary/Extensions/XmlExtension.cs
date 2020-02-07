using System;
using System.IO;
using System.Xml.Serialization;

namespace CsharpLibrary.Extensions
{
    public static class XmlExtension
    {
        public static string SerializeToString<T>(this T obj, XmlSerializerNamespaces namespaces)
        {
            if (obj == null)
            {
                throw new ArgumentNullException($"null can not be serialized to xml!");
            }

            using (var writer = new StringWriter())
            {
                var serializer = new XmlSerializer(obj.GetType());

                serializer.Serialize(writer, obj, namespaces);

                return writer.ToString();
            }
        }

        public static T DeserializeFromObject<T>(string str)
        {
            using (var reader = new StringReader(str))
            {
                var serializer = new XmlSerializer(typeof(T));

                return (T)serializer.Deserialize(reader);
            }
        }
    }
}
