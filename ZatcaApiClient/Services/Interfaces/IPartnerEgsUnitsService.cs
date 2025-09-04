using ZatcaApiClient.Models.Partners;

namespace ZatcaApiClient.Services.Interfaces
{
    public interface IPartnerEgsUnitsService
    {
        Task<CreateNewEgsUnitResponse> CreateNewEgsUnitAsync(CreateNewEgsUnitCommand command);
        Task<List<EgsUnits>> GetEgsUnitsAsync();
        Task<RevokeEgsSecretResponse> RevokeEgsSecretAsync(string egsUnitId);
    }
}
