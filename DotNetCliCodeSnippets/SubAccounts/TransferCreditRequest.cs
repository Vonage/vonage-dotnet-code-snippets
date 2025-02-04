using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Request;
using Vonage.SubAccounts.TransferAmount;

namespace DotnetCliCodeSnippets.SubAccounts;

public class TransferCreditRequest : ICodeSnippet
{
    public async Task Execute()
    {
        var VONAGE_API_KEY = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
        var VONAGE_API_SECRET = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";
        var SUBACCOUNT_KEY = Environment.GetEnvironmentVariable("SUBACCOUNT_KEY") ?? "SUBACCOUNT_KEY";
        var amount =
            decimal.Parse(Environment.GetEnvironmentVariable("AMOUNT") ?? "AMOUNT");
        var credentials = Credentials.FromApiKeyAndSecret(VONAGE_API_KEY, VONAGE_API_SECRET);
        var client = new VonageClient(credentials);
        var request = TransferAmountRequest.Build()
            .WithFrom(VONAGE_API_KEY)
            .WithTo(SUBACCOUNT_KEY)
            .WithAmount(amount)
            .Create();
        var response = await client.SubAccountsClient.TransferCreditAsync(request);
        var message = response.Match(
            success => $"Credit transferred - {success.Id}",
            failure => $"Credit transfer failed: {failure.GetFailureMessage()}");
        Console.WriteLine(message);
    }
}