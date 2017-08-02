using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nexmo.Api;
using Nexmo.Api.Voice;
using NexmoVoiceASPNetCoreQuickStarts.Helpers;

namespace NexmoVoiceASPNetCoreQuickStarts.Controllers
{
    public class VoiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult MakeTextToSpeechCall()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MakeTextToSpeechCall(string to)
        {
            var temp = new NCCOHelpers();
            temp.CreateTalkNCCO();

            var NEXMO_FROM_NUMBER = Configuration.Instance.Settings["appsettings:NEXMO_FROM_NUMBER"];
            var NEXMO_TO_NUMBER = to;
            var NEXMO_CALL_ANSWER_URL = "https://nexmo-community.github.io/ncco-examples/first_call_talk.json";

            var results = Call.Do(new Call.CallCommand
            {
                to = new[]
                {
                    new Call.Endpoint {
                        type = "phone",
                        number = NEXMO_TO_NUMBER
                    }
                },
                from = new Call.Endpoint
                {
                    type = "phone",
                    number = NEXMO_FROM_NUMBER
                },
                answer_url = new[]
                {
                    NEXMO_CALL_ANSWER_URL
                }
            });

            return RedirectToAction("Index", "Home");
        }
    }
}