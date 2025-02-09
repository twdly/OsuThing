using Microsoft.AspNetCore.Components;
using OsuThing.Models;
using OsuThing.Services;

namespace OsuThing.Pages;

// ReSharper disable once UnusedType.Global
public partial class ScoreComparison
{
    [Inject] private ScoreService ScoreService { get; set; } = null!;

    [Inject] private UserService UserService { get; set; } = null!;
    
    [Inject] private BeatmapService BeatmapService { get; set; } = null!;

    [Inject] private AuthenticationService AuthenticationService { get; set; } = null!;
    
    private UserModel? _user1;
    private UserModel? _user2;
    private UserScoreModel? _score1;
    private UserScoreModel? _score2;
    private BeatmapSetModel? _beatmapSet;
    private int? _mapId;
    private bool _getScoreButtonClicked;
    
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
    
    private async void FindMapAndScores()
    {
        _getScoreButtonClicked = true;
        if (_mapId != null)
        {
            _score1 = await ScoreService!.GetBeatmapScore((int)_mapId, _user1!.Id);
            _score2 = await ScoreService!.GetBeatmapScore((int)_mapId, _user2!.Id);
            if (_score1 != null)
            {
                _beatmapSet = await BeatmapService.GetSetFromId(_score1.Score.Beatmap.SetId);
            }
        }
        StateHasChanged();
    }
}