using System;
using messages;
using NServiceBus;

namespace subscriber2
{
    public class OrderPlacedHandler : IHandleMessages<OrderPlaced>
    {
        public void Handle(OrderPlaced message)
        {
            Console.WriteLine("Updating customer's preferred status");
        }
    }
}