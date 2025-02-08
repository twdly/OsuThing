using System.Collections.Specialized;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Web;

namespace OsuThing.Services;

public class ApiService(IHttpClientFactory clientFactory, AuthenticationService authenticationService)
{
    private IHttpClientFactory ClientFactory { get; } = clientFactory;
    private AuthenticationService AuthenticationService { get; } = authenticationService;
    
    private const string Endpoint = "https://osu.ppy.sh/api/v2/";
    
    public async Task<T?> GetAsync<T>(string requestParams)
    {
       return await GetAsync<T>(requestParams, []);
    }

    public async Task<T?> GetAsync<T>(string requestParams, NameValueCollection inputQuery)
    {
        var auth = await AuthenticationService.Authenticate();
        
        var builder = new UriBuilder(Endpoint + requestParams);
        var query = HttpUtility.ParseQueryString(builder.Query);
        query.Add(inputQuery);
        builder.Query = query.ToString();
        var request = new HttpRequestMessage(HttpMethod.Get, builder.ToString());
        
        request.Content = new StringContent("application/json");
        request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
        request.Headers.Add("Authorization", $"Bearer {auth.AccessToken}");

        var client = ClientFactory.CreateClient();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        var response = await client.SendAsync(request);
        var responseString = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(responseString);
    }
}