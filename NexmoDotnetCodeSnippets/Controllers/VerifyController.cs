using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nexmo.Api;
using NexmoDotnetCodeSnippets.Senders;

namespace NexmoDotnetCodeSnippets.Controllers
{
    public class VerifyController : Controller
    {
        public Client Client { get; set; }
        
        public VerifyController()
        {
            Client = NexmoDotnetCodeSnippets.Authentication.BasicAuth.GetClient();
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Start(string to)
        {
            var RECIPIENT_NUMBER = to;

            var start = VerifySender.StartVerify(to);

            if (start.status == "0")
            {
                HttpContext.Session.SetString("RequestId", start.request_id);
                ViewBag.verificationResult = $"Your PIN code was successfully sent to {RECIPIENT_NUMBER}, your request ID is {start.request_id}.";
            }

            else
                ViewBag.verificationResult = start.error_text;

            return View("Index");
        }

        [HttpPost]
        public ActionResult Check(string code, string id)
        {
            var result = VerifySender.Check(code, id);

            if (result.status == "0")
            {
                ViewBag.checkMessage = "Verification Sucessful";
            }
            else
            {
                ViewBag.checkMessage = result.error_text;
            }
            return View("Index");

        }

        [HttpPost]
        public ActionResult Search(string requestID)
        {
            var search = VerifySender.Search(requestID);

            ViewBag.error_text = search.error_text;
            ViewBag.status = search.status;

            return View("Index");
        }

        [HttpPost]
        public ActionResult Cancel(string requestID)
        {
            var results = VerifySender.Cancel(requestID);
            ViewBag.cancelstatus = results.status;
            return View("Index");
        }

        [HttpPost]
        public ActionResult TriggerNext(string requestID)
        {
            var results = VerifySender.TriggerNext(requestID);
            ViewBag.nextMessage = results.status;
            return View("Index");
        }

        [HttpPost]
        public ActionResult VerifyWithWorkflow(string to, string workflow_id)
        {
            var results = VerifySender.VerifyWithWorkflowId(to, workflow_id);
            ViewBag.verificationResult = results;
            ViewBag.VerificationId = results.request_id;
            return View("index");
        }
    }
}