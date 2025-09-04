namespace ZatcaApiClient.Models.Partners
{
    public class UpdateEgsUnitInvoiceLimitCommand
    {
        public string EgsUnitId { get; set; }
        public int MaximumInvoicesPerMonth { get; set; }
        public int RateLimitPerMinute { get; set; }
    }
}
