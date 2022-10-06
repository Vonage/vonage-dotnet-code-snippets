using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Messages;
using Vonage.Messages.Messenger;
using Vonage.Request;

namespace DotnetCliCodeSnippets.Messages.Messenger;

public class SendMessengerVideo : ICodeSnippet
{
    public async Task Execute()
    {
        var to = Environment.GetEnvironmentVariable("TO_NUMBER") ?? "TO_NUMBER";
        var brandName = Environment.GetEnvironmentVariable("VONAGE_BRAND_NAME") ?? "VONAGE_BRAND_NAME";
        var appId = Environment.GetEnvironmentVariable("VONAGE_APP_ID") ?? "VONAGE_APP_ID";
        var privateKeyPath = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";

        var credentials = Credentials.FromAppIdAndPrivateKeyPath(appId, privateKeyPath);

        var vonageClient = new VonageClient(credentials);
        
        var request = new MessengerVideoRequest
        {
            To = to,
            From = brandName,
            Video = new Attachment
            {
                Url = "https://example.com/video.mp4"
            }
        };

        var response = await vonageClient.MessagesClient.SendAsync(request);
        Console.WriteLine($"Message UUID: {response.MessageUuid}");
    }
}