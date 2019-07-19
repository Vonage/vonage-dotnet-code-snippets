using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nexmo.Api;

namespace NexmoDotnetCodeSnippets.Controllers
{
    public class AccountController : Controller
    {
        public Client Client { get; set; }

        public AccountController()
        {
            //Client = new Client(creds: new Nexmo.Api.Request.Credentials
            //{
            //    ApiKey = "NEXMO_API_KEY",
            //    ApiSecret = "NEXMO_API_SECRET"
            //});
            Client = new Client(creds: new Nexmo.Api.Request.Credentials
            {
                ApiKey = "973c7ce2",
                ApiSecret = "6245c2c8978923dc"
            });
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetAccountBalance()
        {
            var result = Client.Account.GetBalance();
            if (result != null)
            {
                ViewBag.Balance = $"Your account balance is: {result.value}";
            }
            return View("Index");
        }

        [HttpPost]
        public ActionResult ConfigureAccount(string smsCallbackUrl)
        {
            var SMS_CALLBACK_URL = smsCallbackUrl;

            var result = Client.Account.SetSettings(null, SMS_CALLBACK_URL, null );

            if (result != null)
            {
                ViewBag.result = $"Your SMS callback url has been updated to {result.moCallbackUrl}";
            }
            
            return View("Index");
        }

        [HttpPost]
        public ActionResult CreateSecret(string apiKey, string newSecret)
        {
            var NEXMO_API_KEY = apiKey;

            var result = Client.ApiSecret.Create(NEXMO_API_KEY, newSecret);

            if (result != null)
            {
                ViewBag.creationResult = $"Secret created! Your secret Id is  {result.Id}";
            }

            return View("Index");
        }

        [HttpPost]
        public ActionResult FetchSecret(string apiKey, string secretId)
        {
            var NEXMO_API_KEY = apiKey;
            var NEXMO_SECRET_ID = secretId;

            var result = Client.ApiSecret.Get(NEXMO_API_KEY, NEXMO_SECRET_ID);

            if (result != null)
            {
                ViewBag.getResult = $"Your secret Id is  {result.Id} , secret created at {result.CreatedAt}";
            }

            return View("Index");
        }

        [HttpPost]
        public ActionResult DeleteSecret(string apiKey, string secretId)
        {
            var NEXMO_API_KEY = apiKey;
            var NEXMO_SECRET_ID = secretId;

            var result = Client.ApiSecret.Delete(NEXMO_API_KEY, NEXMO_SECRET_ID);

            if (result )
            {
                ViewBag.deleteResult = "Secret deleted";
            }

            return View("Index");
        }

        [HttpPost]
        public ActionResult GetAllSecrets(string apiKey)
        {
            var NEXMO_API_KEY = apiKey;

            var result = Client.ApiSecret.List(NEXMO_API_KEY);

            if (result.Count > 0)
            {
                ViewBag.listResults = result;
                ViewBag.count = result.Count;
            }
            return View("Index");
        }
    }
}