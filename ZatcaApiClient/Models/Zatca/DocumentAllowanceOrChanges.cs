using ZatcaApiClient.Enums;

namespace ZatcaApiClient.Models.Zatca
{
    public class DocumentAllowanceOrChanges
    {
        public string AllowanceChargeReasonCode { get; set; }
        public double Amount { get; set; }
        public TaxCategories TaxCategoryCode { get; set; }
        public TaxReasonCode TaxReasonCode { get; set; }
        public int VatRate { get; set; }
    }
}
