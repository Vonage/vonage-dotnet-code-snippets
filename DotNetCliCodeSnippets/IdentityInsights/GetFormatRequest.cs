using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.IdentityInsights.GetInsights;
using Vonage.Request;

namespace DotnetCliCodeSnippets.IdentityInsights;

public class GetFormatRequest : IdentityInsightBaseRequest, ICodeSnippet
{
    public async Task Execute()
    {
        var request = GetInsightsRequest.Build()
            .WithPhoneNumber(InsightNumber)
            .WithFormat()
            .Create();
        var response = await Client.IdentityInsightsClient.GetInsightsAsync(request);
    }
}