using System.Net;
using System.Net.Http.Json;
using ZatcaApiClient.Models.Partners;
using ZatcaApiClient.Services.Interfaces;

namespace ZatcaApiClient.Services.Implementations
{
    public class PartnerService : BaseService, IPartnerService
    {
        public PartnerService(HttpClient httpClient)
            : base(httpClient, "https://zatcaapi.avtax.net") { }

        public async Task<LoginResponse> LoginAsync(LoginCommand command)
        {
            return await PostAsync("/api/Partner/Login", command, async response =>
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<LoginResponse>();
            });
        }

        public async Task<List<EgsUnitStatisticsDto>> GetEgsUnitStatisticsAsync()
        {
            return await GetAsync("/api/Partner/GetEgsUnitStatistics", async response =>
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<EgsUnitStatisticsDto>>();
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

        public async Task<List<MonthlyInvoiceStatisticsDto>> GetEgsUnitMonthlyInvoiceStatisticsAsync(string egsUnitId)
        {
            return await GetAsync($"/api/Partner/GetEgsUnitMonthlyInvoiceStatistics/egsunit/{egsUnitId}/monthly-statistics",
                async response =>
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadFromJsonAsync<List<MonthlyInvoiceStatisticsDto>>();
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