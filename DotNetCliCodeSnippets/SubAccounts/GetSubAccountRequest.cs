using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Request;

namespace DotnetCliCodeSnippets.SubAccounts;

public class GetSubAccountRequest : ICodeSnippet
{
    public async Task Execute()
    {
        var VONAGE_API_KEY = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
        var VONAGE_API_SECRET = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";
        var SUBACCOUNT_KEY = Environment.GetEnvironmentVariable("SUBACCOUNT_KEY") ?? "SUBACCOUNT_KEY";
        var credentials = Credentials.FromApiKeyAndSecret(VONAGE_API_KEY, VONAGE_API_SECRET);
        var client = new VonageClient(credentials);
        var request = Vonage.SubAccounts.GetSubAccount.GetSubAccountRequest.Parse(SUBACCOUNT_KEY);
        var response = await client.SubAccountsClient.GetSubAccountAsync(request);
        var message = response.Match(
            success => $"SubAccount retrieved - {success.ApiKey}",
            failure => $"SubAccount retrieval failed: {failure.GetFailureMessage()}");
        Console.WriteLine(message);
    }
}