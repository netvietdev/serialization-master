using ServiceStack.Text;
using System;

namespace Rabbit.SerializationMaster.ServiceStack
{
    public class JsonSerializationStrategy : ISerializationStrategy
    {
        public string Serialize(object graph)
        {
            return JsonSerializer.SerializeToString(graph);
        }

        public object Deserialize(Type graphType, string serializedValue)
        {
            return JsonSerializer.DeserializeFromString(serializedValue, graphType);
        }
    }
}
