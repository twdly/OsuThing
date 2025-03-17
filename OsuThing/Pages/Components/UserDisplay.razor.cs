using Microsoft.AspNetCore.Components;
using OsuThing.Models;

namespace OsuThing.Pages.Components;

public partial class UserDisplay : ComponentBase
{
    [Parameter] public UserExtendedModel User { get; set; }
}