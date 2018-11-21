using Nancy;
using Newtonsoft.Json.Linq;

namespace NexmoVoiceASPNetCoreQuickStarts
{
    public class VoiceModule : NancyModule 
    {
        public VoiceModule()
        {
            Get["/webhook/answer"] = x => GetInboundNCCO();
            Post["/webhook/event"] = x => this.Request.Query["status"];
        }

        private string GetInboundNCCO()
        {
            dynamic TalkNCCO = new JObject();
            TalkNCCO.action = "talk";
            TalkNCCO.text = "Thank you for calling from "+ string.Join(" ", this.Request.Query["from"].ToCharArray());
            TalkNCCO.voiceName = "Kimberly";
            
            JArray jarrayObj = new JArray();
            jarrayObj.Add(TalkNCCO);

            return jarrayObj.ToString();

        }
    }
}
