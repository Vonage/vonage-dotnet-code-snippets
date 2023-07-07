using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Meetings.CreateRoom;
using Vonage.Request;

namespace DotnetCliCodeSnippets.Meetings.Snippets;

public class CreateLongTermRoom  : ICodeSnippet
{
    public async Task Execute()
    {
        var applicationId = Environment.GetEnvironmentVariable("VONAGE_APP_ID") ?? "VONAGE_APP_ID";
        var privateKeyPath = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var displayName = Environment.GetEnvironmentVariable("ROOM_DISPLAY_NAME") ?? "ROOM_DISPLAY_NAME";
        var expirationDate = DateTime.Parse(Environment.GetEnvironmentVariable("EXPIRATION_DATE") ?? "EXPIRATION_DATE");
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(applicationId, privateKeyPath);
        var client = new VonageClient(credentials);
        var request = CreateRoomRequest.Build()
            .WithDisplayName(displayName)
            .AsLongTermRoom(expirationDate)
            .Create();
        var response = await client.MeetingsClient.CreateRoomAsync(request);
        var message = response.Match(
            success => $"Long-term room has been created: {success.Id}",
            failure => $"Room creation failed: {failure.GetFailureMessage()}");
        Console.WriteLine(message);
    }
}