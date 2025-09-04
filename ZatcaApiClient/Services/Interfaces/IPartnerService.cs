using ZatcaApiClient.Models.Partners;

namespace ZatcaApiClient.Services.Interfaces
{
    public interface IPartnerService
    {
        Task<LoginResponse> LoginAsync(LoginCommand command);
        Task<List<EgsUnitStatisticsDto>> GetEgsUnitStatisticsAsync();
        Task<List<MonthlyInvoiceStatisticsDto>> GetEgsUnitMonthlyInvoiceStatisticsAsync(string egsUnitId);
    }
}
