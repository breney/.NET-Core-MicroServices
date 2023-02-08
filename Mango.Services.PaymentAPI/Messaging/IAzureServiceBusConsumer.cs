namespace Mango.Service.PaymentAPI.Messaging
{
    public interface IAzureServiceBusConsumer
    {
        Task Start();

        Task Stop();
    }
}
