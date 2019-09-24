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

        public ApplicationController()
        {
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateApplication(string name)
        {
            var result = Senders.ApplicationSender.CreateApp(name);
            ViewBag.creationResult = $"Your app {result.Name} has been created. ID {result.Id}";
            return View("Index");
        }

        [HttpPost]
        public ActionResult GetApplication(string id)
        {
            var APPLICATION_ID = id;
            var results = Senders.ApplicationSender.GetApplication(id);
            ViewBag.getResult = $"App public key: {results.Keys.PublicKey}";
            return View("Index");
        }

        [HttpPost]
        public ActionResult ListAvailableApplications()
        {
            var appList = Senders.ApplicationSender.GetAllApplications();
            ViewBag.listResults = appList;
            return View("Index");
        }

        [HttpPost]
        public ActionResult UpdateApplication(string id, string name)
        {
            var result = Senders.ApplicationSender.UpdateApplication(id, name);
            ViewBag.updateResult = $"Your app {result.Id} has been updated. ID {result.Name}";
            return View("Index");
        }

        [HttpPost]
        public ActionResult DeleteApplication(string id)
        {
            var result = Senders.ApplicationSender.DeleteApplication(id);
            if (result)
                ViewBag.deleteResult = "App deleted";
            return View("Index");
        }
    }
}