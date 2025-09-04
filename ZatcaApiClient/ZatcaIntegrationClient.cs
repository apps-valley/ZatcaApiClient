using ZatcaApiClient.Services.Implementations;
using ZatcaApiClient.Services.Interfaces;

namespace ZatcaApiClient
{
    public class ZatcaIntegrationClient
    {
        private readonly HttpClient _httpClient;

        public IZatcaInvoiceService InvoiceService { get; }
        public IZatcaAuthenticationService AuthenticationService { get; }
        public IZatcaUIDataService UIDataService { get; }
        public IPartnerEgsUnitsService PartnerEgsUnitsService { get; }
        public IPartnerService PartnerService { get; }

        public ZatcaIntegrationClient(HttpClient httpClient)
        {
            _httpClient = httpClient;

            InvoiceService = new ZatcaInvoiceService(_httpClient);
            AuthenticationService = new ZatcaAuthenticationService(_httpClient);
            UIDataService = new ZatcaUIDataService(_httpClient);
            PartnerEgsUnitsService = new PartnerEgsUnitsService(_httpClient);
            PartnerService = new PartnerService(_httpClient);
        }

        public void SetBearerToken(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }

        public void ClearBearerToken()
        {
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}
