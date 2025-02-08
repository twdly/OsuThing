using Microsoft.AspNetCore.Components;
using OsuThing.Models;
using OsuThing.Services;

namespace OsuThing.Pages;

public partial class UserScores
{
    [Inject] private ScoreService ScoreService { get; set; } = null!;
    [Inject] private UserService UserService { get; set; } = null!;
    [Inject] private AuthenticationService AuthenticationService { get; set; } = null!;
    
    private const string Best = "best";
    private const string Recent = "recent";
    private const string Firsts = "firsts";
    
    private AuthenticationModel? _authentication;
    private IEnumerable<ScoreModel> _scores = [];
    private UserModel? _user;
    private string _scoresMessage = "";
    private string _scoreType = "best";
    private int? _scoreCount = 100;

    protected override async Task OnInitializedAsync()
    {
        _authentication = await AuthenticationService.Authenticate();
    }

    private async void GetScores()
    {
        if (_authentication != null && _scoreCount != null && _user != null)
        {
            _scores = await ScoreService.GetUserScores(_authentication, _user.Id.ToString(), _scoreType, _scoreCount.Value) ?? [];
        }
        var foundScoreCount = _scores.Count();
        _scoresMessage = foundScoreCount == 0
            ? "No scores have been found"
            : $"The {foundScoreCount} {_scoreType} scores have been found";
        StateHasChanged();
    }

    private async void FindUser(string? input)
    {
        if (_authentication != null && input != null)
        {
            _user = await UserService.FindUser(_authentication, input);
        }
        StateHasChanged();
    }

    private bool IsScoreButtonDisabled()
    {
        return _authentication == null || _scoreCount == null || _scoreCount <= 0 || _user?.Username == null;
    }

    private void SetScoreType(string type)
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