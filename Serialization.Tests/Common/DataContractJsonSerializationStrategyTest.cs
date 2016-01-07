using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rabbit.SerializationMaster;
using Rabbit.SerializationMaster.Strategies;
using Serialization.Tests.ObjectTests;

namespace Serialization.Tests.Common
{
    [TestClass]
    public class DataContractJsonSerializationStrategyTest
    {
        private ISerializationStrategy CreateSUT()
        {
            return new DataContractJsonSerializationStrategy();
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
            Assert.AreEqual("{\"<Number>k__BackingField\":1,\"<Street>k__BackingField\":\"Str\"}", value);
        }

        [TestMethod]
        public void CanDeserialize()
        {
            // Arrange
            var str = "{\"<Number>k__BackingField\":1,\"<Street>k__BackingField\":\"Str\"}";
            var sut = CreateSUT();

            // Act
            var obj = (Address)sut.Deserialize(typeof(Address), str);

            // Assert
            Assert.AreEqual("Str", obj.Street);
            Assert.AreEqual(1, obj.Number);
        }
    }
}
