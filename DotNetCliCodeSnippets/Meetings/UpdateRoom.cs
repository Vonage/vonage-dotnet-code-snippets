using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Meetings.UpdateRoom;
using Vonage.Request;

namespace DotnetCliCodeSnippets.Meetings;

public class UpdateRoom : ICodeSnippet
{
    public async Task Execute()
    {
        var applicationId = Environment.GetEnvironmentVariable("VONAGE_APP_ID") ?? "VONAGE_APP_ID";
        var privateKeyPath = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var roomId = Guid.Parse(Environment.GetEnvironmentVariable("ROOM_ID") ?? "ROOM_ID");
        var themeId = Environment.GetEnvironmentVariable("THEME_ID") ?? "THEME_ID";
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(applicationId, privateKeyPath);
        var client = new VonageClient(credentials);
        var request = UpdateRoomRequest.Build()
            .WithRoomId(roomId)
            .WithThemeId(themeId)
            .Create();
        var response = await client.MeetingsClient.UpdateRoomAsync(request);
        var message = response.Match(
            success => $"Room updated: {success.Id}",
            failure => $"Room update failed: {failure.GetFailureMessage()}");
        Console.WriteLine(message);
    }
}