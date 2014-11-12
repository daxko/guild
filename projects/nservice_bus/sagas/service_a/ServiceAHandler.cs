using System;
using System.Threading;
using messages;
using NServiceBus;

namespace service_a
{
    public class ServiceAHandler : IHandleMessages<CallServiceA>
    {
        readonly Random random = new Random();
        public IBus bus { get; set; }

        public void Handle(CallServiceA message)
        {
            var delay_time = delay();
            Console.WriteLine("Calling Service A's remote API. Waiting {0} ms", delay_time);
            Thread.Sleep(delay_time); //pretend to do some work
            var result = Guid.NewGuid();
            bus.Publish(new ServiceACalled {order_id = message.order_id, product = message.product, service_a_result = result});
        }

        int delay()
        {
            return random.Next(1, 5)*1000;
        }
    }
}