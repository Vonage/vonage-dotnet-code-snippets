using Nexmo.Api;
using Nexmo.Api.Request;
using Nexmo.Api.Applications;
using Nexmo.Api.Applications.Capabilities;
using Webhook = Nexmo.Api.Common.Webhook;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DotnetCliCodeSnippets.Application
{
    public class CreateApplication : ICodeSnippet
    {
        public void Execute()
        {
            var APPLICATION_NAME = Environment.GetEnvironmentVariable("APPLICATION_NAME") ?? "APPLICATION_NAME";
            var NEXMO_API_KEY = Environment.GetEnvironmentVariable("NEXMO_API_KEY") ?? "NEXMO_API_KEY";
            var NEXMO_API_SECRET = Environment.GetEnvironmentVariable("NEXMO_API_SECRET") ?? "NEXMO_API_SECRET";

            var credentials = Credentials.FromApiKeyAndSecret(NEXMO_API_KEY, NEXMO_API_SECRET);
            var client = new NexmoClient(credentials);

            var messagesWebhooks = new Dictionary<Webhook.Type, Webhook>();
            messagesWebhooks.Add(
                Webhook.Type.inbound_url, 
                new Webhook { 
                    Address = "https://example.com/webhooks/inbound", 
                    Method = "POST" 
                });
            messagesWebhooks.Add(
                Webhook.Type.status_url, 
                new Webhook { 
                    Address = "https://example.com/webhooks/status", 
                    Method = "POST" 
                });
            var messagesCapability = new Messages(messagesWebhooks);
            var request = new CreateApplicationRequest { 
                Name = APPLICATION_NAME, 
                Capabilities = new ApplicationCapabilities{ Messages = messagesCapability } 
            };
            var response = client.ApplicationClient.CreateApplicaiton(request);

            Console.WriteLine(JsonConvert.SerializeObject(response));

        }
    }
}
