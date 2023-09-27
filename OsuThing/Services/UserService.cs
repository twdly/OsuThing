using System.Net.Http.Headers;
using System.Text.Json;
using System.Web;
using OsuThing.Models;

namespace OsuThing.Services;

public class UserService
{
    private const string Endpoint = "https://osu.ppy.sh/api/v2/";
    
    public static async Task<UserModel?> FindUser(IHttpClientFactory clientFactory, AuthenticationModel auth, string? userName)
    {
        var requestParams = $"users/{userName}/osu";
        var builder = new UriBuilder(Endpoint + requestParams);
        var query = HttpUtility.ParseQueryString(builder.Query);
        query["key"] = "username";
        builder.Query = query.ToString();
        var request = new HttpRequestMessage(HttpMethod.Get, builder.ToString());
        
        request.Content = new StringContent("application/json");
        request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
        request.Headers.Add("Authorization", $"Bearer {auth.AccessToken}");

        var client = clientFactory.CreateClient();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        var response = await client.SendAsync(request);
        var responseString = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<UserModel>(responseString);
    }
}