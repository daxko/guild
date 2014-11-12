using System;
using NServiceBus;

namespace messages
{
    public class OrderPlaced : IEvent
    {
        public Guid id { get; set; }
        public string product { get; set; }
    }
}