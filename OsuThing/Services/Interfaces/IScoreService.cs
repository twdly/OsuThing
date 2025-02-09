using OsuThing.Enums;
using OsuThing.Models;

namespace OsuThing.Services.Interfaces;

public interface IScoreService
{
    Task<IEnumerable<ScoreModel>?> GetUserScores(string userName, UserScoreType type, int count);
    Task<UserScoreModel?> GetBeatmapScore(int beatmapId, int userId);
}