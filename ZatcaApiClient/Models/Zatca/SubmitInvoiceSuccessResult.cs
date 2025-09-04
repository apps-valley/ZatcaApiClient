using ZatcaApiClient.Models.Common;

namespace ZatcaApiClient.Models.Zatca
{
    public class SubmitInvoiceSuccessResult
    {
        public string Uuid { get; set; }
        public string Status { get; set; }
        public ValidationResult ValidationResults { get; set; }
        public string QrCodeString { get; set; }
        public string SignedInvoice { get; set; }
    }
}
