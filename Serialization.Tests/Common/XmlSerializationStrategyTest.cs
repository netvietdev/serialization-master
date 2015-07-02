using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rabbit.SerializationMaster;
using Rabbit.SerializationMaster.Internal.Strategies;
using Serialization.Tests.ObjectTests;

namespace Serialization.Tests.Common
{
    [TestClass]
    public class XmlSerializationStrategyTest
    {
        private ISerializationStrategy CreateSUT()
        {
            return new XmlSerializationStrategy();
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
            Assert.AreEqual(@"<?xml version=""1.0"" encoding=""utf-16""?>
<Address xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <Street>Str</Street>
  <Number>1</Number>
</Address>", value);
        }

        [TestMethod]
        public void CanDeserialize()
        {
            // Arrange
            var str = @"<?xml version=""1.0"" encoding=""utf-16""?>
<Address xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <Street>Str</Street>
  <Number>1</Number>
</Address>";
            var sut = CreateSUT();

            // Act
            var obj = (Address)sut.Deserialize(typeof(Address), str);

            // Assert
            Assert.AreEqual("Str", obj.Street);
            Assert.AreEqual(1, obj.Number);
        }
    }
}
