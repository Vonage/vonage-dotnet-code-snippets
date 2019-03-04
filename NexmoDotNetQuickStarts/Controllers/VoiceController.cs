using Nexmo.Api;
using Nexmo.Api.Voice;
using System.Threading;
using System.Web.Mvc;

namespace NexmoDotNetQuickStarts.Controllers
{
    public class VoiceController : Controller
    {
        public Client Client { get; set; }

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

        public ActionResult Index()
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

            Session["UUID"] = results.uuid;
            
            return RedirectToAction("MakeCall"); ;
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
            var UUID = Session["UUID"].ToString();

            var result = Client.Call.Edit(UUID, new Call.CallEditCommand
            {
                Action = "mute"
            });

            return RedirectToAction("MakeCall");
        }

        [HttpPost]
        public ActionResult UnmuteCall(string id)
        {
            var UUID = Session["UUID"].ToString();

            var result = Client.Call.Edit(UUID, new Call.CallEditCommand
            {
                Action = "unmute"
            });

            return RedirectToAction("MakeCall");
        }

        [HttpPost]
        public ActionResult EarmuffCall(string id)
        {
            var UUID = Session["UUID"].ToString();

            var result = Client.Call.Edit(UUID, new Call.CallEditCommand
            {
                Action = "earmuff"
            });

            Thread.Sleep(3000);

            var unearmuffresult = Client.Call.Edit(UUID, new Call.CallEditCommand
            {
                Action = "unearmuff"
            });

            return RedirectToAction("MakeCall");
        }

        [HttpPost]
        public ActionResult UnearmuffCall(string id)
        {
            var UUID = Session["UUID"].ToString();

            var result = Client.Call.Edit(UUID, new Call.CallEditCommand
            {
                Action = "unearmuff"
            });

    return RedirectToAction("MakeCall");
}

        [HttpPost]
        public ActionResult HangupCall()
        {
            var UUID = Session["UUID"].ToString();

            var result = Client.Call.Edit(UUID, new Call.CallEditCommand
            {
                Action = "hangup"
            });

            return RedirectToAction("MakeCall");
        }

        [HttpPost]
        public ActionResult PlayttsToCall()
        {
            var UUID = Session["UUID"].ToString();
            var TEXT = "This is a text to speech sample";

            var result = Client.Call.BeginTalk(UUID, new Call.TalkCommand
            {
                text = TEXT,
                voice_name = "Kimberly"
            });

            return RedirectToAction("MakeCall");
        }

        [HttpPost]
        public ActionResult PlayAudioStreamToCall()
        {
            var UUID = Session["UUID"].ToString();

            var result = Client.Call.BeginStream(UUID, new Call.StreamCommand
            {
                stream_url = new[]
                {
                        "https://nexmo-community.github.io/ncco-examples/assets/voice_api_audio_streaming.mp3"
                    }
            });

            return RedirectToAction("MakeCall");
        }

        [HttpPost]
        public ActionResult PlayDTMFToCall()
        {
            var UUID = Session["UUID"].ToString();
            var DIGITS = "1234";

            var result = Client.Call.SendDtmf(UUID, new Call.DtmfCommand
            {
                digits = DIGITS
            });

            return RedirectToAction("MakeCall");
        }

        [HttpPost]
        public ActionResult TransferCall()
        {
            var UUID = Session["UUID"].ToString();

            var result = Client.Call.Edit(UUID, new Call.CallEditCommand
            {
                Action = "transfer",
                Destination = new Call.Destination
                {
                    Type = "ncco",
                    Url = new[] { "https://developer.nexmo.com/ncco/transfer.json" }
                }
            });

            return RedirectToAction("MakeCall");
        }
    }
}