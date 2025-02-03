using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vonage;
using Vonage.Messages.WhatsApp;
using Vonage.Request;

namespace DotnetCliCodeSnippets.Messages.WhatsApp;

public class SendWhatsAppMtm : ICodeSnippet
{
    public async Task Execute()
    {
        var MESSAGES_TO_NUMBER = Environment.GetEnvironmentVariable("MESSAGES_TO_NUMBER") ?? "MESSAGES_TO_NUMBER";
        var WHATSAPP_SENDER_ID = Environment.GetEnvironmentVariable("WHATSAPP_SENDER_ID") ?? "WHATSAPP_SENDER_ID";
        var WHATSAPP_TEMPLATE_NAME = Environment.GetEnvironmentVariable("WHATSAPP_TEMPLATE_NAME") ?? "WHATSAPP_TEMPLATE_NAME";
        var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable("VONAGE_APPLICATION_ID") ?? "VONAGE_APPLICATION_ID";
        var VONAGE_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_PRIVATE_KEY_PATH);
        var vonageClient = new VonageClient(credentials);
        var request = new WhatsAppTemplateRequest
        {
            To = MESSAGES_TO_NUMBER,
            From = WHATSAPP_SENDER_ID,
            WhatsApp = new MessageWhatsApp
            {
                Policy = "deterministic",
                Locale = "en-GB",
            },
            Template = new MessageTemplate
            {
                Name = WHATSAPP_TEMPLATE_NAME,
                Parameters =
                [
                    "Vonage Verification",
                    "64873",
                    "10"
                ],
            }
        };
        var response = await vonageClient.MessagesClient.SendAsync(request);
        Console.WriteLine($"Message UUID: {response.MessageUuid}");
    }
}