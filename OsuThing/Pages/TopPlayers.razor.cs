using Microsoft.AspNetCore.Components;
using OsuThing.Enums;
using OsuThing.Models;
using OsuThing.Services.Interfaces;

namespace OsuThing.Pages;

public partial class TopPlayers
{
    [Inject]
    public required IUserService UserService { get; set; }

    private IEnumerable<UserExtendedModel> Users { get; set; } = [];
    private string SelectedMode { get; set; } = "osu";

    private readonly Dictionary<Mode, string> _modeSelections = new()
    {
        [Mode.Standard] = "osu",
        [Mode.Mania] = "mania",
        [Mode.Taiko] = "taiko",
        [Mode.CTB] = "fruits"
    };

    private async Task SelectModeCallback(string selectedMode)
    {
        SelectedMode = selectedMode;
        Users = [];
        await GetPlayers();
    }

    private async Task GetPlayers()
    {
        var result = await UserService.GetTopPlayers(SelectedMode);
        Users = result.Users;
    }
    
    protected override async Task OnInitializedAsync()
    {
        await GetPlayers();
    }
}