using ZatcaApiClient.Models.Zatca;

namespace ZatcaApiClient.Services.Interfaces
{
    public interface IZatcaAuthenticationService
    {
        Task<LoginAsEgsUnitResponse> LoginAsEgsUnitAsync(LoginAsEgsUnitCommand command);
    }
}
