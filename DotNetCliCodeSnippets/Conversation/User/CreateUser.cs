﻿#region

using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Vonage;
using Vonage.Request;
using Vonage.Users.CreateUser;

#endregion

namespace DotnetCliCodeSnippets.Conversation.User;

public class CreateUser : ICodeSnippet
{
    public async Task Execute()
    {
        var VONAGE_API_KEY = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
        var VONAGE_API_SECRET = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";
        var USER_NAME = Environment.GetEnvironmentVariable("USER_NAME") ?? "USER_NAME";
        var USER_DISPLAY_NAME = Environment.GetEnvironmentVariable("USER_DISPLAY_NAME") ?? "USER_DISPLAY_NAME";
        var credentials = Credentials.FromApiKeyAndSecret(VONAGE_API_KEY, VONAGE_API_SECRET);
        var client = new VonageClient(credentials);
        var response = await client.UsersClient.CreateUserAsync(CreateUserRequest.Build()
            .WithName(USER_NAME)
            .WithDisplayName(USER_DISPLAY_NAME)
            .Create());
        Console.WriteLine(JsonConvert.SerializeObject(response));
    }
}