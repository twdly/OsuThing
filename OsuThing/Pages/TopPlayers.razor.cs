using Microsoft.AspNetCore.Components;
using OsuThing.Models;
using OsuThing.Services.Interfaces;

namespace OsuThing.Pages;

public partial class TopPlayers
{
    [Inject]
    public required IUserService UserService { get; set; }

    private IEnumerable<UserExtendedModel> Users { get; set; } = [];
    private string Mode { get; set; } = "osu";

    private async Task SetMode(string mode)
    {
        Mode = mode;
        await GetPlayers();
    }

    private async Task GetPlayers()
    {
        var result = await UserService.GetTopPlayers(Mode);
        Users = result.Users;
    }
    
    protected override async Task OnInitializedAsync()
    {
        await GetPlayers();
    }
}