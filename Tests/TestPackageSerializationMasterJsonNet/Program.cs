using System;
using System.Collections.Generic;
using Rabbit.SerializationMaster;
using Rabbit.SerializationMaster.JsonNet;

namespace TestPackageSerializationMasterJsonNet
{
    class Program
    {
        static void Main(string[] args)
        {
            SerializationContext.Current.Initialize(new JsonSerializationStrategy());
            var obj = new
            {
                Name = "John",
                Age = 10,
                From = new
                {
                    Country = "VN"
                }
            };
            var text = obj.Serialize();
            Console.WriteLine(text);

            var obj2 = Serializer.Deserialize<dynamic>(text);

            Console.ReadLine();
        }
    }
}
