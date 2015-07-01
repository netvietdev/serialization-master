using System;

namespace SmileSerializationConsole
{
    public class Thing
    {
        public Thing()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}
