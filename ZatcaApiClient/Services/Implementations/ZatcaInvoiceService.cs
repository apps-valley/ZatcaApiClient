using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http.Json;
using ZatcaApiClient.Enums;
using ZatcaApiClient.Models.Common;
using ZatcaApiClient.Models.Zatca;
using ZatcaApiClient.Services.Interfaces;

namespace ZatcaApiClient.Services.Implementations
{
    public class ZatcaInvoiceService : BaseService, IZatcaInvoiceService
    {
        public ZatcaInvoiceService(HttpClient httpClient)
            : base(httpClient, "https://zatcaapi.avtax.net") { }

        public async Task<SubmitInvoiceSuccessResult> SubmitInvoiceAsync(SubmitInvoiceCommand command)
        {
            return await PostAsync("/api/Invoice/SubmitInvoice", command, async response =>
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<SubmitInvoiceSuccessResult>();
                }
                else if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    var errorResponse = await response.Content.ReadFromJsonAsync<ErrorResponse>();
                    throw new ValidationException($"Validation errors: {string.Join(", ", errorResponse.Errors)}");
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new UnauthorizedAccessException(error);
                }
                else if (response.StatusCode == HttpStatusCode.Forbidden)
                {
                    var resourceAccess = await response.Content.ReadFromJsonAsync<ResourceAccess>();
                    throw new AccessViolationException(resourceAccess.Message);
                }
                else
                {
                    response.EnsureSuccessStatusCode();
                    throw new HttpRequestException($"Unexpected status: {response.StatusCode}");
                }
            });
        }

        public async Task<InvoiceDataDto> GetInvoicesAsync(List<InvoiceKind> invoiceTypes = null,
            int? pageNumber = null, int? pageSize = null, DateTime? from = null, DateTime? to = null)
        {
            var queryParams = new Dictionary<string, string>();

            if (invoiceTypes != null && invoiceTypes.Any())
                queryParams.Add("InvoiceTypes", string.Join(",", invoiceTypes));

            if (pageNumber.HasValue)
                queryParams.Add("PageNumber", pageNumber.Value.ToString());

            if (pageSize.HasValue)
                queryParams.Add("PageSize", pageSize.Value.ToString());

            if (from.HasValue)
                queryParams.Add("From", from.Value.ToString("o"));

            if (to.HasValue)
                queryParams.Add("To", to.Value.ToString("o"));

            return await GetAsync("/api/Invoice/GetInvoices", queryParams, async response =>
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<InvoiceDataDto>();
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new UnauthorizedAccessException(error);
                }
                else if (response.StatusCode == HttpStatusCode.Forbidden)
                {
                    var resourceAccess = await response.Content.ReadFromJsonAsync<ResourceAccess>();
                    throw new AccessViolationException(resourceAccess.Message);
                }
                else
                {
                    response.EnsureSuccessStatusCode();
                    throw new HttpRequestException($"Unexpected status: {response.StatusCode}");
                }
            });
        }

        public async Task<object> GetInvoiceStatusAsync(string invoiceUuid)
        {
            return await GetAsync($"/api/Invoice/GetInvoiceStatus/{invoiceUuid}/status", async response =>
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<object>();
                }
                else if (response.StatusCode == HttpStatusCode.Forbidden)
                {
                    var resourceAccess = await response.Content.ReadFromJsonAsync<ResourceAccess>();
                    throw new AccessViolationException(resourceAccess.Message);
                }
                else
                {
                    response.EnsureSuccessStatusCode();
                    throw new HttpRequestException($"Unexpected status: {response.StatusCode}");
                }
            });
        }

        public async Task<object> PrintInvoiceAsync(string invoiceUuid, PrintInvoiceRequest request)
        {
            return await PostAsync($"/api/Invoice/PrintInvoice/{invoiceUuid}/PrintA3", request, async response =>
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<object>();
                }
                else if (response.StatusCode == HttpStatusCode.Forbidden)
                {
                    var resourceAccess = await response.Content.ReadFromJsonAsync<ResourceAccess>();
                    throw new AccessViolationException(resourceAccess.Message);
                }
                else if (response.StatusCode == HttpStatusCode.InternalServerError)
                {
                    var errorDetails = await response.Content.ReadFromJsonAsync<ErrorDetails>();
                    throw new Exception($"Server error: {errorDetails.Details}");
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