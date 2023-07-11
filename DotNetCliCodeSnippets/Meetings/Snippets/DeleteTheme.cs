using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Meetings.DeleteTheme;
using Vonage.Request;

namespace DotnetCliCodeSnippets.Meetings.Snippets;

public class DeleteTheme : ICodeSnippet
{
    public async Task Execute()
    {
        var applicationId = Environment.GetEnvironmentVariable("VONAGE_APP_ID") ?? "VONAGE_APP_ID";
        var privateKeyPath = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var themeId = Guid.Parse(Environment.GetEnvironmentVariable("THEME_ID") ?? "THEME_ID");
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(applicationId, privateKeyPath);
        var client = new VonageClient(credentials);
        var request = DeleteThemeRequest.Build()
            .WithThemeId(themeId)
            .Create();
        var response = await client.MeetingsClient.DeleteThemeAsync(request);
        var message = response.Match(
            success => "Theme deleted",
            failure => $"Theme deletion failed: {failure.GetFailureMessage()}");
        Console.WriteLine(message);
    }
}