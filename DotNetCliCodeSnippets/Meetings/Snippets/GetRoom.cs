using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Meetings.GetRoom;
using Vonage.Request;

namespace DotnetCliCodeSnippets.Meetings.Snippets;

public class GetRoom : ICodeSnippet
{
    public async Task Execute()
    {
        var applicationId = Environment.GetEnvironmentVariable("VONAGE_APP_ID") ?? "VONAGE_APP_ID";
        var privateKeyPath = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var roomId = Guid.Parse(Environment.GetEnvironmentVariable("ROOM_ID") ?? "ROOM_ID");
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(applicationId, privateKeyPath);
        var client = new VonageClient(credentials);
        var request = GetRoomRequest.Parse(roomId);
        var response = await client.MeetingsClient.GetRoomAsync(request);
        var message = response.Match(
            success => $"Room retrieved: {success.Id}",
            failure => $"Room retrieval failed: {failure.GetFailureMessage()}");
        Console.WriteLine(message);
    }
}