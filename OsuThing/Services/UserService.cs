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

    public async Task<PerformanceModel> GetTopPlayers(string mode)
    {
        var requestParams = $"rankings/{mode}/performance";
        return await ApiService.GetAsync<PerformanceModel>(requestParams) ?? new PerformanceModel();
    }
}