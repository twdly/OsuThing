using System.Timers;
using Microsoft.AspNetCore.Components;
using OsuThing.Models;
using Timer = System.Timers.Timer;

namespace OsuThing.Pages;

public partial class UserSelector : IDisposable
{
    [Parameter]
    public EventCallback<UserModel> HandleUserFound { get; set; }

    private Timer _debounceTimer = default!;
    private string? _userInput = "";
    
    private async void FindUser(object? sender, ElapsedEventArgs e)
    {
        var user = await UserService.FindUser(_userInput);
        await InvokeAsync(() => HandleUserFound.InvokeAsync(user));
    }

    private void DebounceFindUser()
    {
        _debounceTimer.Stop();
        _debounceTimer.Start();
    }
    
    protected override void OnInitialized()
    {
        _debounceTimer = new Timer(500);
        _debounceTimer.Elapsed += FindUser;
        _debounceTimer.AutoReset = false;
    }

    public void Dispose()
    {
        _debounceTimer.Dispose();
        GC.SuppressFinalize(this);
    }
}