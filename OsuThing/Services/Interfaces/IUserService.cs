using OsuThing.Models;

namespace OsuThing.Services.Interfaces;

public interface IUserService
{
    Task<UserModel?> FindUser(string? userName);
    Task<PerformanceModel> GetTopPlayers(string mode);
}