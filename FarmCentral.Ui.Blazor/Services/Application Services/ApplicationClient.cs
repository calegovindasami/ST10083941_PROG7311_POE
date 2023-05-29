namespace FarmCentral.Ui.Blazor.Services.Application_Services;

public static class ApplicationClient
{

    public static HttpClient GetClient()
    {
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri("https://localhost:7074/");
        return client;
    }
}
