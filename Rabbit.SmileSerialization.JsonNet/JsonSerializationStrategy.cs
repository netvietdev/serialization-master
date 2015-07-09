using System;
using Newtonsoft.Json;

namespace Rabbit.SerializationMaster.JsonNet
{
    public class JsonSerializationStrategy : ISerializationStrategy
    {
        public string Serialize(object graph)
        {
            return JsonConvert.SerializeObject(graph, Formatting.None);
        }

        public object Deserialize(Type graphType, string serializedValue)
        {
            if (graphType == typeof(object) || graphType == typeof(dynamic))
            {
                return JsonConvert.DeserializeObject(serializedValue);
            }

            return JsonConvert.DeserializeObject(serializedValue, graphType);
        }
    }
}
