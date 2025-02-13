using Microsoft.AspNetCore.Components;
using OsuThing.Models;

namespace OsuThing.Pages;

public partial class ComparisonPanel : ComponentBase
{
    [Parameter] public required BeatmapSetModel BeatmapSet { get; set; }
    [Parameter] public required BeatmapModel Beatmap { get; set; }
    [Parameter] public required ScoreModel UserScore1 { get; set; }
    [Parameter] public required ScoreModel UserScore2 { get; set; }
    [Parameter] public required UserModel User1 { get; set; }
    [Parameter] public required UserModel User2 { get; set; }
    [Parameter] public required EventCallback CloseComparisonCallback { get; set; }

    private async void CloseComparison()
    {
        await CloseComparisonCallback.InvokeAsync();
    }
}