using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Meetings.Common;
using Vonage.Meetings.UpdateThemeLogo;
using Vonage.Request;

namespace DotnetCliCodeSnippets.Meetings.Guides;

public class UploadLogos : ICodeSnippet
{
    public async Task Execute()
    {
        var applicationId = Environment.GetEnvironmentVariable("VONAGE_APP_ID") ?? "VONAGE_APP_ID";
        var privateKeyPath = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(applicationId, privateKeyPath);
        var client = new VonageClient(credentials);
        var request = UpdateThemeLogoRequest.Parse(new Guid("00c3efdf-1cd1-45d6-9379-c5420571d654"),
            ThemeLogoType.White, @"C:\image.png");
        var response = await client.MeetingsClient.UpdateThemeLogoAsync(request);
    }
}