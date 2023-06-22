using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Request;
using Vonage.SubAccounts.TransferAmount;

namespace DotnetCliCodeSnippets.SubAccounts;

public class TransferBalanceRequest : ICodeSnippet
{
    public async Task Execute()
    {
        var vonageApiKey = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
        var vonageApiSecret = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";
        var subAccountKey = Environment.GetEnvironmentVariable("SUBACCOUNT_KEY") ?? "SUBACCOUNT_KEY";
        var amount =
            decimal.Parse(Environment.GetEnvironmentVariable("AMOUNT") ?? "AMOUNT");
        var credentials = Credentials.FromApiKeyAndSecret(vonageApiKey, vonageApiSecret);
        var client = new VonageClient(credentials);
        var request = TransferAmountRequest.Build()
            .WithFrom(vonageApiKey)
            .WithTo(subAccountKey)
            .WithAmount(amount)
            .Create();
        var response = await client.SubAccountsClient.TransferBalanceAsync(request);
        var message = response.Match(
            success => $"Balance transferred - {success.Id}",
            failure => $"Balance transfer failed: {failure.GetFailureMessage()}");
        Console.WriteLine(message);
    }
}