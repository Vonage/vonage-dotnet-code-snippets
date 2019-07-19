using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nexmo.Api;
using NexmoDotnetCodeSnippets.Models;

namespace NexmoDotnetCodeSnippets.Controllers
{
    public class NumberInsightsController : Controller
    {
        public Client Client { get; set; }

        public NumberInsightsController()
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
        public ActionResult Basic(string number)
        {
            var results = Client.NumberInsight.RequestBasic(new NumberInsight.NumberInsightRequest
            {
                Number = number,
            });

            
            ViewBag.requestID = results.RequestId;
            ViewBag.iNumber = results.InternationalFormatNumber;
            ViewBag.nNumber = results.NationalFormatNumber;
            ViewBag.status = results.StatusMessage;
            ViewBag.country = results.CountryName;
            ViewBag.countryCode = results.CountryCode;

            return View("Index");
        }

        [HttpPost]
        public ActionResult Standard(string number)
        {
            var results = Client.NumberInsight.RequestStandard(new NumberInsight.NumberInsightRequest()
            {
                Number = number,
            });

            ViewBag.requestID = results.RequestId;
            ViewBag.iNumber = results.InternationalFormatNumber;
            ViewBag.nNumber = results.NationalFormatNumber;
            ViewBag.country = results.CallerName;
            ViewBag.countryCode = results.CountryCode;
            ViewBag.status = results.StatusMessage;

            if (results.OriginalCarrier != null)
            {
                ViewBag.originalCarrierName = results.OriginalCarrier.Name;
                ViewBag.originalCarrierCode = results.OriginalCarrier.NetworkCode;
                ViewBag.originalCarrierType = results.OriginalCarrier.NetworkType;
                ViewBag.originalCarrierCountry = results.OriginalCarrier.Country;
            }
            if (results.CurrentCarrier != null)
            {

                ViewBag.currentCarrierName = results.CurrentCarrier.Name;
                ViewBag.currentCarrierCode = results.CurrentCarrier.NetworkCode;
                ViewBag.currentCarrierType = results.CurrentCarrier.NetworkType;
                ViewBag.currentCarrierCountry = results.CurrentCarrier.Country;
            }

            return View("Index");
        }


        [HttpPost]
        public ActionResult Advanced(string number)
        {
            var results = Client.NumberInsight.RequestAdvanced(new NumberInsight.NumberInsightRequest()
            {
                Number = number,
            });

            ViewBag.requestID = results.RequestId;
            ViewBag.iNumber = results.InternationalFormatNumber;
            ViewBag.nNumber = results.NationalFormatNumber;
            ViewBag.country = results.CallerName;
            ViewBag.countryCode = results.CountryCode;
            ViewBag.status = results.StatusMessage;

            if (results.OriginalCarrier != null)
            {
                ViewBag.originalCarrierName = results.OriginalCarrier.Name;
                ViewBag.originalCarrierCode = results.OriginalCarrier.NetworkCode;
                ViewBag.originalCarrierType = results.OriginalCarrier.NetworkType;
                ViewBag.originalCarrierCountry = results.OriginalCarrier.Country;
            }
            if (results.CurrentCarrier != null)
            {

                ViewBag.currentCarrierName = results.CurrentCarrier.Name;
                ViewBag.currentCarrierCode = results.CurrentCarrier.NetworkCode;
                ViewBag.currentCarrierType = results.CurrentCarrier.NetworkType;
                ViewBag.currentCarrierCountry = results.CurrentCarrier.Country;
            }

            ViewBag.validNumber = results.NumberValidity;
            ViewBag.ported = results.PortedStatus;
            ViewBag.reachable = results.NumberReachability;
            ViewBag.roaming = results.RoamingInformation.status;

            return View("Index");
        }
    }
}