namespace ZatcaApiClient.Models.Partners
{
    public class MonthlyInvoiceStatisticsDto
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int InvoiceCount { get; set; }
        public double TotalAmount { get; set; }
    }
}
