using Rabbit.SerializationMaster.Internal.Strategies;
using System;

namespace Rabbit.SerializationMaster.Internal
{
    internal class SerializationStrategyBuilder
    {
        public ISerializationStrategy Build(SerializationType type)
        {
            switch (type)
            {
                case SerializationType.Base64:
                    return new Base64SerializationStrategy();
                case SerializationType.DataContractJson:
                    return new DataContractJsonSerializationStrategy();
                case SerializationType.Xml:
                    return new XmlSerializationStrategy();
            }
            throw new NotSupportedException();
        }
    }
}
