using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rabbit.SerializationMaster;
using Rabbit.SerializationMaster.Internal.Strategies;
using Serialization.Tests.ObjectTests;

namespace Serialization.Tests.Common
{
    [TestClass]
    public class Base64SerializationStrategyTest
    {
        private ISerializationStrategy CreateSUT()
        {
            return new Base64SerializationStrategy();
        }

        [TestMethod]
        public void CanSerialize()
        {
            // Arrange
            var addr = new Address()
            {
                Number = 1,
                Street = "Str"
            };
            var sut = CreateSUT();

            // Act
            var value = sut.Serialize(addr);

            // Assert
            Assert.AreEqual("AAEAAAD/////AQAAAAAAAAAMAgAAAEpTZXJpYWxpemF0aW9uLlRlc3RzLCBWZXJzaW9uPTEuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49bnVsbAUBAAAAJ1NlcmlhbGl6YXRpb24uVGVzdHMuT2JqZWN0VGVzdHMuQWRkcmVzcwIAAAAXPFN0cmVldD5rX19CYWNraW5nRmllbGQXPE51bWJlcj5rX19CYWNraW5nRmllbGQBAAgCAAAABgMAAAADU3RyAQAAAAs=", value);
        }

        [TestMethod]
        public void CanDeserialize()
        {
            // Arrange
            var str = "AAEAAAD/////AQAAAAAAAAAMAgAAAEpTZXJpYWxpemF0aW9uLlRlc3RzLCBWZXJzaW9uPTEuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49bnVsbAUBAAAAJ1NlcmlhbGl6YXRpb24uVGVzdHMuT2JqZWN0VGVzdHMuQWRkcmVzcwIAAAAXPFN0cmVldD5rX19CYWNraW5nRmllbGQXPE51bWJlcj5rX19CYWNraW5nRmllbGQBAAgCAAAABgMAAAADU3RyAQAAAAs=";
            var sut = CreateSUT();

            // Act
            var obj = (Address)sut.Deserialize(typeof(Address), str);

            // Assert
            Assert.AreEqual("Str", obj.Street);
            Assert.AreEqual(1, obj.Number);
        }
    }
}
