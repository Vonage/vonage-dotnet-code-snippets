using Nexmo.Api;
using Nexmo.Api.Request;
using Nexmo.Api.Numbers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCliCodeSnippets.Numbers
{
    public class UpdateNumber : ICodeSnippet
    {
        public void Execute()
        {
            var NEXMO_API_KEY = Environment.GetEnvironmentVariable("NEXMO_API_KEY") ?? "NEXMO_API_KEY";
            var NEXMO_API_SECRET = Environment.GetEnvironmentVariable("NEXMO_API_SECRET") ?? "NEXMO_API_SECRET";

            var COUNTRY_CODE = Environment.GetEnvironmentVariable("COUNTRY_CODE") ?? "COUNTRY_CODE";
            var NEXMO_NUMBER = Environment.GetEnvironmentVariable("NEXMO_NUMBER") ?? "NEXMO_NUMBER";

            var SMS_CALLBACK_URL = Environment.GetEnvironmentVariable("SMS_CALLBACK_URL") ?? "SMS_CALLBACK_URL";
            
            var NEXMO_APPLICATION_ID = Environment.GetEnvironmentVariable("NEXMO_APPLICATION_ID") ?? "NEXMO_APPLICATION_ID";

            var VOICE_CALLBACK_TYPE = Environment.GetEnvironmentVariable("VOICE_CALLBACK_TYPE") ?? "VOICE_CALLBACK_TYPE";
            var VOICE_CALLBACK_VALUE = Environment.GetEnvironmentVariable("VOICE_CALLBACK_VALUE") ?? "VOICE_CALLBACK_VALUE";
            var VOICE_STATUS_URL = Environment.GetEnvironmentVariable("VOICE_STATUS_URL") ?? "VOICE_STATUS_URL";


            var credentials = Credentials.FromApiKeyAndSecret(NEXMO_API_KEY, NEXMO_API_SECRET);
            var client = new NexmoClient(credentials);

            var request = new UpdateNumberRequest()
            {
                Country = COUNTRY_CODE,
                Msisdn = NEXMO_NUMBER,
                MoHttpUrl = SMS_CALLBACK_URL,
                AppId = NEXMO_APPLICATION_ID,
                VoiceCallbackType = VOICE_CALLBACK_TYPE,
                VoiceCallbackValue = VOICE_CALLBACK_VALUE,
                VoiceStatusCallback = VOICE_STATUS_URL
            };

            var response = client.NumbersClient.UpdateANumber(request);

            Console.WriteLine($"Response Error Code: {response.ErrorCode} and Error Code Label: {response.ErrorCodeLabel}");
        }
    }
}
