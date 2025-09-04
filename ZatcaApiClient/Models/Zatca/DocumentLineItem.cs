using ZatcaApiClient.Enums;

namespace ZatcaApiClient.Models.Zatca
{
    public class DocumentLineItem
    {
        public string LineItemName { get; set; }
        public double LineItemPrice { get; set; } = 0;
        public double LineItemQty { get; set; } = 1;
        public double DiscountOnLineItem { get; set; }
        public string AllowanceCode { get; set; }
        public TaxCategories TaxCategoryCode { get; set; }
        public TaxReasonCode TaxReasonCode { get; set; }
        public string TaxReasonDescription { get; set; }
        public double VatRateOnLineItem { get; set; }
    }
}
