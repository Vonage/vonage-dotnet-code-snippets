using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Messages;
using Vonage.Request;

namespace DotnetCliCodeSnippets.Messages.Mms;

public class SendMmsAudio : ICodeSnippet
{
    public async Task Execute()
    {
        var to = Environment.GetEnvironmentVariable("TO_NUMBER") ?? "TO_NUMBER";
        var brandName = Environment.GetEnvironmentVariable("VONAGE_BRAND_NAME") ?? "VONAGE_BRAND_NAME";
        var appId = Environment.GetEnvironmentVariable("VONAGE_APP_ID") ?? "VONAGE_APP_ID";
        var privateKeyPath = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";

        var credentials = Credentials.FromAppIdAndPrivateKeyPath(appId, privateKeyPath);

        var vonageClient = new VonageClient(credentials);
        
        var request = new Vonage.Messages.Mms.MmsAudioRequest
        {
            To = to,
            From = brandName,
            Audio = new CaptionedAttachment
            {
                Caption = "My music",
                Url = "https://file-examples.com/storage/fe6bd68931628d5b79b8f47/2017/11/file_example_MP3_700KB.mp3"
            }
        };

        var response = await vonageClient.MessagesClient.SendAsync(request);
        Console.WriteLine($"Message UUID: {response.MessageUuid}");
    }
}