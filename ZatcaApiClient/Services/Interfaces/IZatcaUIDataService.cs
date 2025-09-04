using ZatcaApiClient.Models.Zatca;

namespace ZatcaApiClient.Services.Interfaces
{
    public interface IZatcaUIDataService
    {
        Task<ReasonForAllowancesResponse> GetReasonForAllowancesAsync();
        Task<CountriesResponse> GetCountriesAsync();
        Task<CurrenciesResponse> GetCurrenciesAsync();
        Task<InvoiceTypesResponse> GetInvoiceTypesAsync();
        Task<TaxReasonDictionary> GetTaxReasonCodesAsync();
        Task<InvoiceIndicatorsResponse> GetInvoiceIndicatorsAsync();
        Task<TaxCategoriesResponse> GetTaxCategoriesAsync();
    }
}
