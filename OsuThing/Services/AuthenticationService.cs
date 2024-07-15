using System.Text.Json;
using OsuThing.Models;

namespace OsuThing.Services;

public class AuthenticationService
{
    private static readonly JsonSerializerOptions Options = new()
    {
        PropertyNameCaseInsensitive = false,
        IncludeFields = true
    };
    
    public static async Task<AuthenticationModel?> Authenticate()
    {
        // First line is client_id, second line is client_secret
        var apiKeys = await File.ReadAllLinesAsync("apikey");
        var values = new Dictionary<string, string>
        {
            { "client_id", apiKeys[0] },
            {"client_secret", apiKeys[1]},
            {"grant_type", "client_credentials"},
            {"scope", "public"}
        };
        
        var content = new FormUrlEncodedContent(values);
        var client = new HttpClient();
        
        var response = await client.PostAsync("https://osu.ppy.sh/oauth/token", content);
        var jsonModel = await response.Content.ReadAsStringAsync();
        
        return JsonSerializer.Deserialize<AuthenticationModel>(jsonModel, Options);
    }
}