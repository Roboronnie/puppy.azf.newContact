using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Puppy_AZF_NewContact
{
    public interface IHandler
    {
        Task <IActionResult>ProcessHttpTriggerNewContactHandler(HttpRequest req, Microsoft.Extensions.Logging.ILogger logger);
    }
}
