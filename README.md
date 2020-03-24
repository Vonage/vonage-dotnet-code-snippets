# Nexmo APIs code snippets for .NET using CSharp

The purpose of the code snippets project is to provide simple examples focused on one goal. For example, sending an SMS, handling an incoming SMS webhook or making a Text to Speech call.

## Configure with Your Nexmo Credentials

To use this sample you will first need a [Nexmo account](https://dashboard.nexmo.com/sign-up). Once you have your own API credentials, Create a Nexmo Client instance and pass in credentials in the constructor.

Setting up enviornment variables

### Configuring Enviornment Variables

Open the sln file. For each project, right click and go to properties -> debug -> Enviornment Variables. Alternitively you can edit the enviornment variables in the Properties/launchSettings.json file associated with each project

### Enviornment Variable Reference

Key | Description
----|------------
`NEXMO_API_KEY` | Your API key
`NEXMO_API_SECRET` | Nexmo API secret
`NEXMO_PRIVATE_KEY_PATH` | Path to a private key for your nexmo app
`NEXMO_APPLICATION_ID` | Your application ID
`NEXMO_API_SIGNATURE_SECRET` | Nexmo SIGNATURE_SECRET from the Dashboard. This is different to the usual API_SECRET.
`CODE` | User Supplied Verification code (for checking verify requests)
`SMS_CALLBACK_URL` | Callback URL that you would like to receive SMS webhooks to
`DIGITS` | DTMF Digits to play into app
`API_KEY` | API key to apply an update to
`VOICE_CALLBACK_VALUE` | A SIP URI, telephone number or app ID (depending on `VOICE_CALLBACK_TYPE`)
`VOICE_CALLBACK_TYPE` | `sip`, `tel` or `app`
`NEXMO_NUMBER` | Nexmo Number used for Caller ID or lvn you want to purchase/cancel/update
`NEXMO_NUMBER_FEATURES` | `VOICE` or `SMS` or `VOICE,SMS`
`TO_NUMBER` | Number to send an SMS to.
`TEXT` | Text to be played into call via text-to-speech
`NEXMO_REDACT_ID` | Nexmo ID to use for redaction
`REQUEST_ID` | The ID of the request to search (returned when the request is started) - also request to operate on for verify
`INSIGHT_NUMBER` | The number to provide insight information for.
`NEXMO_BRAND_NAME` | The alphanumeric string that represents the name or number of the organisation sending the message.
`UUID` | The UUID of the call leg  to modify.
`NUMBER_SEARCH_PATTERN` | Whether to look for `NUMBER_SEARCH_CRITERIA` at the beginning of the number (`0`), anywhere within the number (`1`) or at the end of the number (`2`)
`NUMBER_SEARCH_CRITERIA` | The number pattern you want to search for, e.g. `234`
`RECIPIENT_NUMBER` | Telephone number to verify, in E.164 format
`NCCO_URL` | The URL of the NCCO to transfer control to, eg `https://developer.nexmo.com/ncco/tts.json`
`VOICE_STATUS_URL` | The webhook URL that Nexmo makes a request to when a call completes
`BRAND_NAME` | Included in the message to explain who is confirming the phone number
`NEXMO_NUMBER_TYPE` | `landline`, `mobile-lvn` or `landline-toll-free`
`COUNTRY_CODE`| The two-character country code for the number you want to purchase, e.g. `GB`
`RECORDING_URL` |  This is the URL to the recording supplied in the record even webhook
`URL` | The URL of the audio file that will be played.
`FROM_NUMBER` | The phone number you are sending the message from.
`NEXMO_REDACT_TYPE` | Type of transaction to redact `Outbound` or `Inbound`
`NEXMO_REDACT_PRODUCT` | Product you are redacting for: `Sms`, `Voice`, `NumberInsight`, `Verify`, `VerifySdk`, `Messages`
`NEXMO_SECRET_ID` | The secret to revoke/retrieve
`NEW_SECRET` | The new secret to use with this API key

## Other option for setting Enviornment Variables

If you just want to set the enviornment variables via code you can do so by:

1. Remove the field from the Properties/launchSettings.Json file
2. In the snippet - edit the string values on the right side of the `??` :
```csharp
var NEXMO_API_KEY = Environment.GetEnvironmentVariable("NEXMO_API_KEY") ?? "CHANGE_ME";
```

As the enviornment variable has been removed from the launchSettings.json file it will return null when read into the enviornment - causing the app to default to the alternate string value.

## Running the Code Snippets

### CLI Code Snippets

The non-webhook snippets are designed to be run from the cli - in order to run any given snippet you will need to pass in the argument -s or -snippet and set it equal to the partially qualified name of the snippet, e.g.

```ps
dotnet run --project .\DotNetCliCodeSnippets\DotnetCliCodeSnippets.csproj --s=Messaging.SendSms
```

### Webhook snippets

The webhook code snippets are designed to be run in an MVC controller in IIS or IIS Express. Each controller defintes it's own snippet or set of snippets.

For example the inbound-sms snippet is located at 

`/sms/webhooks/inbound-sms`

### Using Ngrok

In order to test the incoming webhook data from Nexmo, the Nexmo API needs an externally accessible URL to send that data to. A commonly used service for development and testing is ngrok. The service will provide you with an externally available web address that creates a secure tunnel to your local environment. The [Nexmo Developer Platform](https://developer.nexmo.com/concepts/guides/testing-with-ngrok) has a guide to getting started with testing with ngrok. 

Once you have your ngrok URL, you can enter your [Nexmo Dashboard](https://dashboard.nexmo.com) and supply it as the `EVENT URL` for any Nexmo service that sends event data via a webhook. A good test case is creating a Voice application and providing the ngrok URL in the following format as the event url: 

The snippet webhook path above is then translated to:

`#{ngrok URL}/sms/webhooks/inbound-sms`

When routed through ngrok.

## working with Numbers

For some of the examples, you will need to [buy a number](https://dashboard.nexmo.com/buy-numbers).

## TLS Upgrade

Nexmo permanently disabled support of legacy TLSv1 and TLSv1.1 protocols. Vulnerabilities within these TLS versions are serious and, left unaddressed, put organizations at risk of being breached. The only supported encryption protocol for HTTPS connections is now TLSv1.2. All API requests and all web requests to the Nexmo Dashboard using legacy TLS protocols will be rejected.

In case you are still using a legacy TLS protocol, make sure to force your app to TLSv1.2 by adding this line of code :

```csharp
System.Net.ServicePointManager.SecurityProtocol =  System.Net.SecurityProtocolType.Tls12;
```

## Request an Example

Please [raise an issue](https://github.com/Nexmo/nexmo-dotnet/issues) to request an example that isn't present within the code snippets. Pull requests will be gratefully received.

## Contributing 

We ❤️ contributions from everyone! [Bug reports](https://github.com/Nexmo/nexmo-dotnet-code-snippets/issues), [bug fixes](https://github.com/Nexmo/nexmo-dotnet-code-snippets/pulls) and feedback on the application is always appreciated. Look at the [Contributor Guidelines](https://github.com/Nexmo/nexmo-dotnet-code-snippets/blob/master/CONTRIBUTING.md) for more information and please follow the [GitHub Flow](https://guides.github.com/introduction/flow/index.html).

## License

This code is licensed under the [MIT](https://github.com/Nexmo/nexmo-dotnet-code-snippets/blob/master/LICENSE.md) license.
