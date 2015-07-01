using System;
using System.Web.Script.Serialization;

namespace Rabbit.SerializationMaster.Web
{
    public class JavaScriptSerializationStrategy : ISerializationStrategy
    {
        private readonly JavaScriptSerializer _serializer;

        public JavaScriptSerializationStrategy()
        {
            _serializer = new JavaScriptSerializer();
        }

        public string Serialize(object graph)
        {
            return _serializer.Serialize(graph);
        }

        public object Deserialize(Type graphType, string serializedValue)
        {
            return _serializer.Deserialize(serializedValue, graphType);
        }
    }
}
