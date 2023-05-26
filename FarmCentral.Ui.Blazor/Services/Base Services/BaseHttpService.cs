using Blazored.LocalStorage;

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
    }
}
