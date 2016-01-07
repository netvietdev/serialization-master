using System;

namespace Rabbit.SerializationMaster
{
    public static class Extensions
    {
        public static string Serialize<T>(this T obj) where T : class
        {
            SerializationContext.Current.ValidateSerializationStrategy();
            return obj.Serialize(SerializationContext.Current.SerializationStrategy);
        }

        public static string Serialize<T>(this T obj, ISerializationStrategy serializationStrategy) where T : class
        {
            if (typeof(T) == typeof(String))
            {
                return obj as string;
            }

            return serializationStrategy.Serialize(obj);
        }

        public static T Deserialize<T>(this string serializedValue) where T : class
        {
            SerializationContext.Current.ValidateSerializationStrategy();
            return serializedValue.Deserialize<T>(SerializationContext.Current.SerializationStrategy);
        }

        public static T Deserialize<T>(this string serializedValue, ISerializationStrategy serializationStrategy) where T : class
        {
            if (typeof(T) == typeof(String))
            {
                return serializedValue as T;
            }

            return (T)serializationStrategy.Deserialize(typeof(T), serializedValue);
        }

        public static T DeepCopy<T>(this T obj) where T : class
        {
            return obj.DeepCopy(SerializationContext.Current.SerializationStrategy);
        }

        public static T DeepCopy<T>(this T obj, ISerializationStrategy serializationStrategy) where T : class
        {
            return obj.Serialize(serializationStrategy).Deserialize<T>(serializationStrategy);
        }
    }
}
