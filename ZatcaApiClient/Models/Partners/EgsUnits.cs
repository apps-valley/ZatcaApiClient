namespace ZatcaApiClient.Models.Partners
{
    public class EgsUnits
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string EgsUnitId { get; set; }
        public string OrganizationName { get; set; }
        public string VatNumber { get; set; }
        public string AdditionalIDSchemeID { get; set; }
        public string SchemeIDName { get; set; }
        public string AdditionalID { get; set; }
        public bool IsProduction { get; set; }
        public int MaximumNumberOfInvoicesPerMonth { get; set; }
        public int RateLimitPerMinute { get; set; }
    }
}
