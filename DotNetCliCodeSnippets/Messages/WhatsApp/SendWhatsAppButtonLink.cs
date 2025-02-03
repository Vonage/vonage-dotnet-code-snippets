using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vonage;
using Vonage.Messages.WhatsApp;
using Vonage.Request;

namespace DotnetCliCodeSnippets.Messages.WhatsApp;

public class SendWhatsAppButtonLink : ICodeSnippet
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
            Custom = new Custom
            {
                type = "template",
                template = new Template
                {
                    @namespace = "whatsapp:hsm:technology:nexmo",
                    name = WHATSAPP_TEMPLATE_NAME,
                    language = new Language
                    {
                        code = "en",
                        policy = "deterministic"
                    },
                    components = new List<Component>
                    {
                        new()
                        {
                            type = "header",
                            parameters = new List<Parameter>
                            {
                                new()
                                {
                                    type = "image",
                                    image = new Image
                                    {
                                        link = MESSAGES_IMAGE_URL
                                    }
                                }
                            }
                        },
                        new()
                        {
                            type = "body",
                            parameters = new List<Parameter>
                            {
                                new()
                                {
                                    type = "text",
                                    text = "Anand"
                                },
                                new()
                                {
                                    type = "text",
                                    text = "Quest"
                                },
                                new()
                                {
                                    type = "text",
                                    text = "113-0921387"
                                },
                                new()
                                {
                                    type = "text",
                                    text = "23rd Nov 2019"
                                }
                            }
                        },
                        new()
                        {
                            type = "button",
                            index = "0",
                            sub_type = "url",
                            parameters = new List<Parameter>
                            {
                                new()
                                {
                                    type = "text",
                                    text = "1Z999AA10123456784"
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

    private class Custom
    {
        public string type { get; set; }
        public Template template { get; set; }
    }

    private class Template
    {
        public string @namespace { get; set; }
        public string name { get; set; }
        public Language language { get; set; }
        public List<Component> components { get; set; }
    }

    private class Language
    {
        public string code { get; set; }
        public string policy { get; set; }
    }

    private class Component
    {
        public string type { get; set; }
        public List<Parameter> parameters { get; set; }
        public string index { get; set; }
        public string sub_type { get; set; }
    }

    private class Parameter
    {
        public string type { get; set; }
        public Image image { get; set; }
        public string text { get; set; }
    }

    private class Image
    {
        public string link { get; set; }
    }
}

