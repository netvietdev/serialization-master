using System;

namespace Serialization.Tests.ObjectTests
{
    [Serializable]
    public class Address
    {
        public string Street { get; set; }
        public int Number { get; set; }
    }
}
