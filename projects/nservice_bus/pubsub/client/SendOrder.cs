using System;
using messages;
using NServiceBus;

namespace client
{
    public class SendOrder : IWantToRunWhenBusStartsAndStops
    {
        public IBus Bus { get; set; }

        public void Start() {
            Console.WriteLine("Press 'Enter' to send a message.To exit, Ctrl + C");

            while (Console.ReadLine() != null) {
                var id = Guid.NewGuid();

                Bus.Send("publisher", new PlaceOrder { product = "red stapler", id = id });

                Console.WriteLine("==========================================================================");
                Console.WriteLine("Send a new PlaceOrder message with id: {0}", id.ToString("N"));
            }
        }        

        public void Stop()
        {
        }
    }
}