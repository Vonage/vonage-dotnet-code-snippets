# Nexmo APIs Quickstart Examples for CSharp

Quickstarts also available for: [Java](https://github.com/nexmo-community/nexmo-java-quickstart), [Node.js](https://github.com/nexmo-community/nexmo-node-quickstart), [PHP](https://github.com/nexmo-community/nexmo-php-quickstart), [Python](https://github.com/nexmo-community/nexmo-python-quickstart), [Ruby](https://github.com/nexmo-community/nexmo-ruby-quickstart)

The purpose of the quickstart guide is to provide simple examples focused on one goal. For example, sending an SMS, handling an incoming SMS webhook or making a Text to Speech call.

## Configure with Your Nexmo Credentials

To use this sample you will first need a [Nexmo account](https://dashboard.nexmo.com/sign-up). Once you have your own API credentials, Create a Nexmo Client instance and pass in credentials in the constructor.

```csharp
var client = new Client(creds: new Nexmo.Api.Request.Credentials
                {
                    ApiKey = "NEXMO-API-KEY",
                    ApiSecret = "NEXMO-API-SECRET"
                });
```

Alternatively, provide the nexmo URLs, API key, secret, and application credentials (for JWT) in ```appsettings.json```:

```json
{
  "appSettings": {
    "Nexmo.UserAgent": "myApp/1.0",
    "Nexmo.Url.Rest": "https://rest.nexmo.com",
    "Nexmo.Url.Api": "https://api.nexmo.com",
    "Nexmo.api_key": "NEXMO-API-KEY",
    "Nexmo.api_secret": "NEXMO-API-SECRET",
    "Nexmo.Application.Id": "ffffffff-ffff-ffff-ffff-ffffffffffff",
    "Nexmo.Application.Key": "c:\\path\\to\\your\\application\\private.key"
  }
}
```

For some of the examples, you will need to [buy a number](https://dashboard.nexmo.com/buy-numbers).

## TLS Upgrade

Nexmo permanently disabled support of legacy TLSv1 and TLSv1.1 protocols. Vulnerabilities within these TLS versions are serious and, left unaddressed, put organizations at risk of being breached. The only supported encryption protocol for HTTPS connections is now TLSv1.2. All API requests and all web requests to the Nexmo Dashboard using legacy TLS protocols will be rejected.

In case you are still using a legacy TLS protocol, make sure to force your app to TLSv1.2 by adding this line of code :

```csharp
System.Net.ServicePointManager.SecurityProtocol =  System.Net.SecurityProtocolType.Tls12;
```

## Request an Example

Please [raise an issue](https://github.com/nexmo-community/nexmo-dotnet-quickstart/issues) to request an example that isn't present within the quickstart. Pull requests will be gratefully received.

## License

This code is licensed under the [MIT](https://github.com/nexmo-community/nexmo-java-quickstart/blob/master/LICENSE.txt) license.
