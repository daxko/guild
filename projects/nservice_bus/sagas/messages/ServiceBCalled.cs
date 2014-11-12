using System;
using NServiceBus;

namespace messages
{
    public class ServiceBCalled : IEvent
    {
        public Guid order_id { get; set; }
        public string product { get; set; }

        public Guid service_b_result { get; set; }
    }
}