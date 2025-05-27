using OsuThing.Models;
using OsuThing.Services.Interfaces;

namespace OsuThing.Services;

public class UserService(IApiService apiService) : IUserService
{
    private IApiService ApiService { get; } = apiService;

    public async Task<UserModel?> FindUser(string? userName)
    {
        var requestParams = $"users/{userName}/osu";
        return await ApiService.GetAsync<UserModel>(requestParams);
    }

    public async Task<PerformanceModel> GetTopPlayers()
    {
        const string requestParams = "rankings/osu/performance";
        return await ApiService.GetAsync<PerformanceModel>(requestParams) ?? new PerformanceModel();
    }
}