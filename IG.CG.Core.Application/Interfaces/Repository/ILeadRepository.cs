using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Interfaces.Repository
{
    public interface ILeadRepository
    {

        Task<string?> UpsertLeadAsync(LeadEntity leadObj);
        Task<IList<LeadDisplayEntity>> GetAllLeadAsync(LeadFilter leadFilter, string? userId);
        Task<LeadDisplayEntity?> GetLeadByIdAsync(int leadId);

        Task<string?> DeleteLeadAsync(int? leadId, string? userId, int? isActive, string? DeleteRemark);
        Task<string?> DeleteLeadProductAsync(int DivisionLeadId);
        Task<IList<LeadsDashboardEntity>> GetLeadsDashboardAsync(LeadsDashboardFilter leadFilter, string? userId);

        Task<IList<LeadsDashboardChartEntity>> GetMonthWishLeadsLineChartAsync(LeadsDashboardFilter leadFilter, string? userId);
        Task<IList<LeadsDashboardChartEntity>> GetLeadActivityStatusPieChartAsync(LeadsDashboardFilter leadFilter, string? userId);
    }
}
