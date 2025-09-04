using System.Net.Http.Json;

namespace ZatcaApiClient.Services.Implementations
{
    public abstract class BaseService
    {
        protected readonly HttpClient _httpClient;
        protected readonly string _baseUrl;

        protected BaseService(HttpClient httpClient, string baseUrl)
        {
            _httpClient = httpClient;
            _baseUrl = baseUrl.TrimEnd('/');
        }

        protected async Task<TResult> PostAsync<TResult>(
            string endpoint,
            object data,
            Func<HttpResponseMessage, Task<TResult>> responseHandler)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}{endpoint}", data);
            return await responseHandler(response);
        }

        protected async Task<TResult> GetAsync<TResult>(
            string endpoint,
            Func<HttpResponseMessage, Task<TResult>> responseHandler)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}{endpoint}");
            return await responseHandler(response);
        }

        protected async Task<TResult> GetAsync<TResult>(
            string endpoint,
            Dictionary<string, string> queryParams,
            Func<HttpResponseMessage, Task<TResult>> responseHandler)
        {
            var queryString = string.Join("&", queryParams.Select(kvp => $"{kvp.Key}={Uri.EscapeDataString(kvp.Value)}"));
            var url = $"{_baseUrl}{endpoint}?{queryString}";

            var response = await _httpClient.GetAsync(url);
            return await responseHandler(response);
        }

        // Helper methods for common response patterns
        protected async Task<T> HandleSuccessResponse<T>(HttpResponseMessage response)
        {
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }

        protected async Task<T> HandleResponseWithErrorHandling<T, TError>(HttpResponseMessage response)
            where TError : Exception
        {
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<T>();
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw Activator.CreateInstance(typeof(TError), errorContent) as TError;
            }
        }
    }
}