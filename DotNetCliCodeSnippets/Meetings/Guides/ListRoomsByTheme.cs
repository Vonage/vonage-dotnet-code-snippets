using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Meetings.GetRoomsByTheme;
using Vonage.Request;

namespace DotnetCliCodeSnippets.Meetings.Guides;

public class ListRoomsByTheme : ICodeSnippet
{
    public async Task Execute()
    {
        var applicationId = Environment.GetEnvironmentVariable("VONAGE_APP_ID") ?? "VONAGE_APP_ID";
        var privateKeyPath = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(applicationId, privateKeyPath);
        var client = new VonageClient(credentials);
        var request = GetRoomsByThemeRequest.Build()
            .WithThemeId(new Guid("e8b1d80b-8f78-4578-94f2-328596e01387"))
            .Create();
        var response = await client.MeetingsClient.GetRoomsByThemeAsync(request);
        var message = response.Match(
            success => $"Rooms retrieved: {success.Rooms}",
            failure => $"Rooms retrieval failed: {failure.GetFailureMessage()}");
        Console.WriteLine(message);
    }
}