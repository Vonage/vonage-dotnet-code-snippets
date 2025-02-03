#region

using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Messages.WhatsApp;
using Vonage.Request;

#endregion

namespace DotnetCliCodeSnippets.Messages.WhatsApp;

public class SendWhatsAppContact : ICodeSnippet
{
    public async Task Execute()
    {
        var MESSAGES_TO_NUMBER = Environment.GetEnvironmentVariable("MESSAGES_TO_NUMBER") ?? "MESSAGES_TO_NUMBER";
        var WHATSAPP_SENDER_ID = Environment.GetEnvironmentVariable("WHATSAPP_SENDER_ID") ?? "WHATSAPP_SENDER_ID";
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
                type = "contacts",
                contacts = new []
                {
                    new
                    {
                       name = new {
                        first_name = "John",
                        formatted_name = "John Smith",
                        last_name = "Smith",
                       },
                       birthday = "2012-08-18",
                       emails = new []
                       {
                           new
                           {
                               email = "test@fb.com",
                               type = "WORK",
                           },
                           new
                           {
                               email = "test@whatsapp.com",
                               type = "WORK",
                           }
                       },
                       addresses = new []
                       {
                            new
                            {
                                 city = "Menlo Park",
                                 country = "United States",
                                 country_code = "US",
                                 state = "CA",
                                 street = "1 Hacker Way",
                                 type = "WORK",
                                 zip = "94025",
                            }
                       },
                       org = new
                       {
                           company = "WhatsApp",
                           department = "Design",
                           title = "Manager",
                       },
                       urls = new
                       {
                           url = "https://www.facebook.com",
                           type = "WORK",
                       }
                    }
                }
            }
        };
        var response = await vonageClient.MessagesClient.SendAsync(request);
        Console.WriteLine($"Message UUID: {response.MessageUuid}");
    }
}