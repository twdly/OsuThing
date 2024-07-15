using System.Net.Http.Headers;
using System.Text.Json;
using OsuThing.Models;

namespace OsuThing.Services;

public class BeatmapService
{
    private const string Endpoint = "https://osu.ppy.sh/api/v2/";

    public static async Task<BeatmapSetModel?> GetSetFromId(IHttpClientFactory clientFactory, AuthenticationModel auth, int beatmapId)
    {
        var requestParams = $"beatmapsets/{beatmapId}";
        var builder = new UriBuilder(Endpoint + requestParams);
        var request = new HttpRequestMessage(HttpMethod.Get, builder.ToString());
        
        request.Content = new StringContent("application/json");
        request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
        request.Headers.Add("Authorization", $"Bearer {auth.AccessToken}");

        var client = clientFactory.CreateClient();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        var response = await client.SendAsync(request);
        var responseString = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<BeatmapSetModel>(responseString);
    }
}