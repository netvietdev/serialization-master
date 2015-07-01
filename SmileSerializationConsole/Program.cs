using Smile.Serialization;
using System;

namespace SmileSerializationConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = new Thing();
            var xml = t.ToXml();

            var t2 = Deserialize.To<Thing>(xml, SerializerType.Xml);

            Console.WriteLine(xml);
            Console.ReadLine();
        }
    }
}
