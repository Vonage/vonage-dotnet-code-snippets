using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Messages.Messenger;
using Vonage.Request;

namespace DotnetCliCodeSnippets.Messages.Messenger;

public class SendMessengerText : ICodeSnippet
{
    public async Task Execute()
    {
        var messagesSandboxAllowListedFbRecipientId = Environment.GetEnvironmentVariable("MESSAGES_SANDBOX_ALLOW_LISTED_FB_RECIPIENT_ID") ?? "MESSAGES_SANDBOX_ALLOW_LISTED_FB_RECIPIENT_ID";
        var messagesSandboxFbId = Environment.GetEnvironmentVariable("MESSAGES_SANDBOX_FB_ID") ?? "MESSAGES_SANDBOX_FB_ID";
        var appId = Environment.GetEnvironmentVariable("VONAGE_APP_ID") ?? "VONAGE_APP_ID";
        var privateKeyPath = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";

        // Set "Url.Api" to "https://messages-sandbox.nexmo.com" in appsettings.json
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(appId, privateKeyPath);

        var vonageClient = new VonageClient(credentials);
        
        var request = new MessengerTextRequest
        {
            To = messagesSandboxAllowListedFbRecipientId,
            From = messagesSandboxFbId,
            Text = "This is a Facebook Messenger Message sent from the Messages API via the Messages Sandbox"
        };

        var response = await vonageClient.MessagesClient.SendAsync(request);
        Console.WriteLine($"Message UUID: {response.MessageUuid}");
    }
}