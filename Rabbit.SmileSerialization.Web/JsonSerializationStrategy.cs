using System;
using System.Web.Helpers;

namespace Rabbit.SerializationMaster.Web
{
    public class JsonSerializationStrategy : ISerializationStrategy
    {
        public string Serialize(object graph)
        {
            return Json.Encode(graph);
        }

        public object Deserialize(Type graphType, string serializedValue)
        {
            return Json.Decode(serializedValue, graphType);
        }
    }
}
