using System.Net.Http.Json;
using ZatcaApiClient.Models.Zatca;
using ZatcaApiClient.Services.Interfaces;

namespace ZatcaApiClient.Services.Implementations
{
    public class ZatcaUIDataService : BaseService, IZatcaUIDataService
    {
        public ZatcaUIDataService(HttpClient httpClient)
            : base(httpClient, "https://zatcaapi.avtax.net") { }

        public async Task<ReasonForAllowancesResponse> GetReasonForAllowancesAsync()
        {
            return await GetAsync("/api/ZatcaUIData/ReasonForAllowances", async response =>
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<ReasonForAllowancesResponse>();
            });
        }

        public async Task<CountriesResponse> GetCountriesAsync()
        {
            return await GetAsync("/api/ZatcaUIData/Countries", async response =>
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<CountriesResponse>();
            });
        }

        public async Task<CurrenciesResponse> GetCurrenciesAsync()
        {
            return await GetAsync("/api/ZatcaUIData/Currencies", async response =>
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<CurrenciesResponse>();
            });
        }

        public async Task<InvoiceTypesResponse> GetInvoiceTypesAsync()
        {
            return await GetAsync("/api/ZatcaUIData/InvoiceTypes", async response =>
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<InvoiceTypesResponse>();
            });
        }

        public async Task<TaxReasonDictionary> GetTaxReasonCodesAsync()
        {
            return await GetAsync("/api/ZatcaUIData/TaxReasonCodes", async response =>
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<TaxReasonDictionary>();
            });
        }

        public async Task<InvoiceIndicatorsResponse> GetInvoiceIndicatorsAsync()
        {
            return await GetAsync("/api/ZatcaUIData/InvoiceIndicators", async response =>
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<InvoiceIndicatorsResponse>();
            });
        }

        public async Task<TaxCategoriesResponse> GetTaxCategoriesAsync()
        {
            return await GetAsync("/api/ZatcaUIData/TaxCategories", async response =>
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<TaxCategoriesResponse>();
            });
        }
    }
}