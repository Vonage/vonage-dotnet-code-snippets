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
        var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable("VONAGE_APPLICATION_ID") ?? "VONAGE_APPLICATION_ID";
        var VONAGE_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";

        var credentials = Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_PRIVATE_KEY_PATH);

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