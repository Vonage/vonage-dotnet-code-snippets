using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vonage;
using Vonage.Common.Monads;
using Vonage.Request;

namespace DotnetCliCodeSnippets;

public class JwtSnippet : ICodeSnippet
{
	public Task Execute()
	{
		var VONAGE_APPLICATION_ID = Environment.GetEnvironmentVariable("VONAGE_APP_ID") ?? "VONAGE_APP_ID";
		var VONAGE_APPLICATION_PRIVATE_KEY_PATH = Environment.GetEnvironmentVariable("VONAGE_PRIVATE_KEY_PATH") ??
		                                          "VONAGE_PRIVATE_KEY_PATH";
		string token;
		Result<string> result;
		var credentials =
			Credentials.FromAppIdAndPrivateKeyPath(VONAGE_APPLICATION_ID, VONAGE_APPLICATION_PRIVATE_KEY_PATH);
		var payload = new Dictionary<string, object>
		{
			{"sub", "alice"},
			{"exp", DateTimeOffset.UtcNow.AddDays(1).ToUnixTimeSeconds().ToString()},
			{
				"acl", new Dictionary<string, object>
				{
					["paths"] = new Dictionary<string, object>
					{
						["/*/users/**"] = new { },
					},
				}
			},
		};

		// With the Jwt static method CreateToken
		// Using ApplicationId and ApplicationKey values 
		token = Jwt.CreateToken(credentials.ApplicationId, credentials.ApplicationKey, payload);

		// With a Jwt instance
		ITokenGenerator tokenGenerator = new Jwt();

		// Using the credentials instance
		result = tokenGenerator.GenerateToken(credentials, payload);

		// Using ApplicationId and ApplicationKey values
		result = tokenGenerator.GenerateToken(credentials.ApplicationId, credentials.ApplicationKey, payload);
		return Task.CompletedTask;
	}
}