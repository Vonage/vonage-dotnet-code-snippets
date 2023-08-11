using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Meetings.CreateRoom;
using Vonage.Request;

namespace DotnetCliCodeSnippets.Meetings;

public class CreateInstantRoom : ICodeSnippet
{
    public async Task Execute()
    {
        var applicationId = Environment.GetEnvironmentVariable("VONAGE_APP_ID") ?? "VONAGE_APP_ID";
        var privateKeyPath = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var displayName = Environment.GetEnvironmentVariable("ROOM_DISPLAY_NAME") ?? "ROOM_DISPLAY_NAME";
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(applicationId, privateKeyPath);
        var client = new VonageClient(credentials);
        var request = CreateRoomRequest.Build()
            .WithDisplayName(displayName)
            .Create();
        var response = await client.MeetingsClient.CreateRoomAsync(request);
        var message = response.Match(
            success => $"Instant room has been created: {success.Id}",
            failure => $"Room creation failed: {failure.GetFailureMessage()}");
        Console.WriteLine(message);
    }
}