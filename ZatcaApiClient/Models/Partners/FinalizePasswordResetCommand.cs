namespace ZatcaApiClient.Models.Partners
{
    public class FinalizePasswordResetCommand
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public string NewPassword { get; set; }
    }
}
