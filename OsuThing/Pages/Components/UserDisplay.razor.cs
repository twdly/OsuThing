using Microsoft.AspNetCore.Components;
using OsuThing.Models;

namespace OsuThing.Pages.Components;

public partial class UserDisplay : ComponentBase
{
    [Parameter] public required UserExtendedModel User { get; set; }
}