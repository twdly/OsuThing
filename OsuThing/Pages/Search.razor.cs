using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using OsuThing.Models;
using OsuThing.Services.Interfaces;

namespace OsuThing.Pages;

public partial class Search
{
    [Inject] private IBeatmapService BeatmapService { get; set; } = null!;

    [Parameter] public bool IsChildComponent { get; set; }
    [Parameter] public EventCallback<bool> CloseSearchCallback { get; set; }
    [Parameter] public EventCallback<int> SelectDiffCallback { get; set; }
    
    private string SearchInput { get; set; } = "";
    private IEnumerable<BeatmapSetModel>? BeatmapSets { get; set; }

    private async Task SearchForSets()
    {
        BeatmapSets = await BeatmapService.SearchForSets(SearchInput);
        StateHasChanged();
    }


    private async Task ClickSearchButton(KeyboardEventArgs args)
    {
        if (args.Key == "Enter")
        {
            await SearchForSets();
        }
    }

    private async Task CloseSearch()
    {
        await CloseSearchCallback.InvokeAsync(false);
    }
}