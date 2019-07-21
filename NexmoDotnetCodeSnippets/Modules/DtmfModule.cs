using Nancy;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NexmoDotnetCodeSnippets.Modules
{
    public class DtmfModule : NancyModule
    {
        public DtmfModule()
        {
            Get("/webhook/answer", x => { var response = (Response)GetDTMFNCCO();
                                          response.ContentType = "application/json";
                                          return response;
            });

            Get("/webhook/dtmf", x => { var response = (Response)GetDTMFInput();
                                        response.ContentType = "application/json";
                                        return response;
            });

            Post("webhook/event", x => Request.Query["status"]);
        }

        private string GetDTMFNCCO()
        {
            dynamic TalkNCCO = new JObject();
            TalkNCCO.action = "talk";
            TalkNCCO.text = "Hello. Please press any key to continue.";

            JArray jarrayObj = new JArray
            {
                TalkNCCO
            };

            dynamic InputNCCO = new JObject();
            InputNCCO.action = "input";
            InputNCCO.maxDigits = "1";
            InputNCCO.eventUrl = $"{Request.Url.SiteBase}/webhook/dtmf";

            jarrayObj.Add(InputNCCO);

            return jarrayObj.ToString();

        }

        private string GetDTMFInput()
        {
            dynamic TalkNCCO = new JObject();
            TalkNCCO.action = "talk";
            TalkNCCO.text = $"You pressed {Request.Query["dtmf"]} ";

            JArray jarrayObj = new JArray
            {
                TalkNCCO
            };

            return jarrayObj.ToString();

        }
    }
}
