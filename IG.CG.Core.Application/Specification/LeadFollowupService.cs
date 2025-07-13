using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Specification
{
    public class LeadFollowupService : ILeadsFollowupListService
    {
        private readonly IMapper _mapper;
        private readonly ILeadsFollowupListRepository _leadFollowupRepository;
        public LeadFollowupService(IMapper mapper, ILeadsFollowupListRepository leadFollowupRepository)
        {
            _mapper = mapper;
            _leadFollowupRepository = leadFollowupRepository;

        }

        public async Task<IList<LeadsFollowupListModel>> GetAllLeadFollowuplistAsync(LeadFilter leadFilter, string? userId)
        {
            var leadFollowup = await _leadFollowupRepository.GetAllLeadFollowuplistAsync(leadFilter, userId);
            var leadFollowupModel = _mapper.Map<List<LeadsFollowupListModel>>(leadFollowup.ToList());
            return leadFollowupModel;
        }

        public async Task<IList<LeadActivityModel>> GetAllLeadActivityAsync(int ActivityId)
        {
            var leadActivity = await _leadFollowupRepository.GetAllLeadActivityAsync(ActivityId);
            var leadActivityModel = _mapper.Map<List<LeadActivityModel>>(leadActivity.ToList());
            return leadActivityModel;
        }





        public async Task<string?> UpsertleadFollowupAsync(LeadFollowupModel leadModel, string? userId, string? UploadDocuments)
        {
            LeadFollowupEntity leadObj = _mapper.Map<LeadFollowupEntity>(leadModel);
            leadObj.UserId = userId;
            leadObj.UploadDocuments = UploadDocuments;
            return await _leadFollowupRepository.UpsertleadFollowupAsync(leadObj);
        }

        public async Task<LeadFollowupSelectModel> GetAllLeadFollowupByIdAsync(int leadId)
        {
            var lead = await _leadFollowupRepository.GetAllLeadFollowupByIdAsync(leadId);
            var leadModel = _mapper.Map<LeadFollowupSelectModel>(lead);
            return leadModel;
        }



    }
}
