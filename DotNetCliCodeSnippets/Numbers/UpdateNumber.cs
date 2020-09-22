using Vonage;
using Vonage.Request;
using Vonage.Numbers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCliCodeSnippets.Numbers
{
    public class UpdateNumber : ICodeSnippet
    {
        public void Execute()
        {
            var VONAGE_API_KEY = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
            var VONAGE_API_SECRET = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";

            var COUNTRY_CODE = Environment.GetEnvironmentVariable("COUNTRY_CODE") ?? "COUNTRY_CODE";
            var VONAGE_NUMBER = Environment.GetEnvironmentVariable("VONAGE_NUMBER") ?? "VONAGE_NUMBER";

            var SMS_CALLBACK_URL = Environment.GetEnvironmentVariable("SMS_CALLBACK_URL") ?? "SMS_CALLBACK_URL";
            
            var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable("VONAGE_APPLICATION_ID") ?? "VONAGE_APPLICATION_ID";

            var VOICE_CALLBACK_TYPE = Environment.GetEnvironmentVariable("VOICE_CALLBACK_TYPE") ?? "VOICE_CALLBACK_TYPE";
            var VOICE_CALLBACK_VALUE = Environment.GetEnvironmentVariable("VOICE_CALLBACK_VALUE") ?? "VOICE_CALLBACK_VALUE";
            var VOICE_STATUS_URL = Environment.GetEnvironmentVariable("VOICE_STATUS_URL") ?? "VOICE_STATUS_URL";


            var credentials = Credentials.FromApiKeyAndSecret(VONAGE_API_KEY, VONAGE_API_SECRET);
            var client = new VonageClient(credentials);

            var request = new UpdateNumberRequest()
            {
                Country = COUNTRY_CODE,
                Msisdn = VONAGE_NUMBER,
                MoHttpUrl = SMS_CALLBACK_URL,
                AppId = VONAGE_APPLICATION_ID,
                VoiceCallbackType = VOICE_CALLBACK_TYPE,
                VoiceCallbackValue = VOICE_CALLBACK_VALUE,
                VoiceStatusCallback = VOICE_STATUS_URL
            };

            var response = client.NumbersClient.UpdateANumber(request);

            Console.WriteLine($"Response Error Code: {response.ErrorCode} and Error Code Label: {response.ErrorCodeLabel}");
        }
    }
}
