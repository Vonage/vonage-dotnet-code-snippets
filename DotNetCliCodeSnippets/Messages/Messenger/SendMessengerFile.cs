using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Messages;
using Vonage.Messages.Messenger;
using Vonage.Request;

namespace DotnetCliCodeSnippets.Messages.Messenger;

public class SendMessengerFile : ICodeSnippet
{
    public async Task Execute()
    {
        var MESSENGER_RECIPIENT_ID = Environment.GetEnvironmentVariable("MESSENGER_RECIPIENT_ID") ?? "MESSENGER_RECIPIENT_ID";
        var MESSENGER_SENDER_ID = Environment.GetEnvironmentVariable("MESSENGER_SENDER_ID") ?? "MESSENGER_SENDER_ID";
        var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable(VonageConstants.ApplicationId) ?? VonageConstants.ApplicationId;
        var VONAGE_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable(VonageConstants.PrivateKeyPath) ?? VonageConstants.PrivateKeyPath;
        var MESSAGES_FILE_URL = Environment.GetEnvironmentVariable("MESSAGES_FILE_URL") ?? "MESSAGES_FILE_URL";
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_PRIVATE_KEY_PATH);
        var vonageClient = new VonageClient(credentials);
        var request = new MessengerFileRequest
        {
            To = MESSENGER_RECIPIENT_ID,
            From = MESSENGER_SENDER_ID,
            File = new Attachment
            {
                Url = MESSAGES_FILE_URL
            }
        };
        var response = await vonageClient.MessagesClient.SendAsync(request);
        Console.WriteLine($"Message UUID: {response.MessageUuid}");
    }
}