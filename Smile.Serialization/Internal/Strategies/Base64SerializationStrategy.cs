using System;
using System.Text;

namespace Rabbit.SerializationMaster.Internal.Strategies
{
    internal class Base64SerializationStrategy : ISerializationStrategy
    {
        private readonly ISerializationStrategy _realSerializationStategy;

        public Base64SerializationStrategy()
        {
            _realSerializationStategy = new DataContractJsonSerializationStrategy();
        }

        public string Serialize(object graph)
        {
            var serializedValue = _realSerializationStategy.Serialize(graph);
            return Convert.ToBase64String(Encoding.Unicode.GetBytes(serializedValue));
        }

        public object Deserialize(Type graphType, string serializedValue)
        {
            var realSerializedValue = Encoding.Unicode.GetString(Convert.FromBase64String(serializedValue));
            return _realSerializationStategy.Deserialize(graphType, realSerializedValue);
        }
    }
}
