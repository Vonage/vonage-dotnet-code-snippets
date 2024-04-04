﻿using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Messages.Viber;
using Vonage.Request;

namespace DotnetCliCodeSnippets.Messages.Sms;

public class SendViberText : ICodeSnippet
{
    public async Task Execute()
    {
        var messagesSandboxAllowListedToNumber = Environment.GetEnvironmentVariable("MESSAGES_SANDBOX_ALLOW_LISTED_TO_NUMBER") ?? "MESSAGES_SANDBOX_ALLOW_LISTED_TO_NUMBER";
        var messagesSandboxViberServiceId = Environment.GetEnvironmentVariable("MESSAGES_SANDBOX_VIBER_SERVICE_ID") ?? "MESSAGES_SANDBOX_VIBER_SERVICE_ID";
        var appId = Environment.GetEnvironmentVariable("VONAGE_APP_ID") ?? "VONAGE_APP_ID";
        var privateKeyPath = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";

        // Set "Url.Api" to "https://messages-sandbox.nexmo.com" in appsettings.json
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(appId, privateKeyPath);

        var vonageClient = new VonageClient(credentials);
        
        var request = new ViberTextRequest
        {
            To = messagesSandboxAllowListedToNumber,
            From = messagesSandboxViberServiceId,
            Text = "An SMS sent using the Vonage Messages API via the Messages Sandbox"
        };

        var response = await vonageClient.MessagesClient.SendAsync(request);
        Console.WriteLine($"Message UUID: {response.MessageUuid}");
    }
}