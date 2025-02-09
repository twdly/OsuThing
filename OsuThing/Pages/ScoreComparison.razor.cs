using Microsoft.AspNetCore.Components;
using OsuThing.Models;
using OsuThing.Services.Interfaces;

namespace OsuThing.Pages;

// ReSharper disable once UnusedType.Global
public partial class ScoreComparison
{
    [Inject] private IScoreService ScoreService { get; set; } = null!;

    [Inject] private IUserService UserService { get; set; } = null!;
    
    [Inject] private IBeatmapService BeatmapService { get; set; } = null!;

    [Inject] private IAuthenticationService AuthenticationService { get; set; } = null!;
    
    private UserModel? _user1;
    private UserModel? _user2;
    private UserScoreModel? _score1;
    private UserScoreModel? _score2;
    private BeatmapSetModel? _beatmapSet;
    private BeatmapModel? _beatmap;
    private bool _getScoreButtonClicked;
    private bool _searchButtonClicked;
    
    private async void FindUser(string? input, int userNo)
    {
        if (input != null)
        {
            var foundUser = await UserService.FindUser(input);
            switch (userNo)
            {
                case 1:
                    _user1 = foundUser;
                    break;
                case 2:
                    _user2 = foundUser;
                    break;
            }
        }
        StateHasChanged();
    }
    
    private async void FindScores()
    {
        _getScoreButtonClicked = true;
        _score1 = await ScoreService.GetBeatmapScore(_beatmap!.DiffId, _user1!.Id);
        _score2 = await ScoreService.GetBeatmapScore(_beatmap!.DiffId, _user2!.Id);
        StateHasChanged();
    }

    private void SearchButtonClicked()
    {
        _searchButtonClicked = true;
        StateHasChanged();
    }

    private Task SearchClosed(bool value)
    {
        _searchButtonClicked = value;
        return Task.CompletedTask;
    }

    private async Task GetMap(int id)
    {
        _beatmap = await BeatmapService.GetMapFromId(id);
        _beatmapSet = await BeatmapService.GetSetFromId(_beatmap!.SetId);
        _searchButtonClicked = false;
    }

    private bool IsGetButtonDisabled()
    {
        return !(_beatmap != null && _user1 != null && _user2 != null);
    }
}