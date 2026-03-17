#region

using System.Threading.Tasks;
using Vonage.IdentityInsights.GetInsights;

#endregion

namespace DotnetCliCodeSnippets.IdentityInsights;

public class GetSimSwapStatusRequest : IdentityInsightBaseRequest, ICodeSnippet
{
    public async Task Execute()
    {
        var request = GetInsightsRequest.Build()
            .WithPhoneNumber(InsightNumber)
            .WithPurpose("FraudPreventionAndDetection")
            .WithSimSwap(new SimSwapRequest(SimSwapPeriod))
            .Create();
        var response = await Client.IdentityInsightsClient.GetInsightsAsync(request);
    }
}