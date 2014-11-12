using System;
using messages;
using NServiceBus;

namespace client
{
    public class SendOrder : IWantToRunWhenBusStartsAndStops
    {
        public IBus bus { get; set; }

        public void Start()
        {
            Console.WriteLine("Press 'Enter' to send order. Ctrl-C to exit.");

            while (Console.ReadLine() != null)
            {
                var id = Guid.NewGuid();
                bus.Send(new PlaceOrder {order_id = id, product = "red stapler"});

                Console.WriteLine("==================================================");
                Console.WriteLine("Send a new PlaceOrder command with id {0}", id.ToString("N"));
            }
        }

        public void Stop()
        {
        }
    }
}