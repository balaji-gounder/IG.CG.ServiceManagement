

using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;

namespace IG.CG.Core.Application.Specification
{
    public class TicketReportService : ITicketReportService
    {
        private readonly IMapper _mapper;
        private readonly ITicketReportRepository _TicketReportRepository;
        public TicketReportService(IMapper mapper, ITicketReportRepository TicketReportRepository)
        {
            _mapper = mapper;
            _TicketReportRepository = TicketReportRepository;

        }

        public async Task<IList<AscServiceTicketInfoComplaintReportModel>> GetAllComplaintReportAsync(ReportFilter ReportFilter, string? UserId)
        {
            ReportFilter.UserId = UserId;
            var Report = await _TicketReportRepository.GetAllComplaintReportAsync(ReportFilter);
            var ReportModel = _mapper.Map<List<AscServiceTicketInfoComplaintReportModel>>(Report.ToList());
            return ReportModel;
        }


        public async Task<IList<ClaimApprovalTATReportModel>> GetAllClaimApprovalTATReportAsync(ReportFilter ReportFilter, string? UserId)
        {
            ReportFilter.UserId = UserId;
            var Report = await _TicketReportRepository.GetAllClaimApprovalTATReportAsync(ReportFilter);
            var ReportModel = _mapper.Map<List<ClaimApprovalTATReportModel>>(Report.ToList());
            return ReportModel;
        }



        public async Task<IList<ServiceTicketDefectReportModel>> GetAllDefectReportAsync(ReportFilter ReportFilter, string? UserId, bool isExport)
        {
            ReportFilter.UserId = UserId;
            var Report = await _TicketReportRepository.GetAllDefectReportAsync(ReportFilter);
            var ReportModel = _mapper.Map<List<ServiceTicketDefectReportModel>>(Report.ToList());
            return ReportModel;
        }


        public async Task<IList<RepeatedTicketsReportModel>> GetAllRepeatedTicketsReportAsync(ReportFilter ReportFilter, string? UserId)
        {
            ReportFilter.UserId = UserId;
            var Report = await _TicketReportRepository.GetAllRepeatedTicketsReportAsync(ReportFilter);
            var ReportModel = _mapper.Map<List<RepeatedTicketsReportModel>>(Report.ToList());
            return ReportModel;
        }




        public async Task<IList<DurationTicketTatDashboardModel>> GetAllDurationTicketTatDashboardAsync(DurationTicketFilter DurationFilter, string? UserId)
        {
            DurationFilter.UserId = UserId;
            var Duration = await _TicketReportRepository.GetAllDurationTicketTatDashboardAsync(DurationFilter);
            var DurationModel = _mapper.Map<List<DurationTicketTatDashboardModel>>(Duration.ToList());
            return DurationModel;
        }

        public async Task<IList<DurationTicketTatDashboardModel>> GetAllDurationOpenTicketTatDashboardAsync(DurationTicketFilter DurationFilter, string? UserId)
        {
            DurationFilter.UserId = UserId;
            var Duration = await _TicketReportRepository.GetAllDurationOpenTicketTatDashboardAsync(DurationFilter);
            var DurationModel = _mapper.Map<List<DurationTicketTatDashboardModel>>(Duration.ToList());
            return DurationModel;
        }

        public async Task<IList<ComplaintCancelReportModel>> GetAllCancelReportTicketAsync(ReportFilter ReportFilter, string? UserId)
        {
            ReportFilter.UserId = UserId;
            var Report = await _TicketReportRepository.GetAllCancelReportTicketAsync(ReportFilter);
            var ReportModel = _mapper.Map<List<ComplaintCancelReportModel>>(Report.ToList());
            return ReportModel;
        }
    }
}
