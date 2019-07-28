using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nexmo.Api;

namespace NexmoDotnetCodeSnippets.Controllers
{
    public class ApplicationController : Controller
    {
        public Client Client { get; set; }

        public ApplicationController()
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
        public ActionResult CreateApplication(string name)
        {
            var APPLICATION_NAME = name;
            var result = Client.ApplicationV2.Create(new AppRequest
            {
                Name = APPLICATION_NAME
            });
            ViewBag.creationResult = $"Your app {result.Name} has been created. ID {result.Id}";
            return View("Index");
        }

        [HttpPost]
        public ActionResult GetApplication(string id)
        {
            var APPLICATION_ID = id;
            var application = Client.ApplicationV2.Get(APPLICATION_ID);
            ViewBag.getResult = $"App public key: {application.Keys.PublicKey}";
            return View("Index");
        }

        [HttpPost]
        public ActionResult ListAvailableApplications()
        {
            var appList = Client.ApplicationV2.List();
            ViewBag.listResults = appList;
            return View("Index");
        }

        [HttpPost]
        public ActionResult UpdateApplication(string appName)
        {
            var APPLICATION_NAME = appName;
            var updatedApp = Client.ApplicationV2.Update(new AppRequest
            {
                Name = appName,

            });
            return View("Index");
        }

        [HttpPost]
        public ActionResult DeleteApplication(string id)
        {
            var APPLICATION_ID = id;
            var result = Client.ApplicationV2.Delete(APPLICATION_ID);
            if (result)
                ViewBag.deleteResult = "App deleted";
            return View("Index");
        }
    }
}