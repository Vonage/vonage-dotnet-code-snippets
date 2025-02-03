using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Messages;
using Vonage.Messages.WhatsApp;
using Vonage.Request;

namespace DotnetCliCodeSnippets.Messages.WhatsApp;

public class SendWhatsAppFile : ICodeSnippet
{
    public async Task Execute()
    {
        var MESSAGES_TO_NUMBER = Environment.GetEnvironmentVariable("MESSAGES_TO_NUMBER") ?? "MESSAGES_TO_NUMBER";
        var WHATSAPP_SENDER_ID = Environment.GetEnvironmentVariable("WHATSAPP_SENDER_ID") ?? "WHATSAPP_SENDER_ID";
        var MESSAGES_FILE_URL = Environment.GetEnvironmentVariable("MESSAGES_FILE_URL") ?? "MESSAGES_FILE_URL";
        var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable("VONAGE_APPLICATION_ID") ?? "VONAGE_APPLICATION_ID";
        var VONAGE_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_PRIVATE_KEY_PATH);
        var vonageClient = new VonageClient(credentials);
        var request = new WhatsAppFileRequest
        {
            To = MESSAGES_TO_NUMBER,
            From = WHATSAPP_SENDER_ID,
            File = new CaptionedAttachment
            {
                Caption = "Work document",
                Url = MESSAGES_FILE_URL
            }
        };
        var response = await vonageClient.MessagesClient.SendAsync(request);
        Console.WriteLine($"Message UUID: {response.MessageUuid}");
    }
}