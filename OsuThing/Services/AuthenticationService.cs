using System.Text.Json;
using OsuThing.Models;
using OsuThing.Services.Interfaces;

namespace OsuThing.Services;

public class AuthenticationService(IHttpClientFactory clientFactory) : IAuthenticationService
{
    private IHttpClientFactory ClientFactory { get; } = clientFactory;
    
    private DateTime LastAuthTime { get; set; }
    private AuthenticationModel? CurrentAuth { get; set; }

    private static readonly JsonSerializerOptions Options = new()
    {
        PropertyNameCaseInsensitive = false,
        IncludeFields = true
    };
    
    public async Task<AuthenticationModel?> Authenticate()
    {
        if (CurrentAuth != null && AuthStillValid())
        {
            return CurrentAuth;
        }
        
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
        var client = ClientFactory.CreateClient();
        
        var response = await client.PostAsync("https://osu.ppy.sh/oauth/token", content);
        var jsonModel = await response.Content.ReadAsStringAsync();
        
        CurrentAuth = JsonSerializer.Deserialize<AuthenticationModel>(jsonModel, Options);
        LastAuthTime = DateTime.Now;

        return CurrentAuth;
    }

    private bool AuthStillValid()
    {
        var secondsSinceLastAuth = DateTime.Now.Subtract(LastAuthTime).Seconds;
        return secondsSinceLastAuth < CurrentAuth!.ExpiresIn;
    }
}