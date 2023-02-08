namespace Mango.Service.Email.Messaging
{
    public interface IAzureServiceBusConsumer
    {
        Task Start();

        Task Stop();
    }
}
