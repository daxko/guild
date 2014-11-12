using System;
using NServiceBus;

namespace messages
{
    public class OrderPlaced : IEvent
    {
        public Guid order_id { get; set; }
        public string product { get; set; }
    }
}