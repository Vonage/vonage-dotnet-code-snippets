using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Messages.WhatsApp;
using Vonage.Request;

namespace DotnetCliCodeSnippets.Messages.WhatsApp;

public class MarkAsRead : ICodeSnippet
{
    public async Task Execute()
    {
        var messageUuid = Environment.GetEnvironmentVariable("MESSAGE_UUID") ?? "MESSAGE_UUID";
        var appId = Environment.GetEnvironmentVariable("VONAGE_APP_ID") ?? "VONAGE_APP_ID";
        var privateKeyPath = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(appId, privateKeyPath);
        var vonageClient = new VonageClient(credentials);
        await vonageClient.MessagesClient.UpdateAsync(WhatsAppUpdateMessageRequest.Build(messageUuid));
    }
}