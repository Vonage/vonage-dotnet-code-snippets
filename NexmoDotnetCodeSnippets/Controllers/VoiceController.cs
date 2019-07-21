using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Nexmo.Api;
using Nexmo.Api.Voice;

namespace NexmoDotnetCodeSnippets.Controllers
{
    public class VoiceController : Controller
    {
        public Client Client { get; set; }
        const string UIDD = "_UIDD";

        public VoiceController()
        {
            Client = new Client(creds: new Nexmo.Api.Request.Credentials
            {
                ApiKey = "NEXMO_API_KEY",
                ApiSecret = "NEXMO_API_SECRET",
                ApplicationId = "NEXMO_APPLICATION_ID",
                ApplicationKey = "NEXMO_APPLICATION_PRIVATE_KEY"
            });
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult MakeCall()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MakeCall(string to)
        {
            var TO_NUMBER = to;
            var NEXMO_NUMBER = "NEXMO_NUMBER";

            var results = Client.Call.Do(new Call.CallCommand
            {
                to = new[]
                {
                    new Call.Endpoint {
                        type = "phone",
                        number = TO_NUMBER
                    }
                },
                from = new Call.Endpoint
                {
                    type = "phone",
                    number = NEXMO_NUMBER
                },
                answer_url = new[]
                {
                    "https://developer.nexmo.com/ncco/tts.json"
                }
            });

            HttpContext.Session.SetString(UIDD, results.uuid);

            return View("Index"); 
        }

        [HttpPost]
        public ActionResult MakeCallWithNCCO(string to)
        {
            var TO_NUMBER = to;
            var NEXMO_NUMBER = "NEXMO_NUMBER";

            var results = Client.Call.Do(new Call.CallCommand
            {
                to = new[]
                {
                    new Call.Endpoint {
                        type = "phone",
                        number = TO_NUMBER
                    }
                },
                from = new Call.Endpoint
                {
                    type = "phone",
                    number = NEXMO_NUMBER
                },

                Ncco = CreateNCCO()
            });

            HttpContext.Session.SetString(UIDD, results.uuid);

            return View("Index");
        }

        private JArray CreateNCCO()
        {
            dynamic TalkNCCO = new JObject();
            TalkNCCO.action = "talk";
            TalkNCCO.text = "This is a text to speech call from Nexmo";

            JArray ncco = new JArray();
            ncco.Add(TalkNCCO);
            return ncco;
        }

        [HttpGet]
        public ActionResult CallList()
        {
            var results = Client.Call.List()._embedded.calls;

            ViewData.Add("results", results);

            return View();
        }

        [HttpGet]
        public ActionResult GetCall()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetCall(string id)
        {
            var UUID = id;

            var call = Client.Call.Get(UUID);
            ViewData.Add("call", call);

            return View();
        }

        [HttpPost]
        public ActionResult MuteCall(string id)
        {
            var UUID = HttpContext.Session.GetString(UIDD);

            var result = Client.Call.Edit(UUID, new Call.CallEditCommand
            {
                Action = "mute"
            });

            return View("Index");
        }

        [HttpPost]
        public ActionResult UnmuteCall(string id)
        {
            var UUID = HttpContext.Session.GetString(UIDD);

            var result = Client.Call.Edit(UUID, new Call.CallEditCommand
            {
                Action = "unmute"
            });

            return View("Index");
        }

        [HttpPost]
        public ActionResult EarmuffCall(string id)
        {
            var UUID = HttpContext.Session.GetString(UIDD);

            var result = Client.Call.Edit(UUID, new Call.CallEditCommand
            {
                Action = "earmuff"
            });

            Thread.Sleep(3000);

            var unearmuffresult = Client.Call.Edit(UUID, new Call.CallEditCommand
            {
                Action = "unearmuff"
            });

            return View("Index");
        }

        [HttpPost]
        public ActionResult UnearmuffCall(string id)
        {
            var UUID = HttpContext.Session.GetString(UIDD);

            var result = Client.Call.Edit(UUID, new Call.CallEditCommand
            {
                Action = "unearmuff"
            });

            return View("Index");
        }

        [HttpPost]
        public ActionResult HangupCall()
        {
            var UUID = HttpContext.Session.GetString(UIDD);

            var result = Client.Call.Edit(UUID, new Call.CallEditCommand
            {
                Action = "hangup"
            });

            return View("Index");
        }

        [HttpPost]
        public ActionResult PlayttsToCall()
        {
            var UUID = HttpContext.Session.GetString(UIDD);
            var TEXT = "This is a text to speech sample";

            var result = Client.Call.BeginTalk(UUID, new Call.TalkCommand
            {
                text = TEXT,
                voice_name = "Kimberly"
            });

            return View("Index");
        }

        [HttpPost]
        public ActionResult PlayAudioStreamToCall()
        {
            var UUID = HttpContext.Session.GetString(UIDD);

            var result = Client.Call.BeginStream(UUID, new Call.StreamCommand
            {
                stream_url = new[]
                {
                        "https://nexmo-community.github.io/ncco-examples/assets/voice_api_audio_streaming.mp3"
                    }
            });

            return View("Index");
        }

        [HttpPost]
        public ActionResult PlayDTMFToCall()
        {
            var UUID = HttpContext.Session.GetString(UIDD);
            var DIGITS = "1234";

            var result = Client.Call.SendDtmf(UUID, new Call.DtmfCommand
            {
                digits = DIGITS
            });

            return View("Index");
        }

        [HttpPost]
        public ActionResult TransferCall()
        {
            var UUID = HttpContext.Session.GetString(UIDD);

            var result = Client.Call.Edit(UUID, new Call.CallEditCommand
            {
                Action = "transfer",
                Destination = new Call.Destination
                {
                    Type = "ncco",
                    Url = new[] { "https://developer.nexmo.com/ncco/transfer.json" }
                }
            });

            return View("Index");
        }
    }
}