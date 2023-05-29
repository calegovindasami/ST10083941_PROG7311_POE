
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

    //Calls api endpoiint to check if the login was valid.
    public async Task<bool> AuthenticateAsync(string email, string password)
    {
        try
        {
            AuthRequest authRequest = new AuthRequest { Email = email, Password = password };
            var response = await _httpClient.PostAsJsonAsync("api/Auth/login", authRequest);
            string jsonResult = await response.Content.ReadAsStringAsync();

            
            AuthResponse authResponse = JsonConvert.DeserializeObject<AuthResponse>(jsonResult)!;

            //Checks if token received is empty, if not it is stored locally.
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

    //Logs user out
    public async Task Logout()
    {
        await ((CustomAuthenticationStateProvider)_authStateProvider).LoggedOut();
    }

    //Calls the api method responsible for registering user in identity.
    public async Task<string?> RegisterAsync(RegistrationRequest registrationRequest)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("api/Auth/register", registrationRequest);
            string jsonResponse = await response.Content.ReadAsStringAsync();
            var registrationResponse = JsonConvert.DeserializeObject<RegistrationResponse>(jsonResponse)!;
            if (string.IsNullOrEmpty(registrationResponse.Id))
            {
                throw new Exception("Invalid registration");
            }

            return registrationResponse.Id;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}
