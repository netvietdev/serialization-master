using Rabbit.SerializationMaster;
using Rabbit.SerializationMaster.Strategies;
using Rabbit.SerializationMaster.Web;
using SmileXmlSerialization.ObjectTests;
using System;

namespace SmileXmlSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Person()
            {
                Name = "H1",
                Age = 20,
                LivingAddress = new Address() { Number = 10, Street = "Tran Thai Tong" },
                WorkingAddress = new Address() { Number = 210, Street = "Nguyen Phong Sac" },
            };
            string result;
            Person p2;

            //try
            //{
            //    SerializationContext.Current.Initialize(SerializationType.Xml);
            //    result = p1.Serialize();

            //    Console.WriteLine("XML serialized result: " + result);
            //    Console.WriteLine("Length is: " + result.Length);

            //    p2 = Serializer.Deserialize<Person>(result);
            //    Console.WriteLine("XML deserialized result: " + p2.Name + " | " + p2.Age + " | " + p2.LivingAddress.Number);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //}

            //try
            //{
            //    Console.WriteLine("-----------");
            //    SerializationContext.Current.Initialize(SerializationType.DataContractJson);
            //    result = p1.Serialize();

            //    Console.WriteLine("DacoJson serialized result: " + result);
            //    Console.WriteLine("Length is: " + result.Length);

            //    p2 = Serializer.Deserialize<Person>(result);
            //    Console.WriteLine("DacoJson deserialized result: " + p2.Name + " | " + p2.Age + " | " + p2.LivingAddress.Number);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //try
            //{
            //    Console.WriteLine("-----------");
            //    SerializationContext.Current.Initialize(SerializationType.Base64);
            //    result = p1.Serialize();

            //    Console.WriteLine("Base64 serialized result: " + result);
            //    Console.WriteLine("Length is: " + result.Length);

            //    p2 = Serializer.Deserialize<Person>(result);
            //    Console.WriteLine("Base64 deserialized result: " + p2.Name + " | " + p2.Age + " | " + p2.LivingAddress.Number);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //try
            //{
            //    Console.WriteLine("-----------");
            //    result = p1.ToJson(JsonSerializerType.JsonNet);

            //    Console.WriteLine("Json serialized result: " + result);
            //    Console.WriteLine("Length is: " + result.Length);

            //    p2 = Deserialize.To<Person>(result, SerializationType.Json);
            //    Console.WriteLine("Json deserialized result: " + p2.Name + " | " + p2.Age + " | " + p2.LivingAddress.Number);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            try
            {
                Console.WriteLine("-----------");
                SerializationContext.Current.Initialize(new JavaScriptSerializationStrategy());
                result = p1.Serialize();

                Console.WriteLine("Json serialized result: " + result);
                Console.WriteLine("Length is: " + result.Length);

                p2 = result.Deserialize<Person>();
                Console.WriteLine("Json deserialized result: " + p2.Name + " | " + p2.Age + " | " + p2.LivingAddress.Number);

                Console.WriteLine("Use custom strategy");
                result = p1.Serialize(new Base64SerializationStrategy());
                Console.WriteLine("Json serialized result: " + result);
                Console.WriteLine("Length is: " + result.Length);

                p2 = result.Deserialize<Person>(new Base64SerializationStrategy());
                Console.WriteLine("Json deserialized result: " + p2.Name + " | " + p2.Age + " | " + p2.LivingAddress.Number);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
