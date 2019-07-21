using Nancy;
using Newtonsoft.Json.Linq;

namespace NexmoDotnetCodeSnippets.Modules
{
    public class InboundCallModule : NancyModule
    {
        public InboundCallModule()
        {
            Get("/webhook/answer", x => {
                var response = (Response)GetInboundNCCO();
                response.ContentType = "application/json";
                return response;
            });

            Post("/webhook/event", x => Request.Query["status"]);
        }

        private string GetInboundNCCO()
        {
            dynamic TalkNCCO = new JObject();
            TalkNCCO.action = "talk";
            TalkNCCO.text = "Thank you for calling from " + string.Join(" ", this.Request.Query["from"].ToCharArray());
            TalkNCCO.voiceName = "Kimberly";

            JArray jarrayObj = new JArray
            {
                TalkNCCO
            };

            return jarrayObj.ToString();

        }
    }
}
