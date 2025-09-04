using System.Net;
using System.Net.Http.Json;
using ZatcaApiClient.Models.Common;
using ZatcaApiClient.Models.Zatca;
using ZatcaApiClient.Services.Interfaces;

namespace ZatcaApiClient.Services.Implementations
{
    public class ZatcaAuthenticationService : BaseService, IZatcaAuthenticationService
    {
        public ZatcaAuthenticationService(HttpClient httpClient)
            : base(httpClient, "https://zatcaapi.avtax.net") { }

        public async Task<LoginAsEgsUnitResponse> LoginAsEgsUnitAsync(LoginAsEgsUnitCommand command)
        {
            return await PostAsync("/api/UserAuthentication/LoginAsEgsUnit", command, async response =>
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<LoginAsEgsUnitResponse>();
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    var errorResponse = await response.Content.ReadFromJsonAsync<ErrorResponse>();
                    throw new UnauthorizedAccessException(string.Join(", ", errorResponse.Errors));
                }
                else
                {
                    response.EnsureSuccessStatusCode();
                    throw new HttpRequestException($"Unexpected status: {response.StatusCode}");
                }
            });
        }
    }
}