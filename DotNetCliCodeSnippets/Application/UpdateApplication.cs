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

public class UpdateApplication : ICodeSnippet
{
    public async Task Execute()
    {
        var VONAGE_API_KEY = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
        var VONAGE_API_SECRET = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";
        var VONAGE_APPLICATION_ID =
            Environment.GetEnvironmentVariable("VONAGE_APPLICATION_ID") ?? "VONAGE_APPLICATION_ID";
        var credentials = Credentials.FromApiKeyAndSecret(VONAGE_API_KEY, VONAGE_API_SECRET);
        var client = new VonageClient(credentials);
        var request = new CreateApplicationRequest
        {
            Name = "New App Name",
            Capabilities = new ApplicationCapabilities
            {
                Messages = Vonage.Applications.Capabilities.Messages.Build()
                    .WithInboundUrl("https://example.com/webhooks/inbound")
                    .WithStatusUrl("https://example.com/webhooks/status"),
                Rtc = Rtc.Build().WithEventUrl("https://example.com/webhooks/events", WebhookHttpMethod.Post),
                Voice = Vonage.Applications.Capabilities.Voice.Build()
                    .WithAnswerUrl("https://example.com/webhooks/answer", WebhookHttpMethod.Get)
                    .WithEventUrl("https://example.com/webhooks/events", WebhookHttpMethod.Post),
                Vbc = Vbc.Build()
            }
        };
        var response = await client.ApplicationClient.UpdateApplicationAsync(VONAGE_APPLICATION_ID, request);
        Console.WriteLine(JsonConvert.SerializeObject(response));
    }
}