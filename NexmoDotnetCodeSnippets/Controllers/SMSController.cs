using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Nexmo.Api;

namespace NexmoDotnetCodeSnippets.Controllers
{
    public class SMSController : Controller
    {
        public Client Client { get; set; }

        public SMSController()
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

        [Microsoft.AspNetCore.Mvc.HttpGet]
        public ActionResult Send()
        {
            return View();
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public ActionResult Send(string to)
        {
            var TO_NUMBER = to;

            var results = Client.SMS.Send(request: new SMS.SMSRequest
            {
                from = "Acme Inc",
                to = TO_NUMBER,
                text = "A test SMS sent using the Nexmo SMS API"
            });

            if (results.messages.Count >= 1)
            {
                if (results.messages[0].status == "0")
                {
                    ViewBag.result = "Message sent successfully.";
                    Debug.WriteLine("Message sent successfully.");
                }
                else
                {
                    ViewBag.result = $"Message failed with error: { results.messages[0].error_text}";
                    Debug.WriteLine($"Message failed with error: {results.messages[0].error_text}");
                }
            }

            return View("Index");
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        public ActionResult SendUnicodeSMS()
        {
            return View();
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public ActionResult SendUnicodeSMS(string to, string text)
        {
            var TO_NUMBER = to;

            var results = Client.SMS.Send(request: new SMS.SMSRequest
            {
                from = "Acme Inc",
                to = TO_NUMBER,
                text = "こんにちは世界",
                type = "unicode"
            });

            if (results.messages.Count >= 1)
            {
                if (results.messages[0].status == "0")
                {
                    ViewBag.unicoderesult = "Message sent successfully.";
                    Debug.WriteLine("Message sent successfully.");
                }
                else
                {
                    ViewBag.unicoderesult = $"Message failed with error: { results.messages[0].error_text}";
                    Debug.WriteLine($"Message failed with error: {results.messages[0].error_text}");
                }
            }
            return View("Index");
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        public ActionResult Receive([FromQuery]SMS.SMSInbound response)
        {

            if (null != response.to && null != response.msisdn)
            {
                Debug.WriteLine("------------------------------------");
                Debug.WriteLine("INCOMING TEXT");
                Debug.WriteLine("From: " + response.msisdn);
                Debug.WriteLine(" Message: " + response.text);
                Debug.WriteLine("------------------------------------");
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status200OK);

            }
            else
            {
                Debug.WriteLine("------------------------------------");
                Debug.WriteLine("Endpoint was hit.");
                Debug.WriteLine("------------------------------------");
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status200OK);

            }

        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        public ActionResult DLR([FromQuery]SMS.SMSDeliveryReceipt response)
        {

            Debug.WriteLine("------------------------------------");
            Debug.WriteLine("DELIVERY RECIEPT");
            Debug.WriteLine("Message ID: " + response.messageId);
            Debug.WriteLine("From: " + response.msisdn);
            Debug.WriteLine("To: " + response.to);
            Debug.WriteLine("Status: " + response.status);
            Debug.WriteLine("------------------------------------");

            return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status200OK);
        }
    }
}