using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Request;

namespace DotnetCliCodeSnippets.SubAccounts;

public class GetSubAccountRequest : ICodeSnippet
{
    public async Task Execute()
    {
        var vonageApiKey = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
        var vonageApiSecret = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";
        var subAccountKey = Environment.GetEnvironmentVariable("SUBACCOUNT_KEY") ?? "SUBACCOUNT_KEY";
        var credentials = Credentials.FromApiKeyAndSecret(vonageApiKey, vonageApiSecret);
        var client = new VonageClient(credentials);
        var request = Vonage.SubAccounts.GetSubAccount.GetSubAccountRequest.Parse(subAccountKey);
        var response = await client.SubAccountsClient.GetSubAccountAsync(request);
        var message = response.Match(
            success => $"SubAccount retrieved - {success.ApiKey}",
            failure => $"SubAccount retrieval failed: {failure.GetFailureMessage()}");
        Console.WriteLine(message);
    }
}