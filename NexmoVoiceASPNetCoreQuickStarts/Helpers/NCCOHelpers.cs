using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NexmoVoiceASPNetCoreQuickStarts.Helpers
{
    public class NCCOHelpers
    {
        public void CreateTalkNCCO()
        {
            dynamic TalkNCCO = new JObject();
            TalkNCCO.action = "Talk";
            TalkNCCO.text = "You are listening to a text-to-speech Call made with Nexmo Voice API";
            TalkNCCO.voiceName = "Amy";
            var test = TalkNCCO.ToString();
        }
    }
}
