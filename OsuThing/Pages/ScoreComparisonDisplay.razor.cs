using Microsoft.AspNetCore.Components;
using OsuThing.Models;

namespace OsuThing.Pages;

public partial class ScoreComparisonDisplay : ComponentBase
{
    [Parameter] public required ScoreModel Score { get; set; }
    [Parameter] public required ScoreModel ComparisonScore { get; set; }
    [Parameter] public required UserModel User { get; set; }

    private static string GetComparisonClass(double score, double comparison, bool higherIsBetter)
    {
        var isBetter = score > comparison;
        isBetter = higherIsBetter ? isBetter : !isBetter;
        return isBetter ? "better" : "worse";
    }
}