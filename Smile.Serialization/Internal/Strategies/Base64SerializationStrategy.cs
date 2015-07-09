using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Rabbit.SerializationMaster.Internal.Strategies
{
    internal class Base64SerializationStrategy : ISerializationStrategy
    {
        public string Serialize(object graph)
        {
            ValidateObjectSerializable(graph);

            using (var ms = new MemoryStream())
            {
                var b = new BinaryFormatter();
                b.Serialize(ms, graph);

                return Convert.ToBase64String(ms.ToArray());
            }
        }

        public object Deserialize(Type graphType, string serializedValue)
        {
            using (var ms = new MemoryStream(Convert.FromBase64String(serializedValue)))
            {
                var b = new BinaryFormatter();
                return b.Deserialize(ms);
            }
        }

        private void ValidateObjectSerializable(object graph)
        {
            var type = graph.GetType();
            if (!type.IsSerializable)
            {
                throw new ArgumentException(
                    string.Format("The type {0} is not serializable, it must be decorated with Serializable attribute",
                                  type.FullName));
            }
        }
    }
}
