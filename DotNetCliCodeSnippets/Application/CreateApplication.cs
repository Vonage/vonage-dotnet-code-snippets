#region

using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Vonage;
using Vonage.Applications;
using Vonage.Applications.Capabilities;
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
        var request = new CreateApplicationRequest
        {
            Name = "Code Snippets V2 Application",
            Capabilities = new ApplicationCapabilities
            {
                Messages = Vonage.Applications.Capabilities.Messages.Build()
                    .WithInboundUrl("https://example.com/webhooks/inbound")
                    .WithStatusUrl("https://example.com/webhooks/status"),
                Voice = Vonage.Applications.Capabilities.Voice.Build()
                    .WithAnswerUrl("https://example.com/webhooks/answer", WebhookHttpMethod.Get)
                    .WithEventUrl("https://example.com/webhooks/event", WebhookHttpMethod.Post)
                    .WithFallbackAnswerUrl("https://fallback.example.com/webhooks/answer", WebhookHttpMethod.Get),
                Rtc = Rtc.Build().WithEventUrl("https://example.com/webhooks/event", WebhookHttpMethod.Post)
            }
        };
        var response = await client.ApplicationClient.CreateApplicationAsync(request);
        Console.WriteLine(JsonConvert.SerializeObject(response));
    }
}