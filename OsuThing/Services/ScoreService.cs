using System.Net.Http.Headers;
using System.Text.Json;
using System.Web;
using OsuThing.Models;

namespace OsuThing.Services;

public class ScoreService
{
    private const string Endpoint = "https://osu.ppy.sh/api/v2/";
    
    public static async Task<IEnumerable<ScoreModel>?> GetUserScores(IHttpClientFactory clientFactory, AuthenticationModel auth, string userName, string type, int count)
    {
        var requestParams = $"users/{userName}/scores/{type}";
        var builder = new UriBuilder(Endpoint + requestParams);
        var query = HttpUtility.ParseQueryString(builder.Query);
        query["mode"] = "osu";
        query["limit"] = count.ToString();
        builder.Query = query.ToString();
        var request = new HttpRequestMessage(HttpMethod.Get, builder.ToString());
        
        request.Content = new StringContent("application/json");
        request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
        request.Headers.Add("Authorization", $"Bearer {auth.AccessToken}");

        var client = clientFactory.CreateClient();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        var response = await client.SendAsync(request);
        var responseString = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<IEnumerable<ScoreModel>>(responseString);
    }

    public static async Task<UserScoreModel?> GetBeatmapScore(IHttpClientFactory clientFactory, AuthenticationModel auth, int beatmapId, int userId)
    {
        var requestParams = $"beatmaps/{beatmapId}/scores/users/{userId}";
        var builder = new UriBuilder(Endpoint + requestParams);
        var query = HttpUtility.ParseQueryString(builder.Query);
        query["mode"] = "osu";
        builder.Query = query.ToString();
        var request = new HttpRequestMessage(HttpMethod.Get, builder.ToString());
        
        request.Content = new StringContent("application/json");
        request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
        request.Headers.Add("Authorization", $"Bearer {auth.AccessToken}");
        
        var client = clientFactory.CreateClient();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        var response = await client.SendAsync(request);
        var responseString = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<UserScoreModel>(responseString);
    }
}