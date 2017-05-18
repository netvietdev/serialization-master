using System;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Rabbit.SerializationMaster.Strategies
{
    public class DataContractJsonSerializationStrategy : ISerializationStrategy
    {
        public virtual string Serialize(object graph)
        {
            var serializer = new DataContractJsonSerializer(graph.GetType());
            return Serialize(serializer, graph);
        }

        public virtual object Deserialize(Type graphType, string serializedValue)
        {
            var serializer = new DataContractJsonSerializer(graphType);
            return Deserialize(serializer, serializedValue);
        }

        protected string Serialize(DataContractJsonSerializer serializer, object graph)
        {
            var stream = new MemoryStream();

            serializer.WriteObject(stream, graph);
            stream.Flush();

            stream.Position = 0;
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        protected object Deserialize(DataContractJsonSerializer serializer, string serializedValue)
        {
            var memoryStream = new MemoryStream();

            using (var writer = new StreamWriter(memoryStream))
            {
                writer.Write(serializedValue);
                writer.Flush();

                memoryStream.Position = 0;
                return serializer.ReadObject(memoryStream);
            }
        }
    }
}
