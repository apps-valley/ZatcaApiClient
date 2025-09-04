using ZatcaApiClient.Enums;

namespace ZatcaApiClient.Models.Zatca
{
    public class SubmitInvoiceCommand
    {
        public InvoiceKind DocumentType { get; set; }
        public InvoiceIndicator InvoiceIndicator { get; set; }
        public Currency Currency { get; set; }
        public double? ExchangeRate { get; set; }
        public DateTime DocumentIssueDateTime { get; set; }
        public DateTime? SupplyDate { get; set; }
        public Buyer Buyer { get; set; }
        public List<DocumentLineItem> DocumentLineItems { get; set; }
        public string ReferenceId { get; set; }
        public string DocumentId { get; set; }
        public string Notes { get; set; }
        public List<DocumentAllowanceOrChanges>? DocumentAllowanceOrChange { get; set; }
        public string InvoiceTypeReason { get; set; }
        public Payment Payment { get; set; }
        public List<PrepaymentDetail> PrepaymentDetails { get; set; }
    }
}
