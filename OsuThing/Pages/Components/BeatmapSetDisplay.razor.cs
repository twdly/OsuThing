using Microsoft.AspNetCore.Components;
using OsuThing.Models;

namespace OsuThing.Pages.Components;

public partial class BeatmapSetDisplay : ComponentBase
{
    [Parameter] public required BeatmapSetModel BeatmapSet { get; set; }
    [Parameter] public required bool IsChildComponent { get; set; }
    [Parameter] public required EventCallback<int> SelectDiffCallback { get; set; }
     private IEnumerable<IGrouping<string, BeatmapModel>> Difficulties { get; set; } = [];

     private readonly Dictionary<string, string> _displayNames = new()
     {
         ["osu"] = "Standard",
         ["taiko"] = "Taiko",
         ["mania"] = "Mania",
         ["fruits"] = "Catch the Beat",
     };
     
     private async Task SelectDiff(int diffId)
     {
         await SelectDiffCallback.InvokeAsync(diffId);
     }
     
    protected override Task OnInitializedAsync()
    {
        Difficulties = BeatmapSet.Difficulties.GroupBy(x => x.Mode);
        return base.OnInitializedAsync();
    }
}