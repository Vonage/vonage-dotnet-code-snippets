﻿using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Messages.WhatsApp;
using Vonage.Request;

namespace DotnetCliCodeSnippets.Messages.Sandbox.WhatsApp;

public class SendWhatsAppText : ICodeSnippet
{
    public async Task Execute()
    {
        var messagesSandboxAllowListedToNumber = Environment.GetEnvironmentVariable("MESSAGES_SANDBOX_ALLOW_LISTED_TO_NUMBER") ?? "MESSAGES_SANDBOX_ALLOW_LISTED_TO_NUMBER";
        var messagesSandboxWhatsAppNumber = Environment.GetEnvironmentVariable("MESSAGES_SANDBOX_WHATSAPP_NUMBER") ?? "MESSAGES_SANDBOX_WHATSAPP_NUMBER";
        var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable("VONAGE_APPLICATION_ID") ?? "VONAGE_APPLICATION_ID";
        var VONAGE_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";

        // Set "Url.Api" to "https://messages-sandbox.nexmo.com" in appsettings.json
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_PRIVATE_KEY_PATH);

        var vonageClient = new VonageClient(credentials);

        var request = new WhatsAppTextRequest
        {
            To = messagesSandboxAllowListedToNumber,
            From = messagesSandboxWhatsAppNumber,
            Text = "A WhatsApp text message sent using the Vonage Messages API via the Messages Sandbox"
        };

        var response = await vonageClient.MessagesClient.SendAsync(request);
        Console.WriteLine($"Message UUID: {response.MessageUuid}");
    }
}