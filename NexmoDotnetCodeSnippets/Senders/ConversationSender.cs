using Nexmo.Api;
using NexmoDotnetCodeSnippets.Authentication;
using Nexmo.Api.Conversations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;

namespace NexmoDotnetCodeSnippets.Senders
{
    public class ConversationSender
    {
        public class DemonstrativeProperties
        {
            public string foo { get; set; }
        }

        public class DemonstrativeCustomEventBody
        {
            public string foo { get; set; }
        }

        public static Nexmo.Api.Conversations.Conversation CreateConversation(string NAME, string DISPLAY_NAME, string IMAGE_URL)
        {
            var client = FullAuth.GetClient();
            var PROPERTIES = new DemonstrativeProperties() { foo = "foo" };

            var request = new CreateConversationRequest()
            {
                DisplayName = DISPLAY_NAME,
                Name = NAME,
                ImageUrl = IMAGE_URL,
                Properties = new Properties(PROPERTIES)
            };
            var response = client.Conversation.CreateConversation(request);
            return response;
        }

        public static Nexmo.Api.Conversations.Conversation GetConversation(string CONVERSATION_ID)
        {
            var client = FullAuth.GetClient();
            var response = client.Conversation.GetConversation(CONVERSATION_ID);
            return response;
        }
        
        public static CursorBasedListResponse<ConversationList> ListConversation()
        {
            var client = FullAuth.GetClient();
            uint PAGE_SIZE = 10;
            string ORDER = "asc";
            string CURSOR = "https://www.example.com/aconversation";
            var parameters = new CursorListParams() { page_size = PAGE_SIZE, order = ORDER, cursor = CURSOR };
            var response = client.Conversation.ListConversations(parameters);
            return response;
        }

        public static Nexmo.Api.Conversations.Conversation UpdateConversation(string CONVERSATION_ID, string NAME, string DISPLAY_NAME, string IMAGE_URL)
        {
            var client = FullAuth.GetClient();
            var PROPERTIES = new DemonstrativeProperties() { foo = "foo" };

            var request = new UpdateConversationRequest() 
            { 
                DisplayName = DISPLAY_NAME, 
                Name = NAME, 
                ImageUrl = IMAGE_URL, 
                Properties = new Properties(PROPERTIES)
            };

            var response = client.Conversation.UpdateConversation(request, CONVERSATION_ID);
            return response;
        }

        public static HttpStatusCode DeleteConversation(string CONVERSATION_ID)
        {
            var client = FullAuth.GetClient();
            var response = client.Conversation.DeleteConversation(CONVERSATION_ID);
            return response;
        }

        public static User CreateUser(string NAME, string DISPLAY_NAME, string IMAGE_URL)
        {
            var client = FullAuth.GetClient();
            var PROPERTIES = new DemonstrativeProperties() { foo = "foo" };
            
            var request = new CreateUserRequest()
            {
                DisplayName = DISPLAY_NAME,
                Name = NAME,
                ImageUrl = IMAGE_URL,
                Properties = new Properties(PROPERTIES)
            };

            var response = client.Conversation.CreateUser(request);
            return response;
        }

        public static User GetUser(string USER_ID)
        {
            var client = FullAuth.GetClient();

            var response = client.Conversation.GetUser(USER_ID);
            return response;
        }

        public static CursorBasedListResponse<UserList> ListUsers()
        {
            var client = FullAuth.GetClient();
            uint PAGE_SIZE = 10;
            string ORDER = "asc";
            string CURSOR = "https://www.example.com/aUser";
            var parameters = new CursorListParams() { page_size = PAGE_SIZE, order = ORDER, cursor = CURSOR };
            var response = client.Conversation.ListUsers(parameters);
            return response;
        }

        public static User UpdateUserRequest(string USER_ID, string NAME, string DISPLAY_NAME, string IMAGE_URL)
        {
            var client = FullAuth.GetClient();

            var PROPERTIES = new DemonstrativeProperties() { foo = "bar" };

            var request = new UpdateUserRequest()
            {
                Name = NAME,
                DisplayName = DISPLAY_NAME,
                ImageUrl = IMAGE_URL,
                Properties = new Properties(PROPERTIES)
            };

            var response = client.Conversation.UpdateUser(request,USER_ID);

            return response;
        }

        public static HttpStatusCode DeleteUser(string USER_ID)
        {
            var client = FullAuth.GetClient();

            var response = client.Conversation.DeleteUser(USER_ID);

            return response;
        }

        public static Member CreateMemberWithUserId(string CONVERSATION_ID, string USER_ID, CreateMemberRequestBase.CreateMemberAction ACTION)
        {
            var client = FullAuth.GetClient();

            var request = new CreateMemberWithIdRequest()
            {
                Id = USER_ID,
                Action = ACTION
            };

            var response = client.Conversation.CreateMember(request, CONVERSATION_ID);

            return response;
        }

        public static Member CreateMemberWithUserName(string CONVERSATION_ID, string USER_NAME, CreateMemberRequestBase.CreateMemberAction ACTION)
        {
            var client = FullAuth.GetClient();

            var request = new CreateMemberWithNameRequest()
            {
                Name = USER_NAME,
                Action = ACTION
            };

            var response = client.Conversation.CreateMember(request, CONVERSATION_ID);
            return response;
        }

        public static Member GetMember(string CONVERSATION_ID, string MEMBER_ID)
        {
            var client = FullAuth.GetClient();
            var response = client.Conversation.GetMember(MEMBER_ID, CONVERSATION_ID);
            return response;
        }

        public static CursorBasedListResponse<MemberList> ListMembers(string CONVERSATION_ID)
        {
            var client = FullAuth.GetClient();
            uint PAGE_SIZE = 10;
            string ORDER = "asc";
            string CURSOR = "https://www.example.com/aUser";

            var parameters = new CursorListParams() { page_size = PAGE_SIZE, order = ORDER, cursor = CURSOR };
            var response = client.Conversation.ListMembers(parameters, CONVERSATION_ID);

            return response;
        }

        public static Member UpdateMember(string CONVERSATION_ID, string MEMBER_ID, UpdateMemberRequest.MemberState STATE)
        {
            var client = FullAuth.GetClient();

            var request = new UpdateMemberRequest() { State = STATE };

            var response = client.Conversation.UpdateMember(request, MEMBER_ID, CONVERSATION_ID);

            return response;
        }

        public static HttpStatusCode DeleteMember(string CONVERSATION_ID, string MEMBER_ID)
        {
            var client = FullAuth.GetClient();
            var response = client.Conversation.DeleteMember(MEMBER_ID, CONVERSATION_ID);
            return response;
        }

        public static Event CreateEventWithText(string TO, string FROM, string TEXT, string CONVERSATION_ID)
        {
            var client = FullAuth.GetClient();

            var request = new CreateTextEventRequest()
            {
                Body = new TextEventBody()
                {
                    Text = TEXT
                },
                To = TO,
                From = FROM
            };

            var response = client.Conversation.CreateEvent(request, CONVERSATION_ID);

            return response;
        }

        public static Event CreateCustomEvent(string TYPE, string TO, string FROM, string CONVERSATION_ID)
        {
            var client = FullAuth.GetClient();
            var BODY = new DemonstrativeCustomEventBody() { foo = "bar" };
            var request = new CreateCustomEventRequest<DemonstrativeCustomEventBody>()
            {
                Body = BODY,
                From = FROM,
                To = TO,
                Type = TYPE
            };
            var response = client.Conversation.CreateEvent(request, CONVERSATION_ID);
            return response;
        }

        public static CursorBasedListResponse<EventList> ListEvents(string CONVERSATION_ID, string START_ID, string END_ID)
        {
            var client = FullAuth.GetClient();

            var parameters = new EventListParams()
            {
                start_id = START_ID,
                end_id = END_ID
            };
            var response = client.Conversation.ListEvents(parameters, CONVERSATION_ID);

            return response;
        }

        public static Event GetEvent(string CONVERSATION_ID, string EVENT_ID)
        {
            var client = FullAuth.GetClient();

            var response = client.Conversation.GetEvent(EVENT_ID, CONVERSATION_ID);

            return response;
        }

        public static HttpStatusCode DeleteEvent(string CONVERSATION_ID, string EVENT_ID)
        {
            var client = FullAuth.GetClient();

            var response = client.Conversation.DeleteEvent(EVENT_ID, CONVERSATION_ID);

            return response;
        }
    }
}
