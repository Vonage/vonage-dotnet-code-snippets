using Nexmo.Api;
using NexmoDotnetCodeSnippets.Authentication;
using System.Collections.Generic;

namespace NexmoDotnetCodeSnippets.Senders
{
    public class ApplicationSender
    {        

        public static AppResponse CreateApp(string name)
        {
            var client = BasicAuth.GetClient();

            var request = new AppRequest()
            {                
                Name = name,
                Capabilities = new Capabilities()
                {
                    Messages = new MessagesWebhook(
                        new Webhook() { Address = "https://example.com/webhooks/inbound", HttpMethod = "POST" },
                        new Webhook() { Address = "https://example.com/webhooks/status", HttpMethod = "POST" }),
                    Rtc = new RtcWebhook(
                        new Webhook() { Address = "https://example.com/webhooks/event", HttpMethod = "POST" }),
                    Voice = new VoiceWebhook(
                        new Webhook() { Address = "https://example.com/webhooks/answer", HttpMethod = "GET" },
                        new Webhook() { Address = "https://example.com/webhooks/event", HttpMethod = "POST" }),
                    Vbc = new VbcWebhook()
                }
            };

            var response = client.ApplicationV2.Create(request: request);

            return response;
        }

        public static AppResponse GetApplication(string id)
        {
            var client = BasicAuth.GetClient();

            var response = client.ApplicationV2.Get(appId: id);

            return response;
        }

        public static IList<AppResponse> GetAllApplications()
        {
            var client = BasicAuth.GetClient();

            var response = client.ApplicationV2.List();

            return response;
        }

        public static AppResponse UpdateApplication(string id, string name)
        {
            var client = BasicAuth.GetClient();

            var request = new AppRequest()
            {
                Id = id,
                Name = name,
                Capabilities = new Capabilities()
                {
                    Messages = new MessagesWebhook(
                        new Webhook() { Address = "https://example.com/webhooks/inbound", HttpMethod = "POST" },
                        new Webhook() { Address = "https://example.com/webhooks/status", HttpMethod = "POST" }),
                    Rtc = new RtcWebhook(
                        new Webhook(){Address = "https://example.com/webhooks/event", HttpMethod = "POST"}),
                    Voice = new VoiceWebhook(
                        new Webhook() { Address = "https://example.com/webhooks/answer", HttpMethod = "GET" },
                        new Webhook() { Address = "https://example.com/webhooks/event", HttpMethod = "POST" }),
                    Vbc = new VbcWebhook()
                }
            };
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(request);
            var resposne = client.ApplicationV2.Update(request: request);

            return resposne;
        }

        public static bool DeleteApplication(string id)
        {
            var client = BasicAuth.GetClient();

            var resposne = client.ApplicationV2.Delete(id);

            return resposne;
        }
    }
}
