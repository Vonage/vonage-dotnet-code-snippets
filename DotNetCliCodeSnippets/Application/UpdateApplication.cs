using Vonage;
using Vonage.Request;
using Vonage.Applications;
using Vonage.Applications.Capabilities;
using Webhook = Vonage.Common.Webhook;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DotnetCliCodeSnippets.Application
{
    public class UpdateApplication : ICodeSnippet
    {
        public void Execute()
        {
            var APPLICATION_NAME = Environment.GetEnvironmentVariable("APPLICATION_NAME") ?? "APPLICATION_NAME";
            var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable("VONAGE_APPLICATION_ID") ?? "VONAGE_APPLICATION_ID";
            var VONAGE_API_KEY = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
            var VONAGE_API_SECRET = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";

            var credentials = Credentials.FromApiKeyAndSecret(VONAGE_API_KEY, VONAGE_API_SECRET);
            var client = new VonageClient(credentials);

            var messagesWebhooks = new Dictionary<Webhook.Type, Webhook>();
            messagesWebhooks.Add(
                Webhook.Type.inbound_url,
                new Webhook
                {
                    Address = "https://example.com/webhooks/inbound",
                    Method = "POST"
                });
            messagesWebhooks.Add(
                Webhook.Type.status_url,
                new Webhook
                {
                    Address = "https://example.com/webhooks/status",
                    Method = "POST"
                });
            var messagesCapability = new Messages(messagesWebhooks);
            var voiceWebhooks = new Dictionary<Webhook.Type, Webhook>();
            voiceWebhooks.Add(Webhook.Type.answer_url,
                new Webhook
                {
                    Address = "https://example.com/webhooks/answer",
                    Method = "GET"
                });
            voiceWebhooks.Add(Webhook.Type.event_url,
                new Webhook
                {
                    Address = "https://example.com/webhooks/events",
                    Method = "POST"
                });
            var voiceCapability = new Vonage.Applications.Capabilities.Voice(voiceWebhooks);
            var rtcWebhooks = new Dictionary<Webhook.Type, Webhook>();
            rtcWebhooks.Add(Webhook.Type.event_url,
                new Webhook
                {
                    Address = "https://example.com/webhooks/events",
                    Method = "POST"
                });
            var rtcCapability = new Rtc(rtcWebhooks);
            var vbcCapability = new Vbc();
            var request = new CreateApplicationRequest { 
                Name = APPLICATION_NAME,
                Capabilities = new ApplicationCapabilities 
                { 
                    Messages = messagesCapability,
                    Rtc = rtcCapability, 
                    Voice = voiceCapability, 
                    Vbc = vbcCapability 
                } 
            };
            var response = client.ApplicationClient.UpdateApplication(VONAGE_APPLICATION_ID, request);
            Console.WriteLine(JsonConvert.SerializeObject(response));
        }
    }
}
