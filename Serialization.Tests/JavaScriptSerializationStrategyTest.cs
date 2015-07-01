using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rabbit.SerializationMaster;
using Rabbit.SerializationMaster.Web;
using Serialization.Tests.ObjectTests;

namespace Serialization.Tests
{
    [TestClass]
    public class JavaScriptSerializationStrategyTest
    {
        private ISerializationStrategy CreateSUT()
        {
            return new JavaScriptSerializationStrategy();
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
    }
}
