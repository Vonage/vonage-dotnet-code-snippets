using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Request;
using Vonage.SubAccounts.UpdateSubAccount;

namespace DotnetCliCodeSnippets.SubAccounts;

public class SuspendAccountRequest : ICodeSnippet
{
    public async Task Execute()
    {
        var vonageApiKey = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
        var vonageApiSecret = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";
        var subAccountKey = Environment.GetEnvironmentVariable("SUBACCOUNT_KEY") ?? "SUBACCOUNT_KEY";
        var credentials = Credentials.FromApiKeyAndSecret(vonageApiKey, vonageApiSecret);
        var client = new VonageClient(credentials);
        var request = UpdateSubAccountRequest.Build().WithSubAccountKey(subAccountKey)
            .SuspendAccount()
            .Create();
        var response = await client.SubAccountsClient.UpdateSubAccountAsync(request);
        var message = response.Match(
            success => $"SubAccount suspended - {success.ApiKey}",
            failure => $"SubAccount suspension failed: {failure.GetFailureMessage()}");
        Console.WriteLine(message);
    }
}