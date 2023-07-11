using System;
using System.Drawing;
using System.Threading.Tasks;
using Vonage;
using Vonage.Meetings.UpdateTheme;
using Vonage.Request;

namespace DotnetCliCodeSnippets.Meetings.Guides;

public class UpdateTheme : ICodeSnippet
{
    public async Task Execute()
    {
        var applicationId = Environment.GetEnvironmentVariable("VONAGE_APP_ID") ?? "VONAGE_APP_ID";
        var privateKeyPath = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(applicationId, privateKeyPath);
        var client = new VonageClient(credentials);
        var request = UpdateThemeRequest.Build()
            .WithThemeId(new Guid("86da462e-fac4-4f46-87ed-63eafc81be48"))
            .WithColor(Color.FromArgb(255, 18, 246, 78))
            .WithBrandText("Brand")
            .WithShortCompanyUrl(new Uri("short-url", UriKind.Relative))
            .Create();
        var response = await client.MeetingsClient.UpdateThemeAsync(request);
    }
}