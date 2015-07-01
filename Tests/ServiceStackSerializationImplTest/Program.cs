using Rabbit.SerializationMaster;
using Rabbit.SerializationMaster.ServiceStack;

namespace ServiceStackSerializationImplTest
{
    class Program
    {
        static void Main(string[] args)
        {
            SerializationContext.Current.Initialize(new JsonSerializationStrategy());
        }
    }
}
