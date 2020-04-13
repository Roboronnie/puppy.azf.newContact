using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Puppy_AZF_NewContact.Models;
using Microsoft.Azure.ServiceBus;

namespace Puppy_AZF_NewContact
{
    public class NewContactHandler : IHandler
    {
        public NewContactHandler()
        {
        }

        public async Task<IActionResult> ProcessHttpTriggerNewContactHandler(HttpRequest req, ILogger log)
        {
            var deserializedRequestBody = new NewContact();
            // parse request
            try
            {
                using StreamReader reader = new StreamReader(req.Body, Encoding.UTF8);
                var requestBody = await reader.ReadToEndAsync();
                deserializedRequestBody = JsonConvert.DeserializeObject<NewContact>(requestBody);
            }
            catch
            {
                log.LogError("Error parsing request");
                return new StatusCodeResult(StatusCodes.Status400BadRequest);
            }

            // send service bus message

            try
            {
                var outgoingMessage = new OutgoingMessage
                {
                    MessageType = "NewContact",
                    Data = new
                    {

                    }
                };

                var messageBody = JsonConvert.SerializeObject(outgoingMessage);
                Message message = new Message(Encoding.UTF8.GetBytes(messageBody))
                {
                    SessionId = "sessionId"
                };

                var destinationTopic = "destinationTopic";
                var connectionString = "connectionString";
                ITopicClient topicClient = new TopicClient(connectionString, destinationTopic);

                await topicClient.SendAsync(message);
            }
            catch
            {
                log.LogError("Error sending sb message");
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            return new StatusCodeResult(StatusCodes.Status200OK);
        }
    }
}
