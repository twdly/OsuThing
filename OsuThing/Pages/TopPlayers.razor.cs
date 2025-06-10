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
    private Mode SelectedMode { get; set; } = Mode.Standard;

    private readonly Dictionary<Mode, string> _modeDisplays = new()
    {
        [Mode.Standard] = "Standard",
        [Mode.Mania] = "Mania",
        [Mode.Taiko] = "Taiko",
        [Mode.CTB] = "CTB"
    };
    
    private readonly Dictionary<Mode, string> _modeSelections = new()
    {
        [Mode.Standard] = "osu",
        [Mode.Mania] = "mania",
        [Mode.Taiko] = "taiko",
        [Mode.CTB] = "fruits"
    };

    private async Task SelectModeCallback(Mode selectedMode)
    {
        SelectedMode = selectedMode;
        Users = [];
        await GetPlayers();
    }

    private async Task GetPlayers()
    {
        var result = await UserService.GetTopPlayers(_modeSelections[SelectedMode]);
        Users = result.Users;
    }
    
    protected override async Task OnInitializedAsync()
    {
        await GetPlayers();
    }
}