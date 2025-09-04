using ZatcaApiClient;
using ZatcaApiClient.Enums;
using ZatcaApiClient.Models.Common;
using ZatcaApiClient.Models.Partners;
using ZatcaApiClient.Models.Zatca;

class Program
{
    static async Task Main(string[] args)
    {
        var httpClient = new HttpClient();
        var client = new ZatcaIntegrationClient(httpClient);

        try
        {
            // Partner login
            var loginResponse = await client.PartnerService.LoginAsync(new LoginCommand
            {
                Email = "partner@company.com",
                Password = "password123"
            });

            client.SetBearerToken(loginResponse.AccessToken);

            // Create EGS Unit
            var egsUnitResponse = await client.PartnerEgsUnitsService.CreateNewEgsUnitAsync(
                new CreateNewEgsUnitCommand
                {
                    OrganizationName = "My Company",
                    VatNumber = "300000000000003",
                    IsProduction = false,
                    Otp = "12345600",
                    AdditionalID = "CRNNumber",
                    AdditionalIDSchemeID = AdditionalIDScheme.CRN,
                    CommonName = "mycompany",
                    Industry = "Retail",
                    InvoiceType = "1100",
                    SerialNumber = "123456789012345678901234567890123",
                    OrganizationUnitName = "My Company",
                    Address = new PartyPostalAddress
                    {
                        StreetName = "Main Street",
                        CityName = "Riyadh",
                        Country = "SA",
                        AdditionalStreetName = "Suite 100",
                        BuildingNumber = "1234",
                        CitySubdivisionName = "Central",
                        PostalZone = "11564",
                        CountrySubentity = "Riyadh Region",
                        PlotIdentification = "5678"
                    }
                });

            // Login as EGS Unit
            var egsLoginResponse = await client.AuthenticationService.LoginAsEgsUnitAsync(
                new LoginAsEgsUnitCommand
                {
                    ClientId = egsUnitResponse.ClientId,
                    ClientSecret = egsUnitResponse.ClientSecret
                });

            client.ClearBearerToken();
            // Set bearer token for subsequent requests
            client.SetBearerToken(egsLoginResponse.AccessToken);

            // Submit invoice
            var invoiceResult = await client.InvoiceService.SubmitInvoiceAsync(
                new SubmitInvoiceCommand
                {
                    DocumentType = InvoiceKind.TaxInvoice,
                    InvoiceIndicator = InvoiceIndicator.Nominal,
                    Currency = Currency.SAR,
                    DocumentIssueDateTime = DateTime.UtcNow,
                    Buyer = new Buyer
                    {
                        BuyerName = "Customer Name",
                        BuyerVatId = "310285784400003",
                        AdditionalIDSchemeID = AdditionalIDScheme.None
                    },
                    DocumentLineItems = new List<DocumentLineItem>
                    {
                        new DocumentLineItem
                        {
                            LineItemName = "Product A",
                            LineItemPrice = 100,
                            LineItemQty = 2,
                            TaxCategoryCode = TaxCategories.S,
                            VatRateOnLineItem = 15
                        }
                    }
                });

            Console.WriteLine($"Invoice submitted successfully: {invoiceResult.Uuid}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}