using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rabbit.SerializationMaster;
using Rabbit.SerializationMaster.JsonNet;
using Serialization.Tests.ObjectTests;

namespace Serialization.Tests.JsonNet
{
    [TestClass]
    public class JsonSerializationStrategyTest
    {
        private ISerializationStrategy CreateSUT()
        {
            return new JsonSerializationStrategy();
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
            Assert.AreEqual("{\"Street\":\"Str\",\"Number\":1}", value);
        }

        [TestMethod]
        public void CanDeserialize()
        {
            // Arrange
            var str = "{\"Street\":\"Str\",\"Number\":1}";
            var sut = CreateSUT();

            // Act
            var obj = (Address)sut.Deserialize(typeof(Address), str);

            // Assert
            Assert.AreEqual("Str", obj.Street);
            Assert.AreEqual(1, obj.Number);
        }

        [TestMethod]
        public void CanSerializeAnonymousObject()
        {
            // Arrange
            var obj = new { Name = "John", Age = 10 };
            var sut = CreateSUT();

            // Act
            var value = sut.Serialize(obj);

            // Assert
            Assert.AreEqual("{\"Name\":\"John\",\"Age\":10}", value);
        }

        [TestMethod]
        public void CanDeserializeAnonymousObject()
        {
            // Arrange
            var str = "{\"Name\":\"John\",\"Age\":10}";
            var sut = CreateSUT();

            // Act
            var obj = (dynamic)sut.Deserialize(typeof(object), str);

            // Assert
            Assert.AreEqual("John", obj.Name.Value);
            Assert.AreEqual(10, obj.Age.Value);
        }
    }
}
