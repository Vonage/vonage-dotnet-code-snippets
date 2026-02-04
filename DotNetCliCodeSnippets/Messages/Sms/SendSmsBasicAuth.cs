#region

using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Messages.Sms;
using Vonage.Request;

#endregion

namespace DotnetCliCodeSnippets.Messages.Sms;

public class SendSmsBasicAuth : ICodeSnippet
{
    public async Task Execute()
    {
        var VONAGE_API_KEY = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
        var VONAGE_API_SECRET = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";
        var MESSAGES_TO_NUMBER = Environment.GetEnvironmentVariable("MESSAGES_TO_NUMBER") ?? "MESSAGES_TO_NUMBER";
        var SMS_SENDER_ID = Environment.GetEnvironmentVariable("SMS_SENDER_ID") ?? "SMS_SENDER_ID";
        var credentials = Credentials.FromApiKeyAndSecret(VONAGE_API_KEY, VONAGE_API_SECRET);
        var vonageClient = new VonageClient(credentials);
        var response = await vonageClient.MessagesClient.SendAsync(new SmsRequest
        {
            To = MESSAGES_TO_NUMBER,
            From = SMS_SENDER_ID,
            Text = "This is an SMS sent using the Vonage Messages API."
        });
        Console.WriteLine($"Message UUID: {response.MessageUuid}");
    }
}