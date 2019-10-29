using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NexmoDotnetCodeSnippets.Senders;
using Microsoft.AspNetCore.Mvc;

namespace NexmoDotnetCodeSnippets.Controllers
{
    public class ConversationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateConversation(string name, string displayName, string imageUrl)
        {
            var response = ConversationSender.CreateConversation(name, displayName, imageUrl);
            ViewBag.CreateDisplayName = response.DisplayName;
            ViewBag.CreateId = response.Id;
            ViewBag.CreateImageUrl = response.ImageUrl;
            ViewBag.CreateSelf = response.Links.Self;
            ViewBag.CreateName = response.Name;
            ViewBag.CreateProperties = response.Properties;
            ViewBag.CreateTimestamp = response.Timestamp;

            return View("index");
        }

        public IActionResult GetConversation(string id)
        {
            var response = ConversationSender.GetConversation(id);
            ViewBag.GetDisplayName = response.DisplayName;
            ViewBag.GetId = response.Id;
            ViewBag.GetImageUrl = response.ImageUrl;
            ViewBag.GetSelf = response.Links.Self;
            ViewBag.GetName = response.Name;
            ViewBag.GetProperties = response.Properties;
            ViewBag.GetTimestamp = response.Timestamp;

            return View("index");
        }

        public IActionResult UpdateConversation(string id, string name, string displayName, string imageUrl)
        {
            var response = ConversationSender.UpdateConversation(id, name, displayName, imageUrl);
            ViewBag.UpdateDisplayName = response.DisplayName;
            ViewBag.UpdateId = response.Id;
            ViewBag.UpdateImageUrl = response.ImageUrl;
            ViewBag.UpdateSelf = response.Links.Self;
            ViewBag.UpdateName = response.Name;
            ViewBag.UpdateProperties = response.Properties;
            ViewBag.UpdateTimestamp = response.Timestamp;
            return View("index");
        }

        public IActionResult ListConversations()
        {
            var response = ConversationSender.ListConversation();
            ViewBag.ConversationCount = response.Embedded.Conversations.Count;
            return View("index");
        }

        public IActionResult DeleteConversation(string id)
        {
            var response = ConversationSender.DeleteConversation(id);
            ViewBag.ConversationStatus = response == System.Net.HttpStatusCode.NoContent ? "Successfully Deleted" : "Something went wrong when deleting conversation " + response.ToString();
            return View("index");
        }
    }
}