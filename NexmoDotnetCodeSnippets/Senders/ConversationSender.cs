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
    }
}
