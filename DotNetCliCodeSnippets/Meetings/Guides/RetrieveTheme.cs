using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Meetings.GetTheme;
using Vonage.Request;

namespace DotnetCliCodeSnippets.Meetings.Guides;

public class RetrieveTheme : ICodeSnippet
{
    public async Task Execute()
    {
        var applicationId = Environment.GetEnvironmentVariable("VONAGE_APP_ID") ?? "VONAGE_APP_ID";
        var privateKeyPath = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(applicationId, privateKeyPath);
        var client = new VonageClient(credentials);
        var request = GetThemeRequest.Parse(new Guid("ef2b46f3-8ebb-437e-a671-272e4990fbc8"));
        var response = await client.MeetingsClient.GetThemeAsync(request);
    }
}