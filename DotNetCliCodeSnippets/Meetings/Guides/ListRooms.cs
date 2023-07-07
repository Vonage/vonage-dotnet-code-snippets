using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Meetings.GetRooms;
using Vonage.Request;

namespace DotnetCliCodeSnippets.Meetings.Guides;

public class ListRooms : ICodeSnippet
{
    public async Task Execute()
    {
        var applicationId = Environment.GetEnvironmentVariable("VONAGE_APP_ID") ?? "VONAGE_APP_ID";
        var privateKeyPath = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(applicationId, privateKeyPath);
        var client = new VonageClient(credentials);
        var request = GetRoomsRequest.Build().Create();
        var response = await client.MeetingsClient.GetRoomsAsync(request);
    }
}