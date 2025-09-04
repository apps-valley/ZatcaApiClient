using ZatcaApiClient.Enums;
using ZatcaApiClient.Models.Common;

namespace ZatcaApiClient.Models.Zatca
{
    public class Buyer
    {
        public PartyPostalAddress BuyerAddress { get; set; }
        public string BuyerName { get; set; }
        public string BuyerVatId { get; set; }
        public AdditionalIDScheme AdditionalIDSchemeID { get; set; }
        public string AdditionalCustomerID { get; set; }
    }
}
