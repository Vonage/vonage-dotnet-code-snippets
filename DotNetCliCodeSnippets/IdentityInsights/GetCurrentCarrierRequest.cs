#region

using System.Threading.Tasks;
using Vonage.IdentityInsights.GetInsights;

#endregion

namespace DotnetCliCodeSnippets.IdentityInsights;

public class GetCurrentCarrierRequest : IdentityInsightBaseRequest, ICodeSnippet
{
    public async Task Execute()
    {
        var request = GetInsightsRequest.Build()
            .WithPhoneNumber(InsightNumber)
            .WithCurrentCarrier()
            .Create();
        var response = await Client.IdentityInsightsClient.GetInsightsAsync(request);
    }
}