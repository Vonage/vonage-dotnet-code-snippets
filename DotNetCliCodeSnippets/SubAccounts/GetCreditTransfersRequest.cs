using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Request;
using Vonage.SubAccounts.GetTransfers;

namespace DotnetCliCodeSnippets.SubAccounts;

public class GetCreditTransfersRequest : ICodeSnippet
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
        var response = await client.SubAccountsClient.GetCreditTransfersAsync(request);
        var message = response.Match(
            success => $"Credit transfers retrieved - {success.Length}",
            failure => $"Credit transfers failed: {failure.GetFailureMessage()}");
        Console.WriteLine(message);
    }
}