using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Request;

namespace DotnetCliCodeSnippets.SubAccounts;

public class CreateSubAccountRequest : ICodeSnippet
{
    public async Task Execute()
    {
        var vonageApiKey = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
        var vonageApiSecret = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";
        var newSubAccountName = Environment.GetEnvironmentVariable("NEW_SUBACCOUNT_NAME") ?? "NEW_SUBACCOUNT_NAME";
        var newSubAccountSecret =
            Environment.GetEnvironmentVariable("NEW_SUBACCOUNT_SECRET") ?? "NEW_SUBACCOUNT_SECRET";
        var credentials = Credentials.FromApiKeyAndSecret(vonageApiKey, vonageApiSecret);
        var client = new VonageClient(credentials);
        var request = Vonage.SubAccounts.CreateSubAccount.CreateSubAccountRequest.Build()
            .WithName(newSubAccountName)
            .WithSecret(newSubAccountSecret)
            .Create();
        var response = await client.SubAccountsClient.CreateSubAccountAsync(request);
        var message = response.Match(
            success => $"SubAccount created - {success.ApiKey}",
            failure => $"SubAccount creation failed: {failure.GetFailureMessage()}");
        Console.WriteLine(message);
    }
}