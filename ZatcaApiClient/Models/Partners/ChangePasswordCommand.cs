namespace ZatcaApiClient.Models.Partners
{
    public class ChangePasswordCommand
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
