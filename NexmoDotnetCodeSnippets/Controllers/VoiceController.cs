using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nexmo.Api.Voice;
using Nexmo.Api.Voice.Nccos;
using NexmoDotnetCodeSnippets.Authentication;
using NexmoDotnetCodeSnippets.Senders;
using System.Collections.Generic;
using System.Threading;

namespace NexmoDotnetCodeSnippets.Controllers
{
    public class VoiceController : Controller
    {
        const string UIDD = "_UIDD";
        const string SITE_BASE = @"SITE_BASE";

        public VoiceController()
        {
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult MakeCall()
        {
            return View("Index");
        }

        [HttpPost]
        public ActionResult MakeCall(string to, string from)
        {
            var NEXMO_NUMBER = from;

            var results = VoiceSender.MakeCall(to, NEXMO_NUMBER);

            HttpContext.Session.SetString(UIDD, results.uuid);
            ViewBag.callResult = $"Call started. Call uuid is {results.uuid}";

            return View("Index"); 
        }

        [HttpPost]
        public ActionResult MakeCallWithNCCO(string to, string from)
        {
            var NEXMO_NUMBER = from;

            var results = VoiceSender.MakeCallWithNCCO(to, NEXMO_NUMBER);

            HttpContext.Session.SetString(UIDD, results.uuid);
            ViewBag.nccoCallResult = $"Call started. Call uuid is {results.uuid}";

            return View("Index");
        }

        [HttpGet]
        public ActionResult CallList()
        {
            var results = VoiceSender.GetAllCalls()._embedded.calls;

            ViewData.Add("results", results);

            return View("Index");
        }

        [HttpPost]
        public ActionResult GetCall(string id)
        {
            var call = VoiceSender.GetCall(id);

            ViewBag.calluuid = $"Uuid: {call.uuid}";
            ViewBag.callconversation_uuid = $"Conversation uuid: {call.conversation_uuid}";
            ViewBag.calltonumber = $"To: {call.to.number}";
            ViewBag.callfromnumber = $"From: {call.from.number}";
            ViewBag.callstatus = $"Status: {call.status}";
            ViewBag.calldirection = $"Direction: {call.direction}";
            ViewBag.callrate = $"Rate: {call.rate}";
            ViewBag.callprice = $"Price: {call.price}";
            ViewBag.callduration = $"Duration: {call.duration}";
            ViewBag.callstart_time = $"Start time: {call.start_time}";
            ViewBag.callend_time = $"End time: {call.end_time}";
            ViewBag.callnetwork = $"Network: {call.network}";

            return View("Index");
        }

        [HttpPost]
        public ActionResult MuteCall(string id)
        {
            var result = VoiceSender.MuteCall(id);

            return View("Index");
        }

        [HttpPost]
        public ActionResult UnmuteCall(string id)
        {
            var result = VoiceSender.UnmuteCall(id);

            return View("Index");
        }

        [HttpPost]
        public ActionResult EarmuffCall(string id)
        {
            var UUID = HttpContext.Session.GetString(UIDD);

            VoiceSender.EarmuffCall(id);

            Thread.Sleep(3000);

            VoiceSender.UnearmuffCall(id);

            return View("Index");
        }

        [HttpPost]
        public ActionResult UnearmuffCall(string id)
        {
            var UUID = HttpContext.Session.GetString(UIDD);

            var result = VoiceSender.UnearmuffCall(id);

            return View("Index");
        }

        [HttpPost]
        public ActionResult HangupCall(string id)
        {
            VoiceSender.HangupCall(id);

            return View("Index");
        }

        [HttpPost]
        public ActionResult PlayttsToCall(string id)
        {
            var result = VoiceSender.PlayTtsToCall(id);

            return View("Index");
        }

        [HttpPost]
        public ActionResult PlayAudioStreamToCall(string id)
        {
            var result = VoiceSender.PlayAudioStreamToCall(id);

            return View("Index");
        }

        [HttpPost]
        public ActionResult PlayDTMFToCall(string id)
        {
            var result = VoiceSender.PlayDTMFToCall(id);

            return View("Index");
        }

        [HttpPost]
        public ActionResult TransferCall(string id)
        {
            var result = VoiceSender.TransferCall(id);

            return View("Index");
        }

        [HttpPost]
        public ActionResult GetAllCalls()
        {
            var calls = VoiceSender.GetAllCalls();

            ViewBag.numCalls = calls.count;

            return View("Index");

        }

        [HttpPost]
        public FileResult GetRecording(string recording_url, string fileName)
        {
            var result = VoiceSender.GetRecording(recording_url);
            var response = File(result.ResultStream, "audio/mpeg");
            response.FileDownloadName = fileName;
            return response;
        }

        [HttpPost]
        public ActionResult TransferWithInlineNCCO(string id)
        {
            var result = VoiceSender.TransferCallWithInlineNCCO(id);
            return View("Index");
        }

        [HttpPost]
        public ActionResult TrackInProgressNCCO(string TO_NUMBER, string NEXMO_NUMBER)
        {
            var client = FullAuth.GetClient();

            var talkAction = new TalkAction() { Text = "This is a text to speech call from Nexmo" };

            var payload = new Dictionary<string, string>();
            payload.Add("foo", "bar");

            var nofityAction = new NotifyAction()
            {
                EventUrl = new[] { $"{SITE_BASE}/voice/Notify" },
                Payload = payload
            };

            var talkAction2 = new TalkAction() { Text = "You'll never hear this talk action because the notification handler will return an NCCO" };

            var ncco = new Ncco(talkAction, nofityAction, talkAction2);

            var command = new Call.CallCommand
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

                NccoObj = ncco
            };

            var results = client.Call.Do(new Call.CallCommand
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

                NccoObj = ncco
            });
            ViewBag.trackNccoCallResult = $"Call started. Call uuid is {results.uuid}";
            return View("Index");
        }

        [HttpPost]
        public string Notify()
        {
            var talkAction = new TalkAction() { Text = "Hello, This is the talk action from the notify NCCO." };
            var ncco = new Ncco(talkAction);

            return ncco.ToString();
        }
    }
}