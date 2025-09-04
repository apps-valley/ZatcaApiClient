using ZatcaApiClient.Enums;
using ZatcaApiClient.Models.Zatca;

namespace ZatcaApiClient.Services.Interfaces
{
    public interface IZatcaInvoiceService
    {
        Task<SubmitInvoiceSuccessResult> SubmitInvoiceAsync(SubmitInvoiceCommand command);
        Task<InvoiceDataDto> GetInvoicesAsync(List<InvoiceKind> invoiceTypes = null,
            int? pageNumber = null, int? pageSize = null, DateTime? from = null, DateTime? to = null);
        Task<object> GetInvoiceStatusAsync(string invoiceUuid);
        Task<object> PrintInvoiceAsync(string invoiceUuid, PrintInvoiceRequest request);
    }
}
