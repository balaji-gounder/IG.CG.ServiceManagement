using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Interfaces.Repository
{
    public interface ITicketReportRepository
    {
        Task<IList<AscServiceTicketInfoComplaintReportEntity>> GetAllComplaintReportAsync(ReportFilter reportFilter);

        Task<IList<ClaimApprovalTATReportEntity>> GetAllClaimApprovalTATReportAsync(ReportFilter reportFilter);

        Task<IList<ServiceTicketDefectReportEntity>> GetAllDefectReportAsync(ReportFilter reportFilter);

        Task<IList<DurationTicketTatDashboardEntity>> GetAllDurationTicketTatDashboardAsync(DurationTicketFilter reportFilter);

        Task<IList<DurationTicketTatDashboardEntity>> GetAllDurationOpenTicketTatDashboardAsync(DurationTicketFilter reportFilter);


        Task<IList<ComplaintCancelReportEntity>> GetAllCancelReportTicketAsync(ReportFilter reportFilter);


        Task<IList<RepeatedTicketsReportEntity>> GetAllRepeatedTicketsReportAsync(ReportFilter reportFilter);
    }




}
