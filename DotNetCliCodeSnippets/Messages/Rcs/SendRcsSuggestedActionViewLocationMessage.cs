using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Messages.Rcs;
using Vonage.Request;

namespace DotnetCliCodeSnippets.Messages.Rcs;

public class SendRcsSuggestedActionViewLocationMessage: ICodeSnippet
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
                        Text = "Drop by our office!",
                        Suggestions = new[]
                        {
                            new
                            {
                                Action = new
                                {
                                    Text = "View map",
                                    PostbackData = "postback_data_1234",
                                    FallbackUrl = "https://www.google.com/maps/place/Vonage/@51.5230371,-0.0852492,15z",
                                    ViewLocationAction = new
                                    {
                                        LatLong = new
                                        {
                                           Latitude = 51.5230371,
                                           Longitude = -0.0852492  
                                        },
                                        Label = "Vonage London Office"
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