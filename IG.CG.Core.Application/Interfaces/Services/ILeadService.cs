using IG.CG.Core.Application.Models;

namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface ILeadService
    {
        Task<string?> UpsertLeadAsync(LeadModel branchModel, string? userId);
        Task<IList<LeadDisplayModel>> GetAllLeadAsync(LeadFilter leadFilter, string? userId);

        Task<LeadDisplayModel> GetLeadByIdAsync(int leadId);

        Task<string?> DeleteLeadAsync(int? leadId, string? userId, int? isActive, string? DeleteRemark);

        Task<string?> DeleteLeadProductAsync(int DivisionLeadId);

        Task<IList<LeadsDashboardModel>> GetLeadsDashboardAsync(LeadsDashboardFilter leadFilter, string? userId);

        Task<IList<LeadsDashboardChartModel>> GetMonthWishLeadsLineChartAsync(LeadsDashboardFilter leadFilter, string? userId);
        Task<IList<LeadsDashboardChartModel>> GetLeadActivityStatusPieChartAsync(LeadsDashboardFilter leadFilter, string? userId);
    }
}
