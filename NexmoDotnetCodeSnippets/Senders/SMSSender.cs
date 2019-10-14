using Nexmo.Api;
using NexmoDotnetCodeSnippets.Authentication;
using Nexmo.Api.Cryptography;

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

        public static SMS.SMSResponse SendSignedSms(string TO_NUMBER, string NEXMO_BRAND_NAME, string message, string NEXMO_API_KEY, string NEXMO_API_SIGNATURE_SECRET, SmsSignatureGenerator.Method method)
        {
            var client = new Nexmo.Api.Client(new Nexmo.Api.Request.Credentials()
            {
                ApiKey = NEXMO_API_KEY,
                SecuritySecret = NEXMO_API_SIGNATURE_SECRET,
                Method = method
            });
            var results = client.SMS.Send(new SMS.SMSRequest
            {
                from = NEXMO_BRAND_NAME,
                to = TO_NUMBER,
                text = message
            });
            return results;
        }
    }
}
