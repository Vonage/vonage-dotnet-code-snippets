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
            var result = Client.Number.Buy(country, number);
            return View("Index");
        }

        [HttpPost]
        public ActionResult UpdateNumber()
        {

            return View("Index");
        }

        [HttpPost]
        public ActionResult CancelNumber(string country, string number)
        {
            var result = Client.Number.Cancel(country, number);
            return View("Index");
        }

        [HttpPost]
        public ActionResult GetNumbersList()
        {
            return View("Index");
        }

        [HttpPost]
        public ActionResult SearchAvailableNumbers()
        {
            return View("Index");
        }


    }
}