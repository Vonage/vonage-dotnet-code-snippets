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
        var vonageApiKey = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
        var vonageApiSecret = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";
        var startDate = DateTimeOffset.Parse(Environment.GetEnvironmentVariable("START_DATE") ?? "START_DATE");
        var credentials = Credentials.FromApiKeyAndSecret(vonageApiKey, vonageApiSecret);
        var client = new VonageClient(credentials);
        var request = GetTransfersRequest.Build()
            .WithStartDate(startDate)
            .Create();
        var response = await client.SubAccountsClient.GetCreditTransfersAsync(request);
        var message = response.Match(
            success => $"Credit transfers retrieved - {success.Length}",
            failure => $"Credit transfers failed: {failure.GetFailureMessage()}");
        Console.WriteLine(message);
    }
}