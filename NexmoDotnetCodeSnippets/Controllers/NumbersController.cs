using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nexmo.Api;

namespace NexmoDotnetCodeSnippets.Controllers
{
    public class NumbersController : Controller
    {
        public Client Client { get; set; }

        public NumbersController()
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
        public ActionResult BuyNumber(string country, string number)
        {
            var COUNTRY_CODE = country;
            var NEXMO_NUMBER = number;

            var result = Client.Number.Buy(COUNTRY_CODE, NEXMO_NUMBER);

            return View("Index");
        }

        [HttpPost]
        public ActionResult UpdateNumber(string country, string number)
        {
            var COUNTRY_CODE = country;
            var NEXMO_NUMBER = number;

            var updatednumber = Client.Number.Update(new Number.NumberUpdateCommand
            {
                country = COUNTRY_CODE,
                msisdn = NEXMO_NUMBER,
                voiceCallbackType = "tel"
            });

            return View("Index");
        }

        [HttpPost]
        public ActionResult CancelNumber(string country, string number)
        {
            var COUNTRY_CODE = country;
            var NEXMO_NUMBER = number;

            var result = Client.Number.Cancel(COUNTRY_CODE, NEXMO_NUMBER);

            return View("Index");
        }

        [HttpPost]
        public ActionResult SearchAvailableNumbers(string country, string type, string features, string criteria, string pattern)
        {
            var availableNumbers = Senders.NumberSender.SearchNumbers(country, type, features, criteria, pattern);

            if(availableNumbers.count > 0)
            {
                ViewBag.listResults = availableNumbers.numbers;
                ViewBag.count = 10;
            }
            return View("Index");
        }

        [HttpPost]
        public ActionResult ListOwnNumber(string criteria, string seachPattern)
        {
            var response = Senders.NumberSender.ListOwnNumbers(criteria, seachPattern);
            return View("Index");
        }
    }
}