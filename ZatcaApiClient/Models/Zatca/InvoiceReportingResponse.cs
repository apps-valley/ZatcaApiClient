using ZatcaApiClient.Enums;
using ZatcaApiClient.Models.Common;

namespace ZatcaApiClient.Models.Zatca
{
    public class InvoiceReportingResponse
    {
        public ValidationResult ValidationResults { get; set; }
        public InvoiceStatus ReportingStatus { get; set; }
    }
}
