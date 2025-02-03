#region

using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Messages.WhatsApp;
using Vonage.Request;

#endregion

namespace DotnetCliCodeSnippets.Messages.WhatsApp;

public class SendWhatsAppQuickReplyButton : ICodeSnippet
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
                            parameters = new[]
                            {
                                new
                                {
                                    type = "text",
                                    text = "12/26"
                                }
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
                                    text = "*Ski Trip*"
                                },
                                new
                                {
                                    type = "text",
                                    text = "2019-12-26"
                                },
                                new
                                {
                                    type = "text",
                                    text = "*Squaw Valley Ski Resort, Tahoe*"
                                }
                            }
                        },
                        new
                        {
                            type = "button",
                            sub_type = "quick_reply",
                            index = 0,
                            parameters = new[]
                            {
                                new
                                {
                                    type = "payload",
                                    text = "Yes-Button-Payload"
                                }
                            }
                        },
                        new
                        {
                            type = "button",
                            sub_type = "quick_reply",
                            index = 1,
                            parameters = new[]
                            {
                                new
                                {
                                    type = "payload",
                                    text = "No-Button-Payload"
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