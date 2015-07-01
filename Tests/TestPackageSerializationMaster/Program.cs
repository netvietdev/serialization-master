using Rabbit.SerializationMaster;

namespace TestPackageSerializationMaster
{
    class Program
    {
        static void Main(string[] args)
        {
            SerializationContext.Current.Initialize(SerializationType.Xml);
        }
    }
}
