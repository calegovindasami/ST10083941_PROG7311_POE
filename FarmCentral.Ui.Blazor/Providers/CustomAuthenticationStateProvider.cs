using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FarmCentral.Ui.Blazor.Providers;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly ILocalStorageService _localStorageService;
    private JwtSecurityTokenHandler jwtSecurityTokenHandler;
    public CustomAuthenticationStateProvider(ILocalStorageService localStorageService)
    {
        _localStorageService = localStorageService;
        jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
    }
    
    //Gets the current authentication state of the user.
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var user = new ClaimsPrincipal(new ClaimsIdentity());
        var isTokenPresent = await _localStorageService.ContainKeyAsync("token");

        if (isTokenPresent == false)
        {
            return new AuthenticationState(user);
        }

        var savedToken = await _localStorageService.GetItemAsync<string>("token");
        var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(savedToken);
        
        //Checks if the token has expired.
        if (tokenContent.ValidTo < DateTime.Now) 
        {
            await _localStorageService.RemoveItemAsync("token");
            return new AuthenticationState(user);
        }

        var claims = await GetUserClaims();
        user = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"));
        return new AuthenticationState(user);

    }

    //Returns authstate with user variable containing the claims.
    public async Task LoggedIn()
    {
        var claims = await GetUserClaims();
        var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"));
        var authState = Task.FromResult(new AuthenticationState(user));
        NotifyAuthenticationStateChanged(authState);
    }

    //Deletes the token to log out the user.
    public async Task LoggedOut()
    {
        await _localStorageService.RemoveItemAsync("token");
        var anonymous = new ClaimsPrincipal(new ClaimsIdentity());
        var authState = Task.FromResult(new AuthenticationState(anonymous));
        NotifyAuthenticationStateChanged(authState);
    }

    //Gets the user claims from the stored token.
    private async Task<List<Claim>> GetUserClaims()
    {
        var savedToken = await _localStorageService.GetItemAsync<string>("token");
        var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(savedToken);
        var claims = tokenContent.Claims.ToList();
        claims.Add(new Claim(ClaimTypes.Name, tokenContent.Subject));
        return claims;
    }
}
