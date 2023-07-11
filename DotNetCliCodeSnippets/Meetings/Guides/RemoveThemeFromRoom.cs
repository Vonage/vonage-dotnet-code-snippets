using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Meetings.UpdateRoom;
using Vonage.Request;

namespace DotnetCliCodeSnippets.Meetings.Guides;

public class RemoveThemeFromRoom : ICodeSnippet
{
    public async Task Execute()
    {
        var applicationId = Environment.GetEnvironmentVariable("VONAGE_APP_ID") ?? "VONAGE_APP_ID";
        var privateKeyPath = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(applicationId, privateKeyPath);
        var client = new VonageClient(credentials);
        var request = UpdateRoomRequest.Build()
            .WithRoomId(new Guid("9f6fe8ae-3458-4a72-b532-8276d5533e97"))
            .WithThemeId(null)
            .Create();
        var response = await client.MeetingsClient.UpdateRoomAsync(request);
    }
}