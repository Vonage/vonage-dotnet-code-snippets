using Nexmo.Api;

namespace NexmoDotnetCodeSnippets.Senders
{
    public class SMSSender
    {   

        public static SMS.SMSResponse SendSMS(string TO_NUMBER, string NEXMO_BRAND_NAME, string message)
        {
            const string API_KEY = "NEXMO_API_KEY";
            const string API_SECRET = "NEXMO_API_SECRET";
            var client = new Client(creds: new Nexmo.Api.Request.Credentials(nexmoApiKey: API_KEY, nexmoApiSecret: API_SECRET));

            var results = client.SMS.Send(new SMS.SMSRequest
            {
                from = NEXMO_BRAND_NAME,
                to = TO_NUMBER,
                text = message
            });

            return results;
        }

        public static SMS.SMSResponse SendSMSUnicode(string TO_NUMBER, string NEXMO_BRAND_NAME, string message)
        {
            const string NEXMO_API_KEY = "NEXMO_API_KEY";
            const string NEXMO_API_SECRET = "NEXMO_API_SECRET";
            var client = new Client(creds: new Nexmo.Api.Request.Credentials(nexmoApiKey: NEXMO_API_KEY, nexmoApiSecret: NEXMO_API_SECRET));

            var messageType = "unicode";
            var results = client.SMS.Send(new SMS.SMSRequest
            {
                from = NEXMO_BRAND_NAME,
                to = TO_NUMBER,
                text = message,
                type = messageType
            });

            return results;
        }
    }
}
