using System;
using System.IO;
using System.Xml.Serialization;

namespace Rabbit.SerializationMaster.Strategies
{
    public class XmlSerializationStrategy : ISerializationStrategy
    {
        public string Serialize(object @object)
        {
            var serializer = new XmlSerializer(@object.GetType());
            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, @object);
                return writer.ToString();
            }
        }

        public object Deserialize(Type objectType, string serializedValue)
        {
            var serializer = new XmlSerializer(objectType);
            using (var reader = new StringReader(serializedValue))
            {
                return serializer.Deserialize(reader);
            }
        }
    }
}
