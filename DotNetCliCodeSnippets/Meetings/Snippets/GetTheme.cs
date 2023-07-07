using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Meetings.GetTheme;
using Vonage.Request;

namespace DotnetCliCodeSnippets.Meetings.Snippets;

public class GetTheme : ICodeSnippet
{
    public async Task Execute()
    {
        var applicationId = Environment.GetEnvironmentVariable("VONAGE_APP_ID") ?? "VONAGE_APP_ID";
        var privateKeyPath = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var themeId = Guid.Parse(Environment.GetEnvironmentVariable("THEME_ID") ?? "THEME_ID");
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(applicationId, privateKeyPath);
        var client = new VonageClient(credentials);
        var request = GetThemeRequest.Parse(themeId);
        var response = await client.MeetingsClient.GetThemeAsync(request);
        var message = response.Match(
            success => $"Theme retrieved: {success.ThemeId}",
            failure => $"Theme retrieval failed: {failure.GetFailureMessage()}");
        Console.WriteLine(message);
    }
}