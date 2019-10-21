using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NexmoDotnetCodeSnippets.Modules;

namespace NexmoDotnetCodeSnippets.Controllers
{
    public class WebhookSwitchController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        public IActionResult SwitchRoute(RoutingModule.RoutingMode mode)
        {
            RoutingModule.Mode = mode;
            ViewBag.route = String.Format("New Route Selected = {0}", RoutingModule.Mode.ToString()) ;
            return View("Index");
        }
    }
}