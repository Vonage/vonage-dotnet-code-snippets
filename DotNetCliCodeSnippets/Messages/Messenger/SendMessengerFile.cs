﻿using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Messages;
using Vonage.Messages.Messenger;
using Vonage.Request;

namespace DotnetCliCodeSnippets.Messages.Messenger;

public class SendMessengerFile : ICodeSnippet
{
    public async Task Execute()
    {
        var to = Environment.GetEnvironmentVariable("TO_NUMBER") ?? "TO_NUMBER";
        var brandName = Environment.GetEnvironmentVariable("VONAGE_BRAND_NAME") ?? "VONAGE_BRAND_NAME";
        var apiKey = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
        var apiSecret = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";

        var credentials = Credentials.FromApiKeyAndSecret(
            apiKey,
            apiSecret
        );

        var vonageClient = new VonageClient(credentials);
        
        var request = new MessengerFileRequest
        {
            To = to,
            From = brandName,
            File = new Attachment
            {
                Url = "https://examples.com/file.pdf"
            }
        };

        var response = await vonageClient.MessagesClient.SendAsync(request);
        Console.WriteLine($"Message UUID: {response.MessageUuid}");
    }
}