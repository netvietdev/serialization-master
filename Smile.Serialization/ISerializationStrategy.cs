using System;

namespace Rabbit.SerializationMaster
{
    public interface ISerializationStrategy
    {
        string Serialize(object graph);
        object Deserialize(Type graphType, string serializedValue);
    }
}
