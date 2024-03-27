using Vonage;
using Vonage.Request;
using Vonage.Applications;
using Vonage.Applications.Capabilities;
using Vonage.Common;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DotnetCliCodeSnippets.Application
{
    public class UpdateApplication : ICodeSnippet
    {
        public async Task Execute()
        {
            var name = Environment.GetEnvironmentVariable("APPLICATION_NAME") ?? "APPLICATION_NAME";
            var vonageApplicationId = Environment.GetEnvironmentVariable("VONAGE_APPLICATION_ID") ?? "VONAGE_APPLICATION_ID";
            var vonageApiKey = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
            var vonageApiSecret = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";

            var credentials = Credentials.FromApiKeyAndSecret(vonageApiKey, vonageApiSecret);
            var client = new VonageClient(credentials);

            var messagesWebhooks = new Dictionary<Webhook.Type, Webhook>();
            messagesWebhooks.Add(
                Webhook.Type.InboundUrl,
                new Webhook
                {
                    Address = "https://example.com/webhooks/inbound",
                    Method = "POST"
                });
            messagesWebhooks.Add(
                Webhook.Type.StatusUrl,
                new Webhook
                {
                    Address = "https://example.com/webhooks/status",
                    Method = "POST"
                });
            var messagesCapability = new Vonage.Applications.Capabilities.Messages(messagesWebhooks);
            var voiceWebhooks = new Dictionary<VoiceWebhookType, Vonage.Applications.Capabilities.Voice.VoiceWebhook>();
            voiceWebhooks.Add(VoiceWebhookType.AnswerUrl, new Vonage.Applications.Capabilities.Voice.VoiceWebhook(new Uri("https://example.com/webhooks/answer"), HttpMethod.Get));
            voiceWebhooks.Add(VoiceWebhookType.EventUrl, new Vonage.Applications.Capabilities.Voice.VoiceWebhook(new Uri("https://example.com/webhooks/events"), HttpMethod.Post));
            var voiceCapability = new Vonage.Applications.Capabilities.Voice
            {
                Webhooks = voiceWebhooks,
            };
            var rtcWebhooks = new Dictionary<Webhook.Type, Webhook>();
            rtcWebhooks.Add(Webhook.Type.EventUrl,
                new Webhook
                {
                    Address = "https://example.com/webhooks/events",
                    Method = "POST"
                });
            var rtcCapability = new Rtc(rtcWebhooks);
            var vbcCapability = new Vbc();
            var request = new CreateApplicationRequest { 
                Name = name,
                Capabilities = new ApplicationCapabilities 
                { 
                    Messages = messagesCapability,
                    Rtc = rtcCapability, 
                    Voice = voiceCapability, 
                    Vbc = vbcCapability 
                } 
            };
            var response = await client.ApplicationClient.UpdateApplicationAsync(vonageApplicationId, request);
            Console.WriteLine(JsonConvert.SerializeObject(response));
        }
    }
}
