using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Request;
using Vonage.SubAccounts.GetTransfers;

namespace DotnetCliCodeSnippets.SubAccounts;

public class GetBalanceTransfersRequest : ICodeSnippet
{
    public async Task Execute()
    {
        var VONAGE_API_KEY = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
        var VONAGE_API_SECRET = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";
        var START_DATE = DateTimeOffset.Parse(Environment.GetEnvironmentVariable("START_DATE") ?? "START_DATE");
        var credentials = Credentials.FromApiKeyAndSecret(VONAGE_API_KEY, VONAGE_API_SECRET);
        var client = new VonageClient(credentials);
        var request = GetTransfersRequest.Build()
            .WithStartDate(START_DATE)
            .Create();
        var response = await client.SubAccountsClient.GetBalanceTransfersAsync(request);
        var message = response.Match(
            success => $"Balance transfers retrieved - {success.Length}",
            failure => $"Balance transfers failed: {failure.GetFailureMessage()}");
        Console.WriteLine(message);
    }
}