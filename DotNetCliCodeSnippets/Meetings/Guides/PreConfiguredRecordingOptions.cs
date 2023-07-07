using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Meetings.Common;
using Vonage.Meetings.CreateRoom;
using Vonage.Request;

namespace DotnetCliCodeSnippets.Meetings.Guides;

public class PreConfiguredRecordingOptions : ICodeSnippet
{
    public async Task Execute()
    {
        var applicationId = Environment.GetEnvironmentVariable("VONAGE_APP_ID") ?? "VONAGE_APP_ID";
        var privateKeyPath = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var expirationDate = DateTime.Parse(Environment.GetEnvironmentVariable("EXPIRATION_DATE") ?? "EXPIRATION_DATE");
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(applicationId, privateKeyPath);
        var client = new VonageClient(credentials);
        var request = CreateRoomRequest.Build()
            .WithDisplayName("New Meeting Room")
            .AsLongTermRoom(expirationDate)
            .WithRecordingOptions(new Room.RecordingOptions {AutoRecord = true, RecordOnlyOwner = true})
            .Create();
        var response = await client.MeetingsClient.CreateRoomAsync(request);
    }
}