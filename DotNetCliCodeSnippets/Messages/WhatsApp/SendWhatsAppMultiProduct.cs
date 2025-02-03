#region

using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Messages.WhatsApp;
using Vonage.Request;

#endregion

namespace DotnetCliCodeSnippets.Messages.WhatsApp;

public class SendWhatsAppMultiProduct : ICodeSnippet
{
    public async Task Execute()
    {
        var MESSAGES_TO_NUMBER = Environment.GetEnvironmentVariable("MESSAGES_TO_NUMBER") ?? "MESSAGES_TO_NUMBER";
        var WHATSAPP_SENDER_ID = Environment.GetEnvironmentVariable("WHATSAPP_SENDER_ID") ?? "WHATSAPP_SENDER_ID";
        var WHATSAPP_CATALOG_ID = Environment.GetEnvironmentVariable("WHATSAPP_CATALOG_ID") ?? "WHATSAPP_CATALOG_ID";
        var WHATSAPP_PRODUCT_ID = Environment.GetEnvironmentVariable("WHATSAPP_PRODUCT_ID") ?? "WHATSAPP_PRODUCT_ID";
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
                type = "interactive",
                interactive = new
                {
                    type = "product_list",
                    header = new
                    {
                        type = "text",
                        text = "Our top products"
                    },
                    body = new
                    {
                        text = "Check out these great products"
                    }
                },
                footer = new
                {
                    text = "Sale now on!"
                },
                action = new
                {
                    catalog_id = WHATSAPP_CATALOG_ID,
                    sections = new[]
                    {
                        new
                        {
                            title = "Cool products",
                            product_items = new[]
                            {
                                new { product_retailer_id = WHATSAPP_PRODUCT_ID },
                                new { product_retailer_id = WHATSAPP_PRODUCT_ID }
                            }
                        },
                        new
                        {
                            title = "Awesome products",
                            product_items = new[]
                            {
                                new { product_retailer_id = WHATSAPP_PRODUCT_ID }
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