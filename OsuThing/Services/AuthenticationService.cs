using System.Text.Json;
using Microsoft.AspNetCore.Http.Json;
using OsuThing.Models;

namespace OsuThing.Services;

public class AuthenticationService
{
    public static async Task<AuthenticationModel?> Authenticate()
    {
        // First line is client_id, second line is client_secret
        string[] apiKeys = await File.ReadAllLinesAsync("apikeys");
        var values = new Dictionary<string, string>
        {
            { "client_id", apiKeys[0] },
            {"client_secret", apiKeys[1]},
            {"grant_type", "client_credentials"},
            {"scope", "public"}
        };
        
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = false,
            IncludeFields = true
        };
        
        var content = new FormUrlEncodedContent(values);
        var client = new HttpClient();
        
        var response = await client.PostAsync("https://osu.ppy.sh/oauth/token", content);
        var jsonModel = await response.Content.ReadAsStringAsync();
        
        return JsonSerializer.Deserialize<AuthenticationModel>(jsonModel, options);
    }
}