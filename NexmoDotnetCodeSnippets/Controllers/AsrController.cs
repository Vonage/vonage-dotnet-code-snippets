using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Nexmo.Api;
using Nexmo.Api.Voice.AnswerWebhooks;
using Nexmo.Api.Voice.EventWebhooks;
using Nexmo.Api.Voice.Nccos;

namespace NexmoDotnetCodeSnippets.Controllers
{
    public class AsrController : Controller
    {
        [HttpGet("/webhooks/answer")]
        public string Answer([FromQuery]Answer request)
        {            
            var eventUrl = $"{Request.Scheme}://{Request.Host}/webhooks/asr";
            var speechSettings = new SpeechSettings {Language="en-US", EndOnSilence=1, Uuid = new[] { request.Uuid } };
            var inputAction = new MultiInputAction { Speech = speechSettings, EventUrl = new[] { eventUrl } };

            var talkAction = new TalkAction { Text = "Please speak now" };

            var ncco = new Ncco(talkAction, inputAction);
            var ret = ncco.ToString();
            return ret;
        }

        [HttpPost("/webhooks/asr")]
        public string OnInput()
        {
            MultiInput input;
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                var result = reader.ReadToEndAsync().Result;
                input = JsonConvert.DeserializeObject<MultiInput>(result);
            }
            var talkAction = new TalkAction();
            talkAction.Text = input.Speech.SpeechResults[0].Text;
            var ncco = new Ncco(talkAction);
            return ncco.ToString();
        }
    }
}