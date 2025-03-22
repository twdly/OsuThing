using Microsoft.AspNetCore.Components;
using OsuThing.Enums;
using OsuThing.Models;
using OsuThing.Services.Interfaces;

namespace OsuThing.Pages;

public partial class UserScores
{
    [Inject] private IScoreService ScoreService { get; set; } = null!;
    [Inject] private IUserService UserService { get; set; } = null!;
    
    private IEnumerable<ScoreModel> _scores = [];
    private UserModel? _user;
    private string _scoresMessage = "";
    private UserScoreType _scoreType = UserScoreType.Best; // Default type is best as most players care primarily about the PP value of their score
    private int? _scoreCount = 100;

    [SupplyParameterFromQuery] private string? User { get; set; }
    private bool SearchImmediately { get; set; }

    private async Task GetScores()
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

    private bool IsScoreButtonDisabled()
    {
        return _scoreCount == null || _scoreCount <= 0 || _user?.Username == null;
    }

    private void SetScoreType(UserScoreType type)
    {
        _scoreType = type;
    }

    private async Task HandleUserSelected(UserModel userModel)
    {
        _user = userModel;

        if (!SearchImmediately) return;
        SearchImmediately = false;
        await GetScores();
    }

    private static string CapitaliseString(string stringToCapitalise)
    {
        var capital = stringToCapitalise[0];
        var remaining = stringToCapitalise[1..];
        return char.ToUpper(capital) + remaining;
    }

    protected override Task OnInitializedAsync()
    {
        if (User != null)
        {
            SearchImmediately = true;
        }

        return base.OnInitializedAsync();
    }
}