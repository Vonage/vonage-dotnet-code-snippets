﻿using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Request;

namespace DotnetCliCodeSnippets.SubAccounts;

public class GetSubAccountsRequest : ICodeSnippet
{
    public async Task Execute()
    {
        var VONAGE_API_KEY = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
        var VONAGE_API_SECRET = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";
        var credentials = Credentials.FromApiKeyAndSecret(VONAGE_API_KEY, VONAGE_API_SECRET);
        var client = new VonageClient(credentials);
        var response = await client.SubAccountsClient.GetSubAccountsAsync();
        var message = response.Match(
            success => $"SubAccounts retrieved - {success.SubAccounts}",
            failure => $"SubAccounts retrieval failed: {failure.GetFailureMessage()}");
        Console.WriteLine(message);
    }
}