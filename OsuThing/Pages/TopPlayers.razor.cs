using Microsoft.AspNetCore.Components;
using OsuThing.Models;
using OsuThing.Services.Interfaces;

namespace OsuThing.Pages;

public partial class TopPlayers
{
    [Inject]
    public required IUserService UserService { get; set; }

    private IEnumerable<UserExtendedModel> Users { get; set; } = [];
    
    protected override async Task OnInitializedAsync()
    {
        var result = await UserService.GetTopPlayers();
        Users = result.Users;
    }
}