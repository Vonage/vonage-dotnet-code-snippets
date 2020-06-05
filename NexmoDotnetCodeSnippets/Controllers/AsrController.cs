using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages;
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
            var host = Request.Host.ToString();
            //Uncomment the next line if using ngrok with --host-header option
            //host = Request.Headers["X-Original-Host"];

            var eventUrl = $"{Request.Scheme}://{host}/webhooks/asr";
            var speechSettings = new SpeechSettings {Language="en-US", EndOnSilence=1, Uuid = new[] { request.Uuid } };
            var inputAction = new MultiInputAction { Speech = speechSettings, EventUrl = new[] { eventUrl } };

            var talkAction = new TalkAction { Text = "Please speak now" };

            var ncco = new Ncco(talkAction, inputAction);
            return ncco.ToString();
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