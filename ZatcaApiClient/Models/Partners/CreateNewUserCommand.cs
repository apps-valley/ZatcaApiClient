namespace ZatcaApiClient.Models.Partners
{
    public class CreateNewUserCommand
    {
        public string FullName { get; set; } = "John Doe";
        public string Email { get; set; } = "johndoe@example.com";
        public string PhoneNumber { get; set; } = "+1234567890";
        public string Password { get; set; }
    }
}
