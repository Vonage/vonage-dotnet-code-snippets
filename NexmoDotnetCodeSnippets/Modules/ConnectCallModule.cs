using Nancy;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NexmoDotnetCodeSnippets.Modules
{
    public class ConnectCallModule : NancyModule
    {
        public ConnectCallModule()
        {
            Get("/webhook/answer", x =>
            {
                var response = (Response)GetConnectNCCO();
                response.ContentType = "application/json";
                return response;
            });

            Post("/webhook/event", x => Request.Query["status"]);
        }

        private string GetConnectNCCO()
        {
            dynamic TalkNCCO = new JObject();
            TalkNCCO.action = "talk";
            TalkNCCO.text = "Thank you for calling";
            TalkNCCO.voiceName = "Kimberly";

            dynamic Endpoint = new JObject();
            Endpoint.number = "RECIPIENT_NUMBER";
            Endpoint.type = "phone";

            dynamic ConnectNCCO = new JObject();
            ConnectNCCO.action = "connect";
            ConnectNCCO.from = "NEXMO_NUMBER";
            ConnectNCCO.endpoint = new JArray(Endpoint);

            JArray NCCObj = new JArray
            {
                TalkNCCO,
                ConnectNCCO
            };

            return NCCObj.ToString();

        }
    }
}
