using Nexmo.Api;
using Nexmo.Api.Request;
using Nexmo.Api.Applications;
using Nexmo.Api.Applications.Capabilities;
using Webhook = Nexmo.Api.Common.Webhook;
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
            var NEXMO_APPLICATION_ID = Environment.GetEnvironmentVariable("NEXMO_APPLICATION_ID") ?? "NEXMO_APPLICATION_ID";
            var NEXMO_API_KEY = Environment.GetEnvironmentVariable("NEXMO_API_KEY") ?? "NEXMO_API_KEY";
            var NEXMO_API_SECRET = Environment.GetEnvironmentVariable("NEXMO_API_SECRET") ?? "NEXMO_API_SECRET";

            var credentials = Credentials.FromApiKeyAndSecret(NEXMO_API_KEY, NEXMO_API_SECRET);
            var client = new NexmoClient(credentials);

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
            var voiceCapability = new Nexmo.Api.Applications.Capabilities.Voice(voiceWebhooks);
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
            var response = client.ApplicationClient.UpdateApplication(NEXMO_APPLICATION_ID, request);
            Console.WriteLine(JsonConvert.SerializeObject(response));
        }
    }
}
