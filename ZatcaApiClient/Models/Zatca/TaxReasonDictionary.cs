namespace ZatcaApiClient.Models.Zatca
{
    public class TaxReasonDictionary : Dictionary<string, List<TaxReason>>
    {
    }
    public class TaxReason
    {
        public string TaxReasonCode { get; set; }
        public string EnglishDescription { get; set; }
        public string ArabicDescription { get; set; }
    }
}
