using Microsoft.AspNetCore.Components;
using OsuThing.Models;
using OsuThing.Services.Interfaces;

namespace OsuThing.Pages;

public partial class Search
{
    [Inject] private IBeatmapService BeatmapService { get; set; } = null!;

    private string searchInput { get; set; } = "";
    private IEnumerable<BeatmapSetModel>? BeatmapSets { get; set; }

    private async void SearchForSets()
    {
        BeatmapSets = await BeatmapService.SearchForSets(searchInput);
        Console.WriteLine(BeatmapSets.First().Title);
        StateHasChanged();
    }
}