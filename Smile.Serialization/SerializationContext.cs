using Rabbit.SerializationMaster.Strategies;
using System;

namespace Rabbit.SerializationMaster
{
    public sealed class SerializationContext
    {
        private static readonly Lazy<SerializationContext> Lazy = new Lazy<SerializationContext>(() => new SerializationContext());

        public ISerializationStrategy SerializationStrategy
        {
            get;
            private set;
        }

        private SerializationContext()
        {
        }

        public static SerializationContext Current
        {
            get { return Lazy.Value; }
        }

        public void Initialize(SerializationType type)
        {
            ValidateInitialization();
            SerializationStrategy = new SerializationStrategyBuilder().Build(type);
        }

        public void Initialize<T>(T serializationStrategy) where T : ISerializationStrategy
        {
            ValidateInitialization();
            SerializationStrategy = serializationStrategy;
        }

        internal void ValidateSerializationStrategy()
        {
            if (SerializationStrategy == null)
            {
                throw new ApplicationException("You must set a serialization strategy by calling Initialize method.");
            }
        }

        private void ValidateInitialization()
        {
            if (SerializationStrategy != null)
            {
                throw new ApplicationException("You cannot reinitialize serialization context.");
            }
        }
    }
}
