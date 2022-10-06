using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Messages.Viber;
using Vonage.Request;

namespace DotnetCliCodeSnippets.Messages.Sms;

public class SendViberText : ICodeSnippet
{
    public async Task Execute()
    {
        var to = Environment.GetEnvironmentVariable("TO_NUMBER") ?? "TO_NUMBER";
        var brandName = Environment.GetEnvironmentVariable("VONAGE_BRAND_NAME") ?? "VONAGE_BRAND_NAME";
        var appId = Environment.GetEnvironmentVariable("VONAGE_APP_ID") ?? "VONAGE_APP_ID";
        var privateKeyPath = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";

        var credentials = Credentials.FromAppIdAndPrivateKeyPath(appId, privateKeyPath);

        var vonageClient = new VonageClient(credentials);
        
        var request = new ViberTextRequest
        {
            To = to,
            From = brandName,
            Text = "An SMS sent using the Vonage Messages API"
        };

        var response = await vonageClient.MessagesClient.SendAsync(request);
        Console.WriteLine($"Message UUID: {response.MessageUuid}");
    }
}