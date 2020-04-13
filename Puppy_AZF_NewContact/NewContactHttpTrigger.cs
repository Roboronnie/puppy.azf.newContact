using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Puppy_AZF_NewContact
{
    public class NewContactHttpTrigger
    {
        private readonly IHandler handler;

        public NewContactHttpTrigger(IHandler handler)
        {
            this.handler = handler;
        }

        [FunctionName("Puppy_AZF_NewContact")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req, ILogger log)
        {
            return await handler.ProcessHttpTriggerNewContactHandler(req, log);
        }
    }
}
