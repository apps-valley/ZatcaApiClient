using ZatcaApiClient.Enums;

namespace ZatcaApiClient.Models.Zatca
{
    public class Payment
    {
        public PaymentMethod PaymentMethod { get; set; }
        public string PaymentAccountIdentifier { get; set; }
        public string PaymentNote { get; set; }
    }
}
