
using Blazored.LocalStorage;
using FarmCentral.Library.Shared.Contracts;
using FarmCentral.Library.Shared.Models.Identity;
using FarmCentral.Ui.Blazor.Providers;
using FarmCentral.Ui.Blazor.Services.Base_Services;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace FarmCentral.Ui.Blazor.Services;

public class AuthenticationService : BaseHttpService, IAuthenticationService
{
    private readonly AuthenticationStateProvider _authStateProvider;
    public AuthenticationService(AuthenticationStateProvider authStateProvider, HttpClient httpClient, ILocalStorageService localStorageService) : base(httpClient, localStorageService)
    {
        _authStateProvider = authStateProvider;
    }

    public async Task<bool> AuthenticateAsync(string email, string password)
    {
        try
        {
            AuthRequest authRequest = new AuthRequest { Email = email, Password = password };
            var response = await _httpClient.PostAsJsonAsync("api/login", authRequest);
            string jsonResult = await response.Content.ReadAsStringAsync();

            AuthResponse authResponse = JsonConvert.DeserializeObject<AuthResponse>(jsonResult)!;

            if (authResponse.Token == string.Empty)
            {
                throw new Exception("Invalid login details.");
            }

            await _localStorageService.SetItemAsync("token", authResponse.Token);
            await ((CustomAuthenticationStateProvider)_authStateProvider).LoggedIn(); 
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task Logout()
    {
        await ((CustomAuthenticationStateProvider)_authStateProvider).LoggedOut();
    }

    public async Task<bool> RegisterAsync(string email, string password, string firstName, string lastName, string? address)
    {
        try
        {
            RegistrationRequest registrationRequest = new() { Email = email, Password = password, FirstName = firstName, LastName = lastName, Role = "Employee" };
            var response = await _httpClient.PostAsJsonAsync("api/Auth/register", registrationRequest);
            string jsonResponse = await response.Content.ReadAsStringAsync();
            var registrationResponse = JsonConvert.DeserializeObject<RegistrationResponse>(jsonResponse)!;
            if (string.IsNullOrEmpty(registrationResponse.Id))
            {
                throw new Exception("Invalid registration");
            }

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}
