using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Request;

namespace DotnetCliCodeSnippets.SubAccounts;

public class CreateSubAccountRequest : ICodeSnippet
{
    public async Task Execute()
    {
        var VONAGE_API_KEY = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
        var VONAGE_API_SECRET = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";
        var NEW_SUBACCOUNT_NAME = Environment.GetEnvironmentVariable("NEW_SUBACCOUNT_NAME") ?? "NEW_SUBACCOUNT_NAME";
        var NEW_SUBACCOUNT_SECRET =
            Environment.GetEnvironmentVariable("NEW_SUBACCOUNT_SECRET") ?? "NEW_SUBACCOUNT_SECRET";
        var credentials = Credentials.FromApiKeyAndSecret(VONAGE_API_KEY, VONAGE_API_SECRET);
        var client = new VonageClient(credentials);
        var request = Vonage.SubAccounts.CreateSubAccount.CreateSubAccountRequest.Build()
            .WithName(NEW_SUBACCOUNT_NAME)
            .WithSecret(NEW_SUBACCOUNT_SECRET)
            .Create();
        var response = await client.SubAccountsClient.CreateSubAccountAsync(request);
        var message = response.Match(
            success => $"SubAccount created - {success.ApiKey}",
            failure => $"SubAccount creation failed: {failure.GetFailureMessage()}");
        Console.WriteLine(message);
    }
}