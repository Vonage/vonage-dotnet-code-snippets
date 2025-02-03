#region

using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Messages.WhatsApp;
using Vonage.Request;

#endregion

namespace DotnetCliCodeSnippets.Messages.WhatsApp;

public class SendWhatsAppAuthenticationTemplate : ICodeSnippet
{
    public async Task Execute()
    {
        var MESSAGES_TO_NUMBER = Environment.GetEnvironmentVariable("MESSAGES_TO_NUMBER") ?? "MESSAGES_TO_NUMBER";
        var WHATSAPP_SENDER_ID = Environment.GetEnvironmentVariable("WHATSAPP_SENDER_ID") ?? "WHATSAPP_SENDER_ID";
        var WHATSAPP_TEMPLATE_NAME = Environment.GetEnvironmentVariable("WHATSAPP_TEMPLATE_NAME") ?? "WHATSAPP_TEMPLATE_NAME";
        var WHATSAPP_OTP = Environment.GetEnvironmentVariable("WHATSAPP_OTP") ?? "WHATSAPP_OTP";
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
                            type = "body",
                            parameters = new[]
                            {
                                new
                                {
                                    type = "text",
                                    text = WHATSAPP_OTP
                                }
                            }
                        },
                        new
                        {
                            type = "button",
                            sub_type = "url",
                            index = "0",
                            parameters = new[]
                            {
                                new
                                {
                                    type = "text",
                                    text = WHATSAPP_OTP
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