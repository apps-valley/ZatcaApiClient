namespace ZatcaApiClient.Models.Partners
{
    public class UpdatePartnerEgsUnitLimitCommand
    {
        public string PartnerId { get; set; }
        public int MaximumEgsUnits { get; set; }
    }
}
