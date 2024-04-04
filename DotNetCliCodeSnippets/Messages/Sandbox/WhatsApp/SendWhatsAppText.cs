﻿using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Messages.WhatsApp;
using Vonage.Request;

namespace DotnetCliCodeSnippets.Messages.WhatsApp;

public class SendWhatsAppText : ICodeSnippet
{
    public async Task Execute()
    {
        var to = Environment.GetEnvironmentVariable("MESSAGES_SANDBOX_ALLOW_LISTED_TO_NUMBER") ?? "MESSAGES_SANDBOX_ALLOW_LISTED_TO_NUMBER";
        var brandName = Environment.GetEnvironmentVariable("MESSAGES_SANDBOX_WHATSAPP_NUMBER") ?? "MESSAGES_SANDBOX_WHATSAPP_NUMBER";
        var appId = Environment.GetEnvironmentVariable("VONAGE_APP_ID") ?? "VONAGE_APP_ID";
        var privateKeyPath = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";

        var credentials = Credentials.FromAppIdAndPrivateKeyPath(appId, privateKeyPath);

        var vonageClient = new VonageClient(credentials);

        var request = new WhatsAppTextRequest
        {
            To = to,
            From = brandName,
            Text = "A WhatsApp text message sent using the Vonage Messages API via the Messages Sandbox"
        };

        var response = await vonageClient.MessagesClient.SendAsync(request);
        Console.WriteLine($"Message UUID: {response.MessageUuid}");
    }
}