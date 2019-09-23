using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NexmoDotnetCodeSnippets.Senders;
using NexmoDotnetCodeSnippets.Models;
using Nexmo.Api.Request;

namespace NexmoDotnetCodeSnippets.Controllers
{
    public class RedactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult RedactWithId(string id, string product, string type)
        {
            if (product == RedactModel.RedactProduct.verifySdk.ToString())
            {
                product = "verify-sdk";
            }
            if (product == RedactModel.RedactProduct.numberInsight.ToString())
            {
                product = "number-insight";
            }
            try
            {
                NexmoResponse result = null;
                if (product == RedactModel.RedactProduct.sms.ToString() && type == RedactModel.RedactType.na.ToString())
                {
                    ViewBag.redactResult = "ERROR: Need to add a type for SMS";
                }
                else if (product == "sms")
                {
                    result = RedactSender.RedactWithIdAndType(id, product, type);                    
                }
                else
                {
                    result = RedactSender.RedactWithId(id, product);                    
                }
                if (result != null && result.Status == System.Net.HttpStatusCode.NoContent)
                {
                    ViewBag.redactResult = "Redact request handled successfully";
                }
                else if (result != null)
                {
                    ViewBag.redactResult = string.Format("Redact request failed got error code: {0}", result);
                }
            }
            catch(Exception e)
            {
                ViewBag.redactResult = "Error processing redact request";
            }
            

            return View("Index");
        }
    }
}