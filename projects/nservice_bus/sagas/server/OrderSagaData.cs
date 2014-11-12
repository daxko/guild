using System;
using NServiceBus.Saga;

namespace server
{
    public class OrderSagaData : ContainSagaData
    {
        [Unique]
        public Guid order_id { get; set; }
        public string product { get; set; }

        public Guid service_a_result { get; set; }
        public Guid service_b_result { get; set; }

        public bool timed_out { get; set; }
    }
}