using OsuThing.Models;
using OsuThing.Services;

namespace OsuThing.Pages;

// ReSharper disable once UnusedType.Global
public partial class ScoreComparison
{
    private UserModel? _user1;
    private UserModel? _user2;
    private UserScoreModel? _score1;
    private UserScoreModel? _score2;
    private BeatmapSetModel? _beatmapSet;
    private AuthenticationModel? _authentication;
    private int? _mapId;
    private bool _getScoreButtonClicked;
    
    private async void FindUser(string? input, int userNo)
    {
        if (_authentication != null && input != null)
        {
            var foundUser = await UserService.FindUser(ClientFactory, _authentication, input);
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
            _score1 = await ScoreService.GetBeatmapScore(ClientFactory, _authentication!, (int)_mapId, _user1!.Id);
            _score2 = await ScoreService.GetBeatmapScore(ClientFactory, _authentication!, (int)_mapId, _user2!.Id);
            _beatmapSet = await BeatmapService.GetSetFromId(ClientFactory, _authentication!, _score1.Score.Beatmap.SetId);
        }
        StateHasChanged();
    }
    
    protected override async Task OnInitializedAsync()
    {
        _authentication = await AuthenticationService.Authenticate();
    }
}