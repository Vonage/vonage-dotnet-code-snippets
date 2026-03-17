using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Messages;
using Vonage.Messages.Viber;
using Vonage.Request;

namespace DotnetCliCodeSnippets.Messages.Sms;

public class SendViberImage : ICodeSnippet
{
    public async Task Execute()
    {
        var MESSAGES_TO_NUMBER = Environment.GetEnvironmentVariable("MESSAGES_TO_NUMBER") ?? "MESSAGES_TO_NUMBER";
        var VIBER_SENDER_ID = Environment.GetEnvironmentVariable("VIBER_SENDER_ID") ?? "VIBER_SENDER_ID";
        var MESSAGES_IMAGE_URL = Environment.GetEnvironmentVariable("MESSAGES_IMAGE_URL") ?? "MESSAGES_IMAGE_URL";
        var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable(VonageConstants.ApplicationId) ?? VonageConstants.ApplicationId;
        var VONAGE_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable(VonageConstants.PrivateKeyPath) ?? VonageConstants.PrivateKeyPath;
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_PRIVATE_KEY_PATH);
        var vonageClient = new VonageClient(credentials);
        var request = new ViberImageRequest
        {
            To = MESSAGES_TO_NUMBER,
            From = VIBER_SENDER_ID,
            Image = new CaptionedAttachment
            {
                Url = MESSAGES_IMAGE_URL
            },
        };
        var response = await vonageClient.MessagesClient.SendAsync(request);
        Console.WriteLine($"Message UUID: {response.MessageUuid}");
    }
}