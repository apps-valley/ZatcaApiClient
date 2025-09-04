using System.Text.Json.Serialization;

namespace ZatcaApiClient.Models.Partners
{
    public class LoginResponse
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }
        public DateTime Expires { get; set; }
    }
}
