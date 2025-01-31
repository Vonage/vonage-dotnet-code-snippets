#region

using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Messages.Rcs;
using Vonage.Request;

#endregion

namespace DotnetCliCodeSnippets.Messages.Rcs;

public class RevokeMessage : ICodeSnippet
{
    public async Task Execute()
    {
        var MESSAGES_MESSAGE_ID = Environment.GetEnvironmentVariable("MESSAGES_MESSAGE_ID") ?? "MESSAGES_MESSAGE_ID";
        var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable("VONAGE_APPLICATION_ID") ?? "VONAGE_APPLICATION_ID";
        var VONAGE_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_PRIVATE_KEY_PATH);
        var vonageClient = new VonageClient(credentials);
        await vonageClient.MessagesClient.UpdateAsync(RcsUpdateMessageRequest.Build(MESSAGES_MESSAGE_ID));
    }
}