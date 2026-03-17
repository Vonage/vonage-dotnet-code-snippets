#region

using System.Threading.Tasks;
using Vonage.IdentityInsights.GetInsights;

#endregion

namespace DotnetCliCodeSnippets.IdentityInsights;

public class GetOriginalCarrierRequest : IdentityInsightBaseRequest, ICodeSnippet
{
    public async Task Execute()
    {
        var request = GetInsightsRequest.Build()
            .WithPhoneNumber(InsightNumber)
            .WithOriginalCarrier()
            .Create();
        var response = await Client.IdentityInsightsClient.GetInsightsAsync(request);
    }
}