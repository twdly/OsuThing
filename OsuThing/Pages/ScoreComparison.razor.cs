using Microsoft.AspNetCore.Components;
using OsuThing.Models;
using OsuThing.Services.Interfaces;

namespace OsuThing.Pages;

// ReSharper disable once UnusedType.Global
public partial class ScoreComparison
{
    [Inject] private IScoreService ScoreService { get; set; } = null!;
    
    [Inject] private IBeatmapService BeatmapService { get; set; } = null!;
    
    private UserModel? _user1;
    private UserModel? _user2;
    private string? _username1;
    private string? _username2;
    private UserScoreModel? _score1;
    private UserScoreModel? _score2;
    private BeatmapSetModel? _beatmapSet;
    private BeatmapModel? _beatmap;
    private bool _getScoreButtonClicked;
    private bool _searchButtonClicked;
    
    [SupplyParameterFromQuery] private int? BeatmapId { get; set; }
    [SupplyParameterFromQuery] private string? Username { get; set; }

    private async Task FindScores()
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

    private async Task GetMapFromSearch(int id)
    {
        _beatmap = await BeatmapService.GetMapFromId(id);
        _beatmapSet = await BeatmapService.GetSetFromId(_beatmap!.SetId);
        _searchButtonClicked = false;
    }

    private bool IsGetButtonDisabled()
    {
        return !(_beatmap != null && _user1 != null && _user2 != null);
    }

    private void HandleComparisonClosed()
    {
        _getScoreButtonClicked = false;
    }

    private void HandleUserOneSelected(UserModel userModel)
    {
        _user1 = userModel;
        _username1 = _user1.Username;
    }

    private void HandleUserTwoSelected(UserModel userModel)
    {
        _user2 = userModel;
        _username2 = _user2.Username;
    }

    protected override async Task OnInitializedAsync()
    {
        if (Username != null)
        {
            _username1 = Username;
        }
        if (BeatmapId != null)
        {
            await GetMapFromSearch(BeatmapId ?? 0);
        }
    }
}