using System;
using System.Drawing;
using System.Threading.Tasks;
using Vonage;
using Vonage.Meetings.Common;
using Vonage.Meetings.UpdateThemeLogo;
using Vonage.Request;

namespace DotnetCliCodeSnippets.Meetings.Snippets;

public class UploadLogo : ICodeSnippet
{
    public async Task Execute()
    {
        var applicationId = Environment.GetEnvironmentVariable("VONAGE_APP_ID") ?? "VONAGE_APP_ID";
        var privateKeyPath = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var themeId = Guid.Parse(Environment.GetEnvironmentVariable("THEME_ID") ?? "THEME_ID");
        var logoType = (ThemeLogoType)Enum.Parse(typeof(ThemeLogoType), Environment.GetEnvironmentVariable("THEME_LOGO_TYPE") ?? "THEME_LOGO_TYPE");
        var filepath = Environment.GetEnvironmentVariable("LOGO_FILEPATH") ?? "LOGO_FILEPATH";
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(applicationId, privateKeyPath);
        var client = new VonageClient(credentials);
        var request = UpdateThemeLogoRequest.Parse(themeId, logoType, filepath);
        var response = await client.MeetingsClient.UpdateThemeLogoAsync(request);
        var message = response.Match(
            success => "Theme logo updated",
            failure => $"Theme logo update failed: {failure.GetFailureMessage()}");
        Console.WriteLine(message);
    }
}