using Rabbit.SerializationMaster;
using Rabbit.SerializationMaster.JsonNet;

namespace TestPackageSerializationMasterJsonNet
{
    class Program
    {
        static void Main(string[] args)
        {
            SerializationContext.Current.Initialize(new JsonSerializationStrategy());
        }
    }
}
