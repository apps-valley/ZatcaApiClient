namespace ZatcaApiClient.Models.Common
{
    public class ValidationResult
    {
        public List<ValidationMessage> InfoMessages { get; set; }
        public List<ValidationMessage> WarningMessages { get; set; }
        public List<ValidationMessage> ErrorMessages { get; set; }
        public string Status { get; set; }
    }
}
