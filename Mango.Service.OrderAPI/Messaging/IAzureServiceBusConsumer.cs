namespace Mango.Service.OrderAPI.Messaging
{
    public interface IAzureServiceBusConsumer
    {
        Task Start();

        Task Stop();
    }
}
