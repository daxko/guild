using System;
using messages;
using NServiceBus;

namespace publisher
{
    public class PlaceOrderHandler : IHandleMessages<PlaceOrder>
    {
        public IBus bus { get; set; }

        public void Handle(PlaceOrder message)
        {
            Console.WriteLine("Placed order for product: {0} with id {1}", message.product, message.id.ToString("N"));
            bus.Publish(new OrderPlaced {id = message.id, product = message.product});
        }
    }
}