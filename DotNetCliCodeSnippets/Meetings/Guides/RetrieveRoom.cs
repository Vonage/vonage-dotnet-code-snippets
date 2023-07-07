using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Meetings.GetRoom;
using Vonage.Request;

namespace DotnetCliCodeSnippets.Meetings.Guides;

public class RetrieveRoom : ICodeSnippet
{
    public async Task Execute()
    {
        var applicationId = Environment.GetEnvironmentVariable("VONAGE_APP_ID") ?? "VONAGE_APP_ID";
        var privateKeyPath = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(applicationId, privateKeyPath);
        var client = new VonageClient(credentials);
        var request = GetRoomRequest.Parse(new Guid("9f6fe8ae-3458-4a72-b532-8276d5533e97"));
        var response = await client.MeetingsClient.GetRoomAsync(request);
    }
}