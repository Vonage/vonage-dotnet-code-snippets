using Vonage;
using Vonage.Request;
using Vonage.Numbers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCliCodeSnippets.Numbers
{
    public class UpdateNumber : ICodeSnippet
    {
        public async Task Execute()
        {
            var vonageApiKey = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
            var vonageApiSecret = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";

            var countryCode = Environment.GetEnvironmentVariable("COUNTRY_CODE") ?? "COUNTRY_CODE";
            var vonageNumber = Environment.GetEnvironmentVariable("VONAGE_NUMBER") ?? "VONAGE_NUMBER";

            var smsCallbackUrl = Environment.GetEnvironmentVariable("SMS_CALLBACK_URL") ?? "SMS_CALLBACK_URL";
            
            var vonageApplicationId = Environment.GetEnvironmentVariable("VONAGE_APPLICATION_ID") ?? "VONAGE_APPLICATION_ID";

            var voiceCallbackType = Environment.GetEnvironmentVariable("VOICE_CALLBACK_TYPE") ?? "VOICE_CALLBACK_TYPE";
            var voiceCallbackValue = Environment.GetEnvironmentVariable("VOICE_CALLBACK_VALUE") ?? "VOICE_CALLBACK_VALUE";
            var voiceStatusUrl = Environment.GetEnvironmentVariable("VOICE_STATUS_URL") ?? "VOICE_STATUS_URL";


            var credentials = Credentials.FromApiKeyAndSecret(vonageApiKey, vonageApiSecret);
            var client = new VonageClient(credentials);

            var request = new UpdateNumberRequest()
            {
                Country = countryCode,
                Msisdn = vonageNumber,
                MoHttpUrl = smsCallbackUrl,
                AppId = vonageApplicationId,
                VoiceCallbackType = voiceCallbackType,
                VoiceCallbackValue = voiceCallbackValue,
                VoiceStatusCallback = voiceStatusUrl
            };

            var response = await client.NumbersClient.UpdateANumberAsync(request);

            Console.WriteLine($"Response Error Code: {response.ErrorCode} and Error Code Label: {response.ErrorCodeLabel}");
        }
    }
}
