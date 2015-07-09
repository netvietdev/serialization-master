using System;
using Rabbit.SerializationMaster;
using Rabbit.SerializationMaster.ServiceStack;

namespace ServiceStackSerializationImplTest
{
    class Program
    {
        static void Main(string[] args)
        {
            SerializationContext.Current.Initialize(new JsonSerializationStrategy());

            var obj = new { Name = "John", Age = 10 };
            var text = obj.Serialize();
            Console.WriteLine(text);

            var obj2 = Serializer.Deserialize<object>(text);
            var typeName = obj2.GetType().Name;

            Console.ReadLine();
        }
    }
}
