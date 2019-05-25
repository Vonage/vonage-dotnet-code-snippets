using Nancy;
using Newtonsoft.Json.Linq;

namespace NexmoVoiceASPNetCoreQuickStarts.Modules
{
    public class ConferenceCallModule : NancyModule
    {
        public ConferenceCallModule()
        {
            Get["/webhook/answer/"] = x => { var response = (Response)GetConferenceCallNCCO();
                                             response.ContentType = "application/json";
                                             return response;
                                           }; 
            Post["/webhook/event"] = x => Request.Query["status"];
        }

        private dynamic GetConferenceCallNCCO()
        {
            dynamic TalkNCCO = new JObject();
            TalkNCCO.action = "talk";
            TalkNCCO.text = "Hello. You will now be added to the conference call.";
            TalkNCCO.voiceName = "Emma";

            dynamic ConferenceNCCO = new JObject();
            ConferenceNCCO.action = "conversation";
            ConferenceNCCO.name = "conference-call";

            JArray nccoObj = new JArray
            {
                TalkNCCO,
                ConferenceNCCO
            };

            return nccoObj.ToString();
        }
    }
}
