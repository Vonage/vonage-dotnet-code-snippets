#region

using System;
using Vonage;
using Vonage.Request;

#endregion

namespace DotnetCliCodeSnippets.Reports;

public abstract class ReportBaseRequest
{
    protected readonly VonageClient Client;

    internal ReportBaseRequest()
    {
        var VONAGE_API_KEY = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
        var VONAGE_API_SECRET = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";
        var credentials = Credentials.FromApiKeyAndSecret(VONAGE_API_KEY, VONAGE_API_SECRET);
        Client = new VonageClient(credentials);
    }
}