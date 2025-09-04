using System.Net;
using System.Net.Http.Json;
using ZatcaApiClient.Models.Common;
using ZatcaApiClient.Models.Partners;
using ZatcaApiClient.Services.Interfaces;

namespace ZatcaApiClient.Services.Implementations
{
    public class PartnerEgsUnitsService : BaseService, IPartnerEgsUnitsService
    {
        public PartnerEgsUnitsService(HttpClient httpClient)
            : base(httpClient, "https://zatcaapi.avtax.net") { }

        public async Task<CreateNewEgsUnitResponse> CreateNewEgsUnitAsync(CreateNewEgsUnitCommand command)
        {
            return await PostAsync("/api/EgsUnits/CreateNewEgsUnit", command, async response =>
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<CreateNewEgsUnitResponse>();
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new UnauthorizedAccessException(error);
                }
                else
                {
                    var error = await response.Content.ReadFromJsonAsync<ErrorResponse>();
                    string errorMessages = string.Join(", ", error.Errors.Select((e, i) => $"{i + 1} - {e}"));
                    throw new HttpRequestException($"Unexpected status: {response.StatusCode} {errorMessages}");

                }
            });
        }

        public async Task<List<EgsUnits>> GetEgsUnitsAsync()
        {
            return await GetAsync("/api/EgsUnits/GetEgsUnits", async response =>
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<EgsUnits>>();
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new UnauthorizedAccessException(error);
                }
                else
                {
                    response.EnsureSuccessStatusCode();
                    throw new HttpRequestException($"Unexpected status: {response.StatusCode}");
                }
            });
        }

        public async Task<RevokeEgsSecretResponse> RevokeEgsSecretAsync(string egsUnitId)
        {
            return await PostAsync($"/api/EgsUnits/{egsUnitId}/revoke", new { }, async response =>
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<RevokeEgsSecretResponse>();
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new UnauthorizedAccessException(error);
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