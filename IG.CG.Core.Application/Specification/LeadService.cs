using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Specification
{
    public class LeadService : ILeadService
    {
        private readonly IMapper _mapper;
        private readonly ILeadRepository _leadRepository;
        public LeadService(IMapper mapper, ILeadRepository leadRepository)
        {
            _mapper = mapper;
            _leadRepository = leadRepository;

        }

        public async Task<IList<LeadDisplayModel>> GetAllLeadAsync(LeadFilter leadFilter, string? userId)
        {
            var lead = await _leadRepository.GetAllLeadAsync(leadFilter, userId);
            var leadModel = _mapper.Map<List<LeadDisplayModel>>(lead.ToList());
            return leadModel;
        }
        public async Task<string?> UpsertLeadAsync(LeadModel leadModel, string? userId)
        {
            LeadEntity leadObj = _mapper.Map<LeadEntity>(leadModel);
            leadObj.UserId = userId;
            return await _leadRepository.UpsertLeadAsync(leadObj);
        }

        public async Task<LeadDisplayModel> GetLeadByIdAsync(int leadId)
        {
            var lead = await _leadRepository.GetLeadByIdAsync(leadId);
            var leadModel = _mapper.Map<LeadDisplayModel>(lead);
            return leadModel;
        }

        public async Task<string?> DeleteLeadAsync(int? leadId, string? userId, int? isActive, string? DeleteRemark)
        {
            return await _leadRepository.DeleteLeadAsync(leadId, userId, isActive, DeleteRemark);
        }

        public async Task<string?> DeleteLeadProductAsync(int DivisionLeadId)
        {
            return await _leadRepository.DeleteLeadProductAsync(DivisionLeadId);
        }


        public async Task<IList<LeadsDashboardModel>> GetLeadsDashboardAsync(LeadsDashboardFilter leadFilter, string? userId)
        {
            var lead = await _leadRepository.GetLeadsDashboardAsync(leadFilter, userId);
            var leadModel = _mapper.Map<List<LeadsDashboardModel>>(lead.ToList());
            return leadModel;
        }


        public async Task<IList<LeadsDashboardChartModel>> GetMonthWishLeadsLineChartAsync(LeadsDashboardFilter leadFilter, string? userId)
        {
            var lead = await _leadRepository.GetMonthWishLeadsLineChartAsync(leadFilter, userId);
            var leadModel = _mapper.Map<List<LeadsDashboardChartModel>>(lead.ToList());
            return leadModel;
        }

        public async Task<IList<LeadsDashboardChartModel>> GetLeadActivityStatusPieChartAsync(LeadsDashboardFilter leadFilter, string? userId)
        {
            var lead = await _leadRepository.GetLeadActivityStatusPieChartAsync(leadFilter, userId);
            var leadModel = _mapper.Map<List<LeadsDashboardChartModel>>(lead.ToList());
            return leadModel;
        }
    }
}
