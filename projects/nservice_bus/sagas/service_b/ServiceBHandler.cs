using System;
using System.Threading;
using messages;
using NServiceBus;

namespace service_b
{
    public class ServiceBHandler : IHandleMessages<CallServiceB>
    {
        Random random = new Random();
        public IBus bus { get; set; }
        
        public void Handle(CallServiceB message)
        {
            var delay_time = delay();
            Console.WriteLine("Calling Service B's remote API. Waiting {0} ms", delay_time);
            Thread.Sleep(delay_time); //pretend to do some work
            var result = Guid.NewGuid();
            bus.Publish(new ServiceBCalled {order_id = message.order_id, product = message.product, service_b_result = result});
        }

        int delay()
        {
            return random.Next(1, 5)*1000;
        }
    }
}