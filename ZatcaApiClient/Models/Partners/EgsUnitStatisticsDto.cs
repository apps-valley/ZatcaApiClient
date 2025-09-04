namespace ZatcaApiClient.Models.Partners
{
    public class EgsUnitStatisticsDto
    {
        public string EgsUnitId { get; set; }
        public string EgsUnitName { get; set; }
        public int SimplifiedInvoiceCount { get; set; }
        public int StandardInvoiceCount { get; set; }
        public int TotalInvoices => SimplifiedInvoiceCount + StandardInvoiceCount;
        public double TotalAmountInvoiced { get; set; }
        public double AverageInvoiceAmount { get; set; }
        public DateTime? LastInvoiceDate { get; set; }
        public bool IsProduction { get; set; }
    }
}
