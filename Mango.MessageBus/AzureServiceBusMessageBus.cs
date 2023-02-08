using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mango.MessageBus
{
    public class AzureServiceBusMessageBus : IBaseMessage
    {
        private string connectionString = "Endpoint=sb://mangorestaurant1.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=9YVqtwGtl9o89VmzSmx2vsUkEAEJmIWWdEPIP/9HSxg=";
        public async Task PublishMessage(BaseMessage message, string topicName)
        {
            ISenderClient senderCLient = new TopicClient(connectionString, topicName);

            var jsonMessage = JsonConvert.SerializeObject(message);

            var finalMessage = new Message(Encoding.UTF8.GetBytes(jsonMessage))
            {
                CorrelationId = Guid.NewGuid().ToString()
            };

            await senderCLient.SendAsync(finalMessage);

            await senderCLient.CloseAsync();
        }
    }
}
