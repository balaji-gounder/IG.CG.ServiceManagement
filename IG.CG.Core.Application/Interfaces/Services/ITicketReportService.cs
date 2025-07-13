using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;

namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface ITicketReportService
    {
        Task<IList<AscServiceTicketInfoComplaintReportModel>> GetAllComplaintReportAsync(ReportFilter reportFilter, string? UserId);

        Task<IList<ClaimApprovalTATReportModel>> GetAllClaimApprovalTATReportAsync(ReportFilter reportFilter, string? UserId);

        Task<IList<ServiceTicketDefectReportModel>> GetAllDefectReportAsync(ReportFilter reportFilter, string? UserId, bool isExport);

        Task<IList<DurationTicketTatDashboardModel>> GetAllDurationTicketTatDashboardAsync(DurationTicketFilter reportFilter, string? UserId);

        Task<IList<DurationTicketTatDashboardModel>> GetAllDurationOpenTicketTatDashboardAsync(DurationTicketFilter reportFilter, string? UserId);

        Task<IList<ComplaintCancelReportModel>> GetAllCancelReportTicketAsync(ReportFilter reportFilter, string? UserId);

        Task<IList<RepeatedTicketsReportModel>> GetAllRepeatedTicketsReportAsync(ReportFilter reportFilter, string? UserId);
    }
}
