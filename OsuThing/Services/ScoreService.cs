using System.Collections.Specialized;
using System.Text.Json;
using OsuThing.Enums;
using OsuThing.Models;
using OsuThing.Services.Interfaces;

namespace OsuThing.Services;

public class ScoreService(IApiService apiService) : IScoreService
{
    private IApiService ApiService { get; } = apiService;
    
    public async Task<IEnumerable<ScoreModel>?> GetUserScores(string userName, UserScoreType type, int count)
    {
        var requestParams = $"users/{userName}/scores/{type.ToString().ToLower()}";
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
            return await ApiService.GetAsync<UserScoreModel>(requestParams, query) ?? new UserScoreModel();
        }
        catch (JsonException e)
        {
            Console.WriteLine(e.StackTrace);
            return null;
        }
    }
}