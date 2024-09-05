using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Messages.Rcs;
using Vonage.Request;

namespace DotnetCliCodeSnippets.Messages.Rcs;

public class SendRcsSuggestedActionMultipleMessage : ICodeSnippet
{
    public async Task Execute()
    {
        var to = Environment.GetEnvironmentVariable("TO_NUMBER") ?? "TO_NUMBER";
        var rcsSenderId = Environment.GetEnvironmentVariable("RCS_SENDER_ID") ?? "RCS_SENDER_ID";
        var appId = Environment.GetEnvironmentVariable("VONAGE_APP_ID") ?? "VONAGE_APP_ID";
        var privateKeyPath = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(appId, privateKeyPath);
        var vonageClient = new VonageClient(credentials);
        var request = new RcsCustomRequest
        {
            To = to,
            From = rcsSenderId,
            Custom =
                new
                {
                    ContentMessage = new
                    {
                        Text = "Need some help? Call us now or visit our website for more information.",
                        Suggestions = new object[]
                        {
                            new
                            {
                                Action = new
                                {
                                    Text = "Call us",
                                    PostbackData = "postback_data_1234",
                                    FallbackUrl = "https://www.example.com/contact/",
                                    DialAction = new
                                    {
                                        PhoneNumber = "+447900000000"
                                    }
                                }
                            },
                            new
                            {
                                Action = new
                                {
                                    Text = "Visit site",
                                    PostbackData = "postback_data_1234",
                                    FallbackUrl = "https://www.example.com/contact/",
                                    OpenUrlAction = new
                                    {
                                        Url = "http://example.com/"
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