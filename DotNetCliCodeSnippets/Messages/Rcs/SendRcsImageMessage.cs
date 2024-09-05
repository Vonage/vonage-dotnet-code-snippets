using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Messages;
using Vonage.Messages.Rcs;
using Vonage.Request;

namespace DotnetCliCodeSnippets.Messages.Rcs;

public class SendRcsImageMessage : ICodeSnippet
{
    public async Task Execute()
    {
        var to = Environment.GetEnvironmentVariable("TO_NUMBER") ?? "TO_NUMBER";
        var rcsSenderId = Environment.GetEnvironmentVariable("RCS_SENDER_ID") ?? "RCS_SENDER_ID";
        var imageUrl = Environment.GetEnvironmentVariable("IMAGE_URL") ?? "IMAGE_URL";
        var appId = Environment.GetEnvironmentVariable("VONAGE_APP_ID") ?? "VONAGE_APP_ID";
        var privateKeyPath = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(appId, privateKeyPath);
        var vonageClient = new VonageClient(credentials);
        var request = new RcsImageRequest()
        {
            To = to,
            From = rcsSenderId,
            Image = new CaptionedAttachment()
            {
                Url = imageUrl,
            }
        };
        var response = await vonageClient.MessagesClient.SendAsync(request);
        Console.WriteLine($"Message UUID: {response.MessageUuid}");
    }
}