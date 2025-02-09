using OsuThing.Models;

namespace OsuThing.Services.Interfaces;

public interface IAuthenticationService
{
    Task<AuthenticationModel?> Authenticate();
}