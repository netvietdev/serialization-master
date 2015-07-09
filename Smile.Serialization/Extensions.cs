namespace Rabbit.SerializationMaster
{
    public static class Extensions
    {
        public static string Serialize<T>(this T obj) where T : class
        {
            SerializationContext.Current.ValidateSerializationStrategy();
            return SerializationContext.Current.SerializationStrategy.Serialize(obj);
        }

        public static T Deserialize<T>(this string serializedValue) where T : class
        {
            SerializationContext.Current.ValidateSerializationStrategy();
            return (T)SerializationContext.Current.SerializationStrategy.Deserialize(typeof(T), serializedValue);
        }

        public static T DeepCopy<T>(this T obj) where T : class
        {
            return obj.Serialize().Deserialize<T>();
        }
    }
}
