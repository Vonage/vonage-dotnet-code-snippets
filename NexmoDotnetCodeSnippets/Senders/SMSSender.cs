using Nexmo.Api;
using NexmoDotnetCodeSnippets.Authentication;

namespace NexmoDotnetCodeSnippets.Senders
{
    public class SMSSender
    {   

        public static SMS.SMSResponse SendSMS(string TO_NUMBER, string NEXMO_BRAND_NAME, string message)
        {            
            var client = BasicAuth.GetClient();

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
            var client = BasicAuth.GetClient();

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
