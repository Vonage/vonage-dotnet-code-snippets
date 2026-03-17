#region

using System;
using Vonage;
using Vonage.Request;

#endregion

namespace DotnetCliCodeSnippets.IdentityInsights;

public abstract class IdentityInsightBaseRequest
{
    protected readonly VonageClient Client;
    protected readonly string InsightNumber;
    protected readonly int SimSwapPeriod;

    internal IdentityInsightBaseRequest()
    {
        var applicationId = Environment.GetEnvironmentVariable(VonageConstants.ApplicationId) ??
                            VonageConstants.ApplicationId;
        var privateKeyPath = Environment.GetEnvironmentVariable(VonageConstants.PrivateKeyPath) ??
                             VonageConstants.PrivateKeyPath;
        InsightNumber = Environment.GetEnvironmentVariable(Constants.InsightNumber) ?? Constants.InsightNumber;
        SimSwapPeriod =
            int.Parse(Environment.GetEnvironmentVariable(Constants.SimSwapPeriod) ?? Constants.SimSwapPeriod);
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(applicationId, privateKeyPath);
        Client = new VonageClient(credentials);
    }
}