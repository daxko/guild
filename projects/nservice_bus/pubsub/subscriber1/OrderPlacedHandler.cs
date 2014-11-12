using System;
using messages;
using NServiceBus;

namespace subscriber1
{
    public class OrderPlacedHandler : IHandleMessages<OrderPlaced>
    {
        public void Handle(OrderPlaced message)
        {
            Console.WriteLine("Updating customer's order history: adding order id {0}", message.id);
        }
    }
}