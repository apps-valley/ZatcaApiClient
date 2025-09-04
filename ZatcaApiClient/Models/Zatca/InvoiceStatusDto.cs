using ZatcaApiClient.Enums;

namespace ZatcaApiClient.Models.Zatca
{
    public class InvoiceStatusDto
    {
        public string InvoiceUUID { get; set; }
        public InvoiceStatus InvoiceStatus { get; set; }
        public InvoiceReportingResponse InvoiceReportingResponse { get; set; }
        public InvoiceClearanceResponse InvoiceClearanceResponse { get; set; }
    }
}
