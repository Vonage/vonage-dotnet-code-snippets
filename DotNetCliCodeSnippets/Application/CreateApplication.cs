#region

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Vonage;
using Vonage.Applications;
using Vonage.Applications.Capabilities;
using Vonage.Common;
using Vonage.Request;

#endregion

namespace DotnetCliCodeSnippets.Application;

public class CreateApplication : ICodeSnippet
{
    public async Task Execute()
    {
        var VONAGE_API_KEY = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
        var VONAGE_API_SECRET = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";
        var credentials = Credentials.FromApiKeyAndSecret(VONAGE_API_KEY, VONAGE_API_SECRET);
        var client = new VonageClient(credentials);
        var messagesCapability = new Vonage.Applications.Capabilities.Messages(new Dictionary<Webhook.Type, Webhook>()
        {
            { Webhook.Type.InboundUrl, new Webhook { Address = "https://example.com/webhooks/inbound", Method = "POST" } },
            { Webhook.Type.StatusUrl, new Webhook { Address = "https://example.com/webhooks/status", Method = "POST" } }
        });
        var voiceCapability = new Vonage.Applications.Capabilities.Voice
        {
            Webhooks = new Dictionary<VoiceWebhookType, Vonage.Applications.Capabilities.Voice.VoiceWebhook>
            {
                {
                    VoiceWebhookType.AnswerUrl,
                    new Vonage.Applications.Capabilities.Voice.VoiceWebhook(
                        new Uri("https://example.com/webhooks/answer"), HttpMethod.Get)
                },
                {
                    VoiceWebhookType.FallbackAnswerUrl,
                    new Vonage.Applications.Capabilities.Voice.VoiceWebhook(
                        new Uri("https://fallback.example.com/webhooks/answer"), HttpMethod.Get)
                },
                {
                    VoiceWebhookType.EventUrl,
                    new Vonage.Applications.Capabilities.Voice.VoiceWebhook(
                        new Uri("https://example.com/webhooks/event"), HttpMethod.Post)
                }
            }
        };
        var rtcCapability = new Rtc(new Dictionary<Webhook.Type, Webhook>
        {
            { Webhook.Type.EventUrl, new Webhook { Address = "https://example.com/webhooks/event", Method = "POST" } }
        });
        var request = new CreateApplicationRequest
        {
            Name = "Code Snippets V2 Application",
            Capabilities = new ApplicationCapabilities
            {
                Messages = messagesCapability,
                Voice = voiceCapability,
                Rtc = rtcCapability
            }
        };
        var response = await client.ApplicationClient.CreateApplicationAsync(request);
        Console.WriteLine(JsonConvert.SerializeObject(response));
    }
}