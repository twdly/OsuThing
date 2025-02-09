using System.Collections.Specialized;
using OsuThing.Models;
using OsuThing.Services.Interfaces;

namespace OsuThing.Services;

public class BeatmapService(IApiService apiService) : IBeatmapService
{
    private IApiService ApiService { get; } = apiService;

    public async Task<BeatmapSetModel?> GetSetFromId(int beatmapId)
    {
        var requestParams = $"beatmapsets/{beatmapId}";
        return await ApiService.GetAsync<BeatmapSetModel>(requestParams);
    }

    public async Task<BeatmapModel?> GetMapFromId(int beatmapId)
    {
        var requestParams = $"beatmaps/{beatmapId}";
        return await ApiService.GetAsync<BeatmapModel>(requestParams);
    }

    public async Task<IEnumerable<BeatmapSetModel>?> SearchForSets(string searchInput)
    {
        const string requestParams = "beatmapsets/search";
        var query = new NameValueCollection
        {
            ["q"] = searchInput
        };
        var searchResults = await ApiService.GetAsync<BeatmapSetSearchModel>(requestParams, query);
        return searchResults!.BeatmapSets;
    }
}