using System.Timers;
using Microsoft.AspNetCore.Components;
using OsuThing.Models;
using Timer = System.Timers.Timer;

namespace OsuThing.Pages.Components;

public partial class UserSelector : IDisposable
{
    [Parameter]
    public EventCallback<UserModel> HandleUserFound { get; set; }
    
    [Parameter]
    public string? Label { get; set; }
    
    [Parameter]
    public string? InitialValue { get; set; }

    private Timer? _debounceTimer;
    private string? _userInput = "";

    private UserModel? _userModel;
    
    private void FindUserForTimer(object? sender, ElapsedEventArgs e)
    {
        _ = FindUser();
    }

    private async Task FindUser()
    {
        _userModel = await UserService.FindUser(_userInput);
        await InvokeAsync(() => HandleUserFound.InvokeAsync(_userModel));
    }

    private void DebounceFindUser()
    {
        _debounceTimer?.Stop();
        _debounceTimer?.Start();
    }
    
    protected override async Task OnInitializedAsync()
    {
        _userInput = InitialValue;

        if (!string.IsNullOrEmpty(InitialValue))
        {
            await FindUser();
        }
        
        _debounceTimer = new Timer(500);
        _debounceTimer.Elapsed += FindUserForTimer;
        _debounceTimer.AutoReset = false;
    }

    public void Dispose()
    {
        _debounceTimer?.Dispose();
        GC.SuppressFinalize(this);
    }
}