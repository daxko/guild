using System;
using System.Transactions;
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
                //using (var tx = new TransactionScope())
                //{
                    try
                    {
                        var id = Guid.NewGuid();
                        bus.Send(new PlaceOrder {id = id, product = "red stapler"});

                        Console.WriteLine("==================================================");
                        Console.WriteLine("Send a new PlaceOrder command with id {0}", id.ToString("N"));

                        //throw new Exception("Oops");

                        //tx.Complete();
                    }
                    catch (Exception)
                    {

                    }
                //}
            }
        }

        public void Stop()
        {
        }
    }
}