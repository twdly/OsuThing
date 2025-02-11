using Microsoft.AspNetCore.Components;
using OsuThing.Models;

namespace OsuThing.Pages;

public partial class ScoreComparisonDisplay : ComponentBase
{
    [Parameter] public required ScoreModel Score { get; set; }
    [Parameter] public required ScoreModel ComparisonScore { get; set; }
    [Parameter] public required UserModel User { get; set; }
}