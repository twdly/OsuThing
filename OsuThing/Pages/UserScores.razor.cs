using Microsoft.AspNetCore.Components;
using OsuThing.Enums;
using OsuThing.Models;
using OsuThing.Services;

namespace OsuThing.Pages;

public partial class UserScores
{
    [Inject] private ScoreService ScoreService { get; set; } = null!;
    [Inject] private UserService UserService { get; set; } = null!;
    
    private IEnumerable<ScoreModel> _scores = [];
    private UserModel? _user;
    private string _scoresMessage = "";
    private UserScoreType _scoreType = UserScoreType.Best; // Default type is best as most players care primarily about the PP value of their score
    private int? _scoreCount = 100;

    private async void GetScores()
    {
        if (_scoreCount != null && _user != null)
        {
            _scores = await ScoreService.GetUserScores(_user.Id.ToString(), _scoreType, _scoreCount.Value) ?? [];
        }
        var foundScoreCount = _scores.Count();
        _scoresMessage = foundScoreCount == 0
            ? "No scores have been found"
            : $"The {foundScoreCount} {_scoreType} scores have been found";
        StateHasChanged();
    }

    private async void FindUser(string? input)
    {
        if (input != null)
        {
            _user = await UserService.FindUser(input);
        }
        StateHasChanged();
    }

    private bool IsScoreButtonDisabled()
    {
        return _scoreCount == null || _scoreCount <= 0 || _user?.Username == null;
    }

    private void SetScoreType(UserScoreType type)
    {
        _scoreType = type;
    }

    private static string CapitaliseString(string stringToCapitalise)
    {
        var capital = stringToCapitalise[0];
        var remaining = stringToCapitalise[1..];
        return char.ToUpper(capital) + remaining;
    }
}