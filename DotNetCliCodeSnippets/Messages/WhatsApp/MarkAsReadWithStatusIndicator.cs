using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Messages.WhatsApp;
using Vonage.Request;

namespace DotnetCliCodeSnippets.Messages.WhatsApp;

public class MarkAsReadWithStatusIndicator : ICodeSnippet
{
    public async Task Execute()
    {
        var MESSAGES_MESSAGE_ID = Environment.GetEnvironmentVariable("MESSAGES_MESSAGE_ID") ?? "MESSAGES_MESSAGE_ID";
        var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable(VonageConstants.ApplicationId) ?? VonageConstants.ApplicationId;
        var VONAGE_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable(VonageConstants.PrivateKeyPath) ?? VonageConstants.PrivateKeyPath;
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_PRIVATE_KEY_PATH);
        var vonageClient = new VonageClient(credentials);
        await vonageClient.MessagesClient.UpdateAsync(WhatsAppUpdateMessageRequest.Build(MESSAGES_MESSAGE_ID, new WhatsAppReplyingIndicator(true)));
    }
}