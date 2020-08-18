using Vonage;
using Vonage.Request;
using Vonage.Applications;
using Vonage.Applications.Capabilities;
using Webhook = Vonage.Common.Webhook;
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
            var VONAGE_API_KEY = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
            var VONAGE_API_SECRET = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";

            var credentials = Credentials.FromApiKeyAndSecret(VONAGE_API_KEY, VONAGE_API_SECRET);
            var client = new VonageClient(credentials);

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
