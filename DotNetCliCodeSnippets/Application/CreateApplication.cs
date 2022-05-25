using Vonage;
using Vonage.Request;
using Vonage.Applications;
using Vonage.Applications.Capabilities;
using Webhook = Vonage.Common.Webhook;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DotnetCliCodeSnippets.Application
{
    public class CreateApplication : ICodeSnippet
    {
        public async Task Execute()
        {
            var applicationName = Environment.GetEnvironmentVariable("APPLICATION_NAME") ?? "APPLICATION_NAME";
            var vonageApiKey = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
            var vonageApiSecret = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";

            var credentials = Credentials.FromApiKeyAndSecret(vonageApiKey, vonageApiSecret);
            var client = new VonageClient(credentials);

            var messagesWebhooks = new Dictionary<Webhook.Type, Webhook>();
            messagesWebhooks.Add(
                Webhook.Type.InboundUrl, 
                new Webhook { 
                    Address = "https://example.com/webhooks/inbound", 
                    Method = "POST" 
                });
            messagesWebhooks.Add(
                Webhook.Type.StatusUrl, 
                new Webhook { 
                    Address = "https://example.com/webhooks/status", 
                    Method = "POST" 
                });
            var messagesCapability = new Vonage.Applications.Capabilities.Messages(messagesWebhooks);
            var request = new CreateApplicationRequest { 
                Name = applicationName, 
                Capabilities = new ApplicationCapabilities{ Messages = messagesCapability } 
            };
            var response = await client.ApplicationClient.CreateApplicaitonAsync(request);

            Console.WriteLine(JsonConvert.SerializeObject(response));

        }
    }
}
