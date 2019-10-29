using Microsoft.AspNetCore.Mvc;
using Nexmo.Api.Conversations;
using NexmoDotnetCodeSnippets.Senders;

namespace NexmoDotnetCodeSnippets.Controllers
{
    public class ConversationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateConversation(string name, string displayName, string imageUrl)
        {
            var response = ConversationSender.CreateConversation(name, displayName, imageUrl);
            ViewBag.CreateDisplayName = response.DisplayName;
            ViewBag.CreateId = response.Id;
            ViewBag.CreateImageUrl = response.ImageUrl;
            ViewBag.CreateSelf = response.Links.Self.Href;
            ViewBag.CreateName = response.Name;
            ViewBag.CreateProperties = response.Properties;
            ViewBag.CreateTimestamp = response.Timestamp;

            return View("index");
        }

        [HttpPost]
        public IActionResult GetConversation(string id)
        {
            var response = ConversationSender.GetConversation(id);
            ViewBag.GetDisplayName = response.DisplayName;
            ViewBag.GetId = response.Id;
            ViewBag.GetImageUrl = response.ImageUrl;
            ViewBag.GetSelf = response.Links.Self.Href;
            ViewBag.GetName = response.Name;
            ViewBag.GetProperties = response.Properties;
            ViewBag.GetTimestamp = response.Timestamp;

            return View("index");
        }

        [HttpPost]
        public IActionResult UpdateConversation(string id, string name, string displayName, string imageUrl)
        {
            var response = ConversationSender.UpdateConversation(id, name, displayName, imageUrl);
            ViewBag.UpdateDisplayName = response.DisplayName;
            ViewBag.UpdateId = response.Id;
            ViewBag.UpdateImageUrl = response.ImageUrl;
            ViewBag.UpdateSelf = response.Links.Self.Href;
            ViewBag.UpdateName = response.Name;
            ViewBag.UpdateProperties = response.Properties;
            ViewBag.UpdateTimestamp = response.Timestamp;
            return View("index");
        }

        [HttpPost]
        public IActionResult ListConversations()
        {
            var response = ConversationSender.ListConversation();
            ViewBag.ConversationCount = response.Embedded.Conversations.Count;
            return View("index");
        }

        [HttpPost]
        public IActionResult DeleteConversation(string id)
        {
            var response = ConversationSender.DeleteConversation(id);
            ViewBag.ConversationStatus = response == System.Net.HttpStatusCode.NoContent ? "Successfully Deleted" : "Something went wrong when deleting conversation " + response.ToString();
            return View("index");
        }

        [HttpPost]
        public IActionResult CreateUser(string name, string displayName, string imageUrl)
        {
            var response = ConversationSender.CreateUser(name, displayName, imageUrl);
            ViewBag.UserCreateDisplayName = response.DisplayName;
            ViewBag.UserCreateId = response.Id;
            ViewBag.UserCreateImageUrl = response.ImageUrl;
            ViewBag.UserCreateSelf = response.Links.Self.Href;
            ViewBag.UserCreateName = response.Name;

            return View("index");
        }

        [HttpPost]
        public IActionResult GetUser(string id)
        {
            var response = ConversationSender.GetUser(id);
            ViewBag.UserGetDisplayName = response.DisplayName;
            ViewBag.UserGetId = response.Id;
            ViewBag.UserGetImageUrl = response.ImageUrl;
            ViewBag.UserGetSelf = response.Links.Self.Href;
            ViewBag.UserGetName = response.Name;

            return View("index");
        }

        [HttpPost]
        public IActionResult ListUsers()
        {
            var response = ConversationSender.ListUsers();
            ViewBag.UserCount = response.Embedded.Users.Count;
            return View("index");
        }

        [HttpPost]
        public IActionResult UpdateUser(string id, string name, string displayName, string imageUrl)
        {
            var response = ConversationSender.UpdateUserRequest(id, name, displayName, imageUrl);
            ViewBag.UserUpdateDisplayName = response.DisplayName;
            ViewBag.UserUpdateId = response.Id;
            ViewBag.UserUpdateImageUrl = response.ImageUrl;
            ViewBag.UserUpdateSelf = response.Links.Self.Href;
            ViewBag.UserUpdateName = response.Name;
            return View("index");
        }

        [HttpPost]
        public IActionResult DeleteUser(string id)
        {
            var response = ConversationSender.DeleteUser(id);
            ViewBag.UserStatus = response == System.Net.HttpStatusCode.NoContent ? "Successfully deleted user " : "Something went wrong while deleting Conversation " + response.ToString();
            return View("index");
        }

        [HttpPost]
        public IActionResult CreateMemberWithUserId(string conversationId, string userId, CreateMemberRequestBase.CreateMemberAction action)
        {
            var response = ConversationSender.CreateMemberWithUserId(conversationId, userId, action);
            ViewBag.MemberCreateId = response.Id;
            ViewBag.MemberCreatename = response.Name;
            ViewBag.MemberCreateDisplayName = response.DisplayName;
            return View("index");
        }

        [HttpPost]
        public IActionResult CreateMemberWithUserName(string conversationId, string userName, CreateMemberRequestBase.CreateMemberAction action)
        {
            var response = ConversationSender.CreateMemberWithUserName(conversationId, userName, action);
            ViewBag.MemberCreateWithNameid = response.Id;
            ViewBag.MemberCreateWithNameName = response.Name;
            ViewBag.MemberCreateWithNameDisplayName = response.DisplayName;
            return View("index");
        }

        [HttpPost]
        public IActionResult UpdateMember(string conversationId, string memberId, UpdateMemberRequest.MemberState state)
        {
            var response = ConversationSender.UpdateMember(conversationId, memberId, state);
            ViewBag.MemberUpdateid = response.Id;
            ViewBag.MemberUpdateName = response.Name;
            ViewBag.MemberUpdateDisplayName = response.DisplayName;
            ViewBag.MemberUpdateState = response.State;
            return View("index");
        }

        [HttpPost]
        public IActionResult GetMember(string conversationId, string memberId)
        {
            var response = ConversationSender.GetMember(conversationId, memberId);
            ViewBag.MemberGetId = response.Id;
            ViewBag.MemberGetName = response.Name;
            ViewBag.MemberGetDisplayName = response.DisplayName;
            ViewBag.MemberGetState = response.State;
            return View("index");
        }

        [HttpPost]
        public IActionResult ListMembers(string conversationId)
        {
            var response = ConversationSender.ListMembers(conversationId);

            ViewBag.MemberCount = response.Embedded.Members.Count;
            return View("index");
        }

        [HttpPost]
        public IActionResult DeleteMember(string conversationId, string memberId)
        {
            var response = ConversationSender.DeleteMember(conversationId, memberId);

            ViewBag.MemberStatus = response == System.Net.HttpStatusCode.NoContent ? "Successfully deleted member" : "Encountered an issue while deleteing member : " + response.ToString();
            return View("index");
        }

        [HttpPost]
        public IActionResult CreateTextEvent(string conversationId, string to, string from, string text)
        {
            var response = ConversationSender.CreateEventWithText(to, from, text, conversationId);

            ViewBag.CreateTextEventId = response.Id;
            return View("index");
        }

        [HttpPost]
        public IActionResult CreateCustomEvent(string conversationid, string to, string from, string type)
        {
            var response = ConversationSender.CreateCustomEvent(type, to, from, conversationid);

            ViewBag.CreateCustomEventId = response.Id;
            return View("index");
        }

        [HttpPost]
        public IActionResult ListEvents(string conversationId, string start_id, string end_id)
        {
            var response = ConversationSender.ListEvents(conversationId, start_id, end_id);

            ViewBag.EventCount = response.Embedded.Events.Count;
            return View("index");
        }

        [HttpPost]
        public IActionResult GetEvent(string eventId, string conversationId)
        {
            var response = ConversationSender.GetEvent(conversationId, eventId);

            ViewBag.GetEventId = response.Id;
            return View("index");
        }

        [HttpPost]
        public IActionResult DeleteEvent(string eventId, string conversationId)
        {
            var response = ConversationSender.DeleteEvent(conversationId, eventId);
            ViewBag.EventStatus = response == System.Net.HttpStatusCode.NoContent ? "Event deleted successfully" : "Encountered a problem when deleting event " + response.ToString();
            return View("index");
        }
    }
}