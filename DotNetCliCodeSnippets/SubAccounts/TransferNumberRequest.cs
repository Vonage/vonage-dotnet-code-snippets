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
        var VONAGE_API_KEY = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
        var VONAGE_API_SECRET = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";
        var SUBACCOUNT_KEY = Environment.GetEnvironmentVariable("SUBACCOUNT_KEY") ?? "SUBACCOUNT_KEY";
        var VONAGE_NUMBER = Environment.GetEnvironmentVariable("PHONE_NUMBER") ?? "PHONE_NUMBER";
        var COUNTRY_CODE = Environment.GetEnvironmentVariable("COUNTRY_CODE") ?? "COUNTRY_CODE";
        var credentials = Credentials.FromApiKeyAndSecret(VONAGE_API_KEY, VONAGE_API_SECRET);
        var client = new VonageClient(credentials);
        var request = Vonage.SubAccounts.TransferNumber.TransferNumberRequest.Build()
            .WithFrom(VONAGE_API_KEY)
            .WithTo(SUBACCOUNT_KEY)
            .WithNumber(VONAGE_NUMBER)
            .WithCountry(COUNTRY_CODE)
            .Create();
        var response = await client.SubAccountsClient.TransferNumberAsync(request);
        var message = response.Match(
            success => $"Number transferred - {success.Number}",
            failure => $"Number transfer failed: {failure.GetFailureMessage()}");
        Console.WriteLine(message);
    }
}