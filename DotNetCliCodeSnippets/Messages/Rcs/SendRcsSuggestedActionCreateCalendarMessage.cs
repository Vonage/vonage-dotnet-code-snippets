using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Messages.Rcs;
using Vonage.Messages.Rcs.Suggestions;
using Vonage.Request;

namespace DotnetCliCodeSnippets.Messages.Rcs;

public class SendRcsSuggestedActionCreateCalendarMessage : ICodeSnippet
{
    public async Task Execute()
    {
        var MESSAGES_TO_NUMBER = Environment.GetEnvironmentVariable("MESSAGES_TO_NUMBER") ?? "MESSAGES_TO_NUMBER";
        var RCS_SENDER_ID = Environment.GetEnvironmentVariable("RCS_SENDER_ID") ?? "RCS_SENDER_ID";
        var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable(VonageConstants.ApplicationId) ?? VonageConstants.ApplicationId;
        var VONAGE_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable(VonageConstants.PrivateKeyPath) ?? VonageConstants.PrivateKeyPath;
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_PRIVATE_KEY_PATH);
        var vonageClient = new VonageClient(credentials);
        var request = new RcsTextRequest()
        {
            To = MESSAGES_TO_NUMBER,
            From = RCS_SENDER_ID,
            Text = "Product Launch: Save the date!",
            Suggestions =
            [
                new CreateCalendarEventSuggestion(
                    "Save to calendar",
                        "postback_data_1234",
                        DateTime.Parse("2024-06-28T19:00:00Z"),
                        DateTime.Parse("2024-06-28T20:00:00Z"),
                        "Vonage API Product Launch",
                        "Event to demo a new and exciting Vonage API product")
                    .WithFallbackUrl(new Uri("https://www.google.com/calendar")),
            ]
        };
        var response = await vonageClient.MessagesClient.SendAsync(request);
        Console.WriteLine($"Message UUID: {response.MessageUuid}");
    }
}