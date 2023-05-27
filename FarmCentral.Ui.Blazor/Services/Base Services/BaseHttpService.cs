using Blazored.LocalStorage;
using System.Net.Http.Headers;

namespace FarmCentral.Ui.Blazor.Services.Base_Services
{
    public class BaseHttpService
    {
        protected HttpClient _httpClient;
        protected readonly ILocalStorageService _localStorageService;

        public BaseHttpService(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            _httpClient = httpClient;
            _localStorageService = localStorageService;
        }

        protected async Task AddBearerToken()
        {
            if (await _localStorageService.ContainKeyAsync("token"))
            {
                _httpClient.DefaultRequestHeaders.Authorization = 
                    new AuthenticationHeaderValue("Bearer", 
                    await _localStorageService.GetItemAsync<string>("token"));
            }
        }
    }
}
