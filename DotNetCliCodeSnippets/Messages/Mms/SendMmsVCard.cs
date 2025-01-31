using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Messages;
using Vonage.Request;

namespace DotnetCliCodeSnippets.Messages.Mms;

public class SendMmsVCard : ICodeSnippet
{
    public async Task Execute()
    {
        var MESSAGES_TO_NUMBER = Environment.GetEnvironmentVariable("MESSAGES_TO_NUMBER") ?? "MESSAGES_TO_NUMBER";
        var MMS_SENDER_ID = Environment.GetEnvironmentVariable("MMS_SENDER_ID") ?? "MMS_SENDER_ID";
        var MESSAGES_VCARD_URL = Environment.GetEnvironmentVariable("MESSAGES_VCARD_URL") ?? "MESSAGES_VCARD_URL";
        var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable("VONAGE_APPLICATION_ID") ?? "VONAGE_APPLICATION_ID";
        var VONAGE_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";

        var credentials = Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_PRIVATE_KEY_PATH);

        var vonageClient = new VonageClient(credentials);

        var request = new Vonage.Messages.Mms.MmsVcardRequest()
        {
            To = MESSAGES_TO_NUMBER,
            From = MMS_SENDER_ID,
            Vcard = new Attachment
            {
                Url = MESSAGES_VCARD_URL
            }
        };

        var response = await vonageClient.MessagesClient.SendAsync(request);
        Console.WriteLine($"Message UUID: {response.MessageUuid}");
    }
}