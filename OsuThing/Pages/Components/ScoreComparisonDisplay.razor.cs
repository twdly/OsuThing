using Microsoft.AspNetCore.Components;
using OsuThing.Models;

namespace OsuThing.Pages.Components;

public partial class ScoreComparisonDisplay : ComponentBase
{
    [Parameter] public required ScoreModel Score { get; set; }
    [Parameter] public required ScoreModel ComparisonScore { get; set; }
    [Parameter] public required UserModel User { get; set; }

    private string GetComparisonClass(double? score, double? comparison, bool higherIsBetter)
    {
        if (Score.Score == 0 || ComparisonScore.Score == 0)
        {
            // Score has nothing to be compared to and, therefore, is inherently better
            return "better";
        }
        var isBetter = score > comparison;
        isBetter = higherIsBetter ? isBetter : !isBetter;
        return isBetter ? "better" : "worse";
    }
}