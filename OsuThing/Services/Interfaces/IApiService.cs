using System.Collections.Specialized;

namespace OsuThing.Services.Interfaces;

public interface IApiService
{
    Task<T?> GetAsync<T>(string requestParams);
    Task<T?> GetAsync<T>(string requestParams, NameValueCollection inputQuery);
}