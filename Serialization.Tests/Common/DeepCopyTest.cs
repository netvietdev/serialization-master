﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rabbit.SerializationMaster;
using Serialization.Tests.ObjectTests;

namespace Serialization.Tests.Common
{
    [TestClass]
    public class DeepCopyTest
    {
        [TestMethod]
        public void CanPerformDeepCopy()
        {
            // Arrange
            var addr = new Address()
            {
                Number = 1,
                Street = "Str"
            };
            SerializationContext.Current.Initialize(SerializationType.Xml);

            // Act
            var newAddr = addr.DeepCopy();

            // Assert
            Assert.AreNotSame(addr, newAddr);
            Assert.AreEqual(addr.Number, newAddr.Number);
            Assert.AreEqual(addr.Street, newAddr.Street);
        }
    }
}
