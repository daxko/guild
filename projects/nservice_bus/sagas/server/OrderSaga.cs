using System;
using messages;
using NServiceBus;
using NServiceBus.Saga;

namespace server
{
    public class OrderSaga : Saga<OrderSagaData>,
        IAmStartedByMessages<PlaceOrder>,
        IHandleMessages<ServiceACalled>,
        IHandleMessages<ServiceBCalled>,
        IHandleTimeouts<OrderTimeout>
    {
        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<OrderSagaData> mapper)
        {
            mapper.ConfigureMapping<ServiceACalled>(s => s.order_id).ToSaga(x => x.order_id);
            mapper.ConfigureMapping<ServiceBCalled>(s => s.order_id).ToSaga(x => x.order_id);
        }

        public void Handle(PlaceOrder message)
        {
            Data.order_id = message.order_id;
            Data.product = message.product;

            Console.WriteLine("\n\n===========================================================");
            Console.WriteLine("Recieved Order {0}. Calling Service A...", message.order_id);

            RequestTimeout<OrderTimeout>(TimeSpan.FromSeconds(30));
            Bus.Send(new CallServiceA {order_id = message.order_id, product = message.product});
        }

        public void Handle(ServiceACalled message)
        {
            Console.WriteLine("Recieved results from Service A. Calling Service B...");
            Data.service_a_result = message.service_a_result;

            Bus.Send(new CallServiceB {order_id = Data.order_id, product = Data.product });
        }

        public void Handle(ServiceBCalled message)
        {
            Console.WriteLine("Recieved results from Service B. Completing order...");
            Data.service_b_result = message.service_b_result;

            Console.WriteLine("Finished processing order {2}:\nService A Result: {0}\nService B Result: {1}", Data.service_a_result, Data.service_b_result, Data.order_id);
            MarkAsComplete();
        }

        public void Timeout(OrderTimeout state)
        {
            Console.WriteLine("Order took too long. Deleting for space.");
            Data.timed_out = true;
        }
    }
}