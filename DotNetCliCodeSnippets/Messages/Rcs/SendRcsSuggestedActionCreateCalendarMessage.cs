using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Messages.Rcs;
using Vonage.Request;

namespace DotnetCliCodeSnippets.Messages.Rcs;

public class SendRcsSuggestedActionCreateCalendarMessage : ICodeSnippet
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
                        Text = "Product Launch: Save the date!",
                        Suggestions = new[]
                        {
                            new
                            {
                                Action = new
                                {
                                    Text = "Save to calendar",
                                    PostbackData = "postback_data_1234",
                                    FallbackUrl = "https://www.google.com/calendar",
                                    CreateCalendarEventAction = new
                                    {
                                        StartTime = "2024-06-28T19:00:00Z",
                                        EndTime = "2024-06-28T20:00:00Z",
                                        Title = "Vonage API Product Launch",
                                        Description = "Event to demo Vonage\\'s new and exciting API product",
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