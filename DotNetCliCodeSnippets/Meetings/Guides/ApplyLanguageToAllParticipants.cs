using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Meetings.Common;
using Vonage.Meetings.CreateRoom;
using Vonage.Request;

namespace DotnetCliCodeSnippets.Meetings.Guides;

public class ApplyLanguageToAllParticipants : ICodeSnippet
{
    public async Task Execute()
    {
        var applicationId = Environment.GetEnvironmentVariable("VONAGE_APP_ID") ?? "VONAGE_APP_ID";
        var privateKeyPath = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(applicationId, privateKeyPath);
        var client = new VonageClient(credentials);
        var request = CreateRoomRequest.Build()
            .WithDisplayName("New Meeting Room")
            .WithUserInterfaceSettings(new UiSettings(UiSettings.UserInterfaceLanguage.Es))
            .Create();
        var response = await client.MeetingsClient.CreateRoomAsync(request);
    }
}