namespace FarmCentral.Ui.Blazor.Services.Application_Services;

public static class ApplicationClient
{
    //Class used to get an instance of the http client with the corresponding address.
    public static HttpClient GetClient()
    {
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri("https://localhost:7074/");
        return client;
    }
}
