using OsuThing.Models;

namespace OsuThing.Services;

public class UserService(ApiService apiService)
{
    private ApiService ApiService { get; } = apiService;

    public async Task<UserModel?> FindUser(string? userName)
    {
        var requestParams = $"users/{userName}/osu";
        return await ApiService.GetAsync<UserModel>(requestParams);
    }
}