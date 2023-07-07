using System;
using System.Drawing;
using System.Threading.Tasks;
using Vonage;
using Vonage.Meetings.CreateTheme;
using Vonage.Request;

namespace DotnetCliCodeSnippets.Meetings.Guides;

public class CreateTheme : ICodeSnippet
{
    public async Task Execute()
    {
        var applicationId = Environment.GetEnvironmentVariable("VONAGE_APP_ID") ?? "VONAGE_APP_ID";
        var privateKeyPath = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(applicationId, privateKeyPath);
        var client = new VonageClient(credentials);
        var request = CreateThemeRequest.Build()
            .WithBrand("Orange")
            .WithColor(Color.FromArgb(255, 255, 65, 0))
            .WithName("orange-room")
            .Create();
        var response = await client.MeetingsClient.CreateThemeAsync(request);
    }
}