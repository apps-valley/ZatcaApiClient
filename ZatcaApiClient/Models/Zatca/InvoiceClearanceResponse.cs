using ZatcaApiClient.Enums;
using ZatcaApiClient.Models.Common;

namespace ZatcaApiClient.Models.Zatca
{
    public class InvoiceClearanceResponse
    {
        public ValidationResult ValidationResults { get; set; }
        public string ClearedInvoice { get; set; }
        public InvoiceStatus ClearanceStatus { get; set; }
    }
}
