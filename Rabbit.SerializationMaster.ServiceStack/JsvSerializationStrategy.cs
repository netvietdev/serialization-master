using ServiceStack;
using ServiceStack.Text;
using System;

namespace Rabbit.SerializationMaster.ServiceStack
{
    public class JsvSerializationStrategy : ISerializationStrategy
    {
        public string Serialize(object graph)
        {
            return graph.ToJsv();
        }

        public object Deserialize(Type graphType, string serializedValue)
        {
            return TypeSerializer.DeserializeFromString(serializedValue, graphType);
        }
    }
}
