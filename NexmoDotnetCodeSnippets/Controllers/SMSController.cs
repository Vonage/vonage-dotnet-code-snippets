using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Nexmo.Api;
using NexmoDotnetCodeSnippets.Senders;

namespace NexmoDotnetCodeSnippets.Controllers
{
    public class SMSController : Controller
    {
        public SMSController()
        {
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
        public ActionResult Send(string to, string from, string message)
        {
            var results = SMSSender.SendSMS(to, from, message);

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
        public ActionResult SendUnicodeSMS(string to, string from, string text = "こんにちは世界")
        {
            var type = "unicode";

            var results = SMSSender.SendSMSUnicode(to, from, text);

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
        [HttpPost]
        public ActionResult SendSignedSms(string to, string from, string message, string NEXMO_API_KEY, string NEXMO_API_SIGNATURE_SECRET)
        {
            var results = SMSSender.SendSignedSms(to, from, message, NEXMO_API_KEY, NEXMO_API_SIGNATURE_SECRET);

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