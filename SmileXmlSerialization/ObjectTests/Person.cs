using System;
using System.Collections.Generic;

namespace SmileXmlSerialization.ObjectTests
{
    [Serializable]
    public class Person
    {
        private readonly IList<Address> _addresses = new List<Address>();
        private Address _livingAddress;
        private Address _workingAddress;

        public string Name { get; set; }
        public int Age { get; set; }

        public Address LivingAddress
        {
            get { return _livingAddress; }
            set
            {
                _livingAddress = value;
                _addresses.Add(value);
            }
        }

        public Address WorkingAddress
        {
            get { return _workingAddress; }
            set
            {
                _workingAddress = value;
                _addresses.Add(value);
            }
        }
    }
}
