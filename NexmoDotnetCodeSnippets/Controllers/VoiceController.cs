using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nexmo.Api;
using NexmoDotnetCodeSnippets.Senders;
using System.Threading;

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
        public ActionResult MakeCall(string to, string from)
        {
            var TO_NUMBER = to;
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
            var results = Client.Call.List()._embedded.calls;

            ViewData.Add("results", results);

            return View();
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
        public ActionResult PlayttsToCall()
        {
            var UUID = HttpContext.Session.GetString(UIDD);

            var result = VoiceSender.PlayTtsToCall(UUID);

            return View("Index");
        }

        [HttpPost]
        public ActionResult PlayAudioStreamToCall()
        {
            var UUID = HttpContext.Session.GetString(UIDD);

            var result = VoiceSender.PlayAudioStreamToCall(UUID);

            return View("Index");
        }

        [HttpPost]
        public ActionResult PlayDTMFToCall()
        {
            var UUID = HttpContext.Session.GetString(UIDD);

            var result = VoiceSender.PlayDTMFToCall(UUID);

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
    }
}