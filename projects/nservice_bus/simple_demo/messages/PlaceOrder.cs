using System;
using NServiceBus;

namespace messages
{
    public class PlaceOrder : ICommand
    {
        public Guid id { get; set; }
        public string product { get; set; }
    }
}