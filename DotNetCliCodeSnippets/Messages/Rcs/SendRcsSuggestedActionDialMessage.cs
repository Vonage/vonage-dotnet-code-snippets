#region

using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Messages.Rcs;
using Vonage.Request;

#endregion

namespace DotnetCliCodeSnippets.Messages.Rcs;

public class SendRcsSuggestedActionDialMessage : ICodeSnippet
{
    public async Task Execute()
    {
        var MESSAGES_TO_NUMBER = Environment.GetEnvironmentVariable("MESSAGES_TO_NUMBER") ?? "MESSAGES_TO_NUMBER";
        var RCS_SENDER_ID = Environment.GetEnvironmentVariable("RCS_SENDER_ID") ?? "RCS_SENDER_ID";
        var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable("VONAGE_APPLICATION_ID") ?? "VONAGE_APPLICATION_ID";
        var VONAGE_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_PRIVATE_KEY_PATH);
        var vonageClient = new VonageClient(credentials);
        var request = new RcsCustomRequest
        {
            To = MESSAGES_TO_NUMBER,
            From = RCS_SENDER_ID,
            Custom =
                new
                {
                    ContentMessage = new
                    {
                        Text = "Call us to claim your free gift!",
                        Suggestions = new[]
                        {
                            new
                            {
                                Action = new
                                {
                                    Text = "Call now!",
                                    PostbackData = "postback_data_1234",
                                    FallbackUrl = "https://www.example.com/contact/",
                                    DialAction = new
                                    {
                                        PhoneNumber = "+447900000000"
                                    }
                                }
                            }
                        }
                    }
                }
        };
        var response = await vonageClient.MessagesClient.SendAsync(request);
        Console.WriteLine($"Message UUID: {response.MessageUuid}");
    }
}