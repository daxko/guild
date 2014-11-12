using System;
using NServiceBus;

namespace messages
{
    public class CallServiceB : ICommand
    {
        public Guid order_id { get; set; }
        public string product { get; set; }
    }
}