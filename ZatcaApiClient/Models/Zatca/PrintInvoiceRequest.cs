using ZatcaApiClient.Enums;

namespace ZatcaApiClient.Models.Zatca
{
    public class PrintInvoiceRequest
    {
        public string SignedInvoice { get; set; }
        public string LogoUrl { get; set; }
        public string PdfInvoiceBase64 { get; set; }
        public PdfA3Template PdfA3Templete { get; set; }
    }
}
