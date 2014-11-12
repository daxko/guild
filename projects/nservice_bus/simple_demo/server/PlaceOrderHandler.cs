using System;
using messages;
using NServiceBus;

namespace server
{
    public class PlaceOrderHandler : IHandleMessages<PlaceOrder>
    {
        public void Handle(PlaceOrder message)
        {
            Console.WriteLine("Order for product: {0} placed with Id: {1}", message.product, message.id);
        }
    }
}