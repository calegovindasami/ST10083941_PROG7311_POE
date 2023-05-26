
using Blazored.LocalStorage;
using FarmCentral.Library.Shared.Contracts;
using FarmCentral.Ui.Blazor.Services.Base_Services;

namespace FarmCentral.Ui.Blazor.Services;

public class AuthenticationService : BaseHttpService, IAuthenticationService
{
    public AuthenticationService(HttpClient httpClient, ILocalStorageService localStorageService) : base(httpClient, localStorageService)
    {
    }

    public Task<bool> AuthenticateAsync(string email, string password)
    {
        throw new NotImplementedException();
    }

    public Task Logout()
    {
        throw new NotImplementedException();
    }

    public Task<bool> RegisterAsync(string email, string password, string firstName, string lastName, string? address)
    {
        throw new NotImplementedException();
    }
}
