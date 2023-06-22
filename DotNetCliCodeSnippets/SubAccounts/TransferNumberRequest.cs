using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Request;
using Vonage.SubAccounts.GetTransfers;

namespace DotnetCliCodeSnippets.SubAccounts;

public class TransferNumberRequest : ICodeSnippet
{
    public async Task Execute()
    {
        var vonageApiKey = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
        var vonageApiSecret = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";
        var subAccountKey = Environment.GetEnvironmentVariable("SUBACCOUNT_KEY") ?? "SUBACCOUNT_KEY";
        var phoneNumber = Environment.GetEnvironmentVariable("PHONE_NUMBER") ?? "PHONE_NUMBER";
        var country = Environment.GetEnvironmentVariable("COUNTRY") ?? "COUNTRY";
        var credentials = Credentials.FromApiKeyAndSecret(vonageApiKey, vonageApiSecret);
        var client = new VonageClient(credentials);
        var request = Vonage.SubAccounts.TransferNumber.TransferNumberRequest.Build()
            .WithFrom(vonageApiKey)
            .WithTo(subAccountKey)
            .WithNumber(phoneNumber)
            .WithCountry(country)
            .Create();
        var response = await client.SubAccountsClient.TransferNumberAsync(request);
        var message = response.Match(
            success => $"Number transferred - {success.Number}",
            failure => $"Number transfer failed: {failure.GetFailureMessage()}");
        Console.WriteLine(message);
    }
}