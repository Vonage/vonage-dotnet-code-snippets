using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vonage;
using Vonage.Messages.WhatsApp;
using Vonage.Request;

namespace DotnetCliCodeSnippets.Messages.WhatsApp;

public class SendWhatsAppMediaMtm : ICodeSnippet
{
    public async Task Execute()
    {
        var MESSAGES_TO_NUMBER = Environment.GetEnvironmentVariable("MESSAGES_TO_NUMBER") ?? "MESSAGES_TO_NUMBER";
        var WHATSAPP_SENDER_ID = Environment.GetEnvironmentVariable("WHATSAPP_SENDER_ID") ?? "WHATSAPP_SENDER_ID";
        var WHATSAPP_TEMPLATE_NAME = Environment.GetEnvironmentVariable("WHATSAPP_TEMPLATE_NAME") ?? "WHATSAPP_TEMPLATE_NAME";
        var MESSAGES_IMAGE_URL = Environment.GetEnvironmentVariable("MESSAGES_IMAGE_URL") ?? "MESSAGES_IMAGE_URL";
        var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable("VONAGE_APPLICATION_ID") ?? "VONAGE_APPLICATION_ID";
        var VONAGE_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ?? "VONAGE_PRIVATE_KEY_PATH";
        var credentials = Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_PRIVATE_KEY_PATH);
        var vonageClient = new VonageClient(credentials);
        var request = new WhatsAppCustomRequest
        {
            To = MESSAGES_TO_NUMBER,
            From = WHATSAPP_SENDER_ID,
            Custom = new
            {
                type = "template",
                template = new
                {
                    name = WHATSAPP_TEMPLATE_NAME,
                    language = new
                    {
                        code = "en",
                        policy = "deterministic"
                    },
                    components = new object[]
                    {
                        new
                        {
                            type = "header",
                            image = new
                            {
                                link = MESSAGES_IMAGE_URL
                            }
                        },
                        new
                        {
                            type = "body",
                            parameters = new[]
                            {
                                new
                                {
                                    type = "text",
                                    text = "This is a WhatsApp Media Message Template Message sent using the Vonage Messages API."
                                }
                            }
                        }
                    }
                }
            }
        };
        var response = await vonageClient.MessagesClient.SendAsync(request);
        Console.WriteLine($"Message UUID: {response.MessageUuid}");
    }
}