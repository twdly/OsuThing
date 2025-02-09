using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using OsuThing.Models;
using OsuThing.Services.Interfaces;

namespace OsuThing.Pages;

public partial class Search
{
    [Inject] private IBeatmapService BeatmapService { get; set; } = null!;

    private string SearchInput { get; set; } = "";
    private IEnumerable<BeatmapSetModel>? BeatmapSets { get; set; }

    private async void SearchForSets()
    {
        BeatmapSets = await BeatmapService.SearchForSets(SearchInput);
        StateHasChanged();
    }

    [Parameter] public bool IsChildComponent { get; set; }

    private void ClickSearchButton(KeyboardEventArgs args)
    {
        if (args.Key == "Enter")
        {
            SearchForSets();
        }
    }
}