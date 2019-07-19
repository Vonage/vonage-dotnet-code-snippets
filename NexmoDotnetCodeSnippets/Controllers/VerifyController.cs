using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nexmo.Api;

namespace NexmoDotnetCodeSnippets.Controllers
{
    public class VerifyController : Controller
    {
        public Client Client { get; set; }
        const string RequestId = "_RequestId";
        public VerifyController()
        {
            Client = new Client(creds: new Nexmo.Api.Request.Credentials
            {
                ApiKey = "NEXMO_API_KEY",
                ApiSecret = "NEXMO_API_SECRET"
            });
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Start(string to)
        {
            var RECIPIENT_NUMBER = to;

            var start = Client.NumberVerify.Verify(new NumberVerify.VerifyRequest
            {
                number = RECIPIENT_NUMBER,
                brand = "AcmeInc"
            });

            HttpContext.Session.SetString(RequestId, start.request_id);

            return View("Index");
        }

        [HttpPost]
        public ActionResult Check(string code)
        {
            var result = Client.NumberVerify.Check(new NumberVerify.CheckRequest
            {
                request_id = HttpContext.Session.GetString(RequestId),
                code = code
            }); ;

            if (result.status == "0")
            {
                ViewBag.Message = "Verification Sucessful";
            }
            else
            {
                ViewBag.Message = result.error_text;
            }
            return View("Index");

        }

        [HttpPost]
        public ActionResult Search(string requestID)
        {
            var search = Client.NumberVerify.Search(new NumberVerify.SearchRequest
            {
                request_id = requestID
            });
            ViewBag.error_text = search.error_text;
            ViewBag.status = search.status;

            return View("Index");
        }

        [HttpPost]
        public ActionResult Cancel(string requestID)
        {
            var results = Client.NumberVerify.Control(new NumberVerify.ControlRequest
            {
                request_id = requestID,
                cmd = "cancel"
            });
            ViewBag.status = results.status;
            return View("Index");
        }

        [HttpPost]
        public ActionResult TriggerNext(string requestID)
        {
            var results = Client.NumberVerify.Control(new NumberVerify.ControlRequest
            {
                request_id = requestID,
                cmd = "trigger_next_event"
            });
            ViewBag.status = results.status;
            return View("Index");
        }
    }
}