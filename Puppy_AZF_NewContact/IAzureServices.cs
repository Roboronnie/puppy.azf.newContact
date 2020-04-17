using System;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace Puppy_AZF_NewContact
{
    public interface IAzureServices
    {
        Task SendMessageAsync(Message message);
    }
}
