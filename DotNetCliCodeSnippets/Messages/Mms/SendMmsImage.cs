using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Messages;
using Vonage.Request;

namespace DotnetCliCodeSnippets.Messages.Mms;

public class SendMmsImage : ICodeSnippet
{
    public async Task Execute()
    {
        var MESSAGES_TO_NUMBER = Environment.GetEnvironmentVariable("MESSAGES_TO_NUMBER") ?? "MESSAGES_TO_NUMBER";
        var MMS_SENDER_ID = Environment.GetEnvironmentVariable("MMS_SENDER_ID") ?? "MMS_SENDER_ID";
        var MESSAGES_IMAGE_URL = Environment.GetEnvironmentVariable("MESSAGES_IMAGE_URL") ?? "MESSAGES_IMAGE_URL";
        var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable("VONAGE_APPLICATION_ID") ?? "VONAGE_APPLICATION_ID";
        var VONAGE_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";

        var credentials = Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_PRIVATE_KEY_PATH);

        var vonageClient = new VonageClient(credentials);
        
        var request = new Vonage.Messages.Mms.MmsImageRequest
        {
            To = MESSAGES_TO_NUMBER,
            From = MMS_SENDER_ID,
            Image = new Attachment
            {
                Url = MESSAGES_IMAGE_URL
            }
        };

        var response = await vonageClient.MessagesClient.SendAsync(request);
        Console.WriteLine($"Message UUID: {response.MessageUuid}");
    }
}