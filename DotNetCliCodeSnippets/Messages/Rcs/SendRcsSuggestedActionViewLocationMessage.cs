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