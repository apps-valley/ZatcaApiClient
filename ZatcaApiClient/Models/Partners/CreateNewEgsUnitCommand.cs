using ZatcaApiClient.Enums;
using ZatcaApiClient.Models.Common;

namespace ZatcaApiClient.Models.Partners
{
    public class CreateNewEgsUnitCommand
    {
        public string CommonName { get; set; } = "Default Common Name";
        public string OrganizationName { get; set; } = "Default Organization Name";
        public string OrganizationUnitName { get; set; } = "Default Organization Unit Name";
        public string SerialNumber { get; set; } = "1-Manufacturer or Solution Provider Name|2-Model or Version|3-SerialNumber";
        public string VatNumber { get; set; } = "300075588700003";
        public string AdditionalID { get; set; }
        public AdditionalIDScheme AdditionalIDSchemeID { get; set; }
        public string InvoiceType { get; set; } = "1100";
        public string Industry { get; set; } = "Default Industry";
        public bool IsProduction { get; set; } = false;
        public PartyPostalAddress Address { get; set; }
        public string Otp { get; set; } = "537888";
    }
}
