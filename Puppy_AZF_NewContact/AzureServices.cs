using System;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace Puppy_AZF_NewContact
{
    public class AzureServices : IAzureServices
    {
        static IQueueClient queueClient;
        const string ServiceBusConnectionString = "Endpoint=sb://oberon.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=RlXFNdEaURZmgFwlr/Rzt6rySkUkpw/8/X23E+Cse/g=";
        const string QueueName = "newcontactazf";

        public AzureServices()
        {

        }

        public async Task SendMessageAsync(Message message)
        {
            // send service bus message
            try
            {
                queueClient = new QueueClient(ServiceBusConnectionString, QueueName);

                await queueClient.SendAsync(message);

                await queueClient.CloseAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
