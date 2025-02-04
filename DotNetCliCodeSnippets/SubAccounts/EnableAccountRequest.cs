using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Request;
using Vonage.SubAccounts.UpdateSubAccount;

namespace DotnetCliCodeSnippets.SubAccounts;

public class EnableAccountRequest : ICodeSnippet
{
    public async Task Execute()
    {
        var VONAGE_API_KEY = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
        var VONAGE_API_SECRET = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";
        var SUBACCOUNT_KEY = Environment.GetEnvironmentVariable("SUBACCOUNT_KEY") ?? "SUBACCOUNT_KEY";
        var credentials = Credentials.FromApiKeyAndSecret(VONAGE_API_KEY, VONAGE_API_SECRET);
        var client = new VonageClient(credentials);
        var request = UpdateSubAccountRequest.Build().WithSubAccountKey(SUBACCOUNT_KEY)
            .EnableAccount()
            .Create();
        var response = await client.SubAccountsClient.UpdateSubAccountAsync(request);
        var message = response.Match(
            success => $"SubAccount enabled - {success.ApiKey}",
            failure => $"SubAccount activation failed: {failure.GetFailureMessage()}");
        Console.WriteLine(message);
    }
}