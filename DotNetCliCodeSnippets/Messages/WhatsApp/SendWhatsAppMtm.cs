using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vonage;
using Vonage.Messages.WhatsApp;
using Vonage.Request;

namespace DotnetCliCodeSnippets.Messages.WhatsApp;

public class SendWhatsAppMtm : ICodeSnippet
{
    public async Task Execute()
    {
        var to = Environment.GetEnvironmentVariable("TO_NUMBER") ?? "TO_NUMBER";
        var brandName = Environment.GetEnvironmentVariable("VONAGE_BRAND_NAME") ?? "VONAGE_BRAND_NAME";
        var appId = Environment.GetEnvironmentVariable("VONAGE_APP_ID") ?? "VONAGE_APP_ID";
        var privateKeyPath = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";

        var credentials = Credentials.FromAppIdAndPrivateKeyPath(appId, privateKeyPath);

        var vonageClient = new VonageClient(credentials);

        var request = new WhatsAppTemplateRequest
        {
            To = to,
            From = brandName,
            WhatsApp = new MessageWhatsApp
            {
                Policy = "deterministic",
                Locale = "en-GB"
            },
            Template = new MessageTemplate
            {
                Name = "whatsapp:hsm:technology:nexmo:mytemplate",
                Parameters =  new List<object>
                {
                    new {
                        @default = "Vonage Verification"
                    },
                    new {
                        @default = "64873"
                    },
                    new {
                        @default = "10"
                    }
                }
            }
        };

        var response = await vonageClient.MessagesClient.SendAsync(request);
        Console.WriteLine($"Message UUID: {response.MessageUuid}");
    }
}