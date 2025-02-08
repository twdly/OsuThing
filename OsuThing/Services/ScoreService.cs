using System.Collections.Specialized;
using System.Text.Json;
using OsuThing.Models;

namespace OsuThing.Services;

public class ScoreService(ApiService apiService)
{
    private ApiService ApiService { get; } = apiService;
    
    public async Task<IEnumerable<ScoreModel>?> GetUserScores(string userName, string type, int count)
    {
        var requestParams = $"users/{userName}/scores/{type}";
        var query = new NameValueCollection
        {
            ["mode"] = "osu",
            ["limit"] = count.ToString()
        };
        return await ApiService.GetAsync<IEnumerable<ScoreModel>>(requestParams, query);
    }

    public async Task<UserScoreModel?> GetBeatmapScore(int beatmapId, int userId)
    {
        var requestParams = $"beatmaps/{beatmapId}/scores/users/{userId}";
        var query = new NameValueCollection
        {
            ["mode"] = "osu"
        };
        try
        {
            return await ApiService.GetAsync<UserScoreModel>(requestParams, query);
        }
        catch (JsonException e)
        {
            Console.WriteLine(e.StackTrace);
            return null;
        }
    }
}