using System;
using NServiceBus;

namespace messages
{
    public class ServiceACalled : IEvent
    {
        public Guid order_id { get; set; }
        public string product { get; set; }

        public Guid service_a_result { get; set; }
    }
}