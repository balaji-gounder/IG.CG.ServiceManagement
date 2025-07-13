
using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Specification
{
    public class ClaimApprovalHistoryService : IClaimApprovalHistoryService
    {
        private readonly IMapper _mapper;
        private readonly IClaimApprovalHistoryRepository _claimApprovalHistoryRepository;
        public ClaimApprovalHistoryService(IMapper mapper, IClaimApprovalHistoryRepository claimApprovalHistoryRepository)
        {
            _mapper = mapper;
            _claimApprovalHistoryRepository = claimApprovalHistoryRepository;

        }

        public async Task<int?> UpsertClaimApprovalHistoryAsync(List<ClaimApprovalHistoryModel> lstClaimApprovalHistory, string? userId)
        {
            int? result = null;
            var claimApprovalHistoryEntity = _mapper.Map<List<ClaimApprovalHistoryEntity>>(lstClaimApprovalHistory);

            foreach (var claimApprovalHistory in claimApprovalHistoryEntity)
            {
                result = await _claimApprovalHistoryRepository.UpsertClaimApprovalHistoryAsync(claimApprovalHistory, userId);
            }
            return result;
        }

        public async Task<IList<ClaimApprovalHistoryDisplayModel>> GetAllClaimApprovalHistoryAsync(int serviceTicketClaimId)
        {
            var ClaimApprovalHistory = await _claimApprovalHistoryRepository.GetAllClaimApprovalHistoryAsync(serviceTicketClaimId);
            var ClaimApprovalHistoryModel = _mapper.Map<List<ClaimApprovalHistoryDisplayModel>>(ClaimApprovalHistory.ToList());
            return ClaimApprovalHistoryModel;
        }

        public async Task<int?> UpsertSpecialApprovalHistoryAsync(List<SpecialApprovalHistoryModel> lstClaimApprovalHistory, string? userId)
        {
            int? result = null;
            var claimApprovalHistoryEntity = _mapper.Map<List<SpecialApprovalHistoryEntity>>(lstClaimApprovalHistory);

            foreach (var claimApprovalHistory in claimApprovalHistoryEntity)
            {
                result = await _claimApprovalHistoryRepository.UpsertSpecialApprovalHistoryAsync(claimApprovalHistory, userId);
            }
            return result;
        }

        public async Task<IList<SpecialApprovalHistoryDisplayModel>> GetAllSpecialApprovalHistoryAsync(int specialApprovalId)
        {
            var SpecialApprovalHistory = await _claimApprovalHistoryRepository.GetAllSpecialApprovalHistoryAsync(specialApprovalId);
            var SpecialApprovalHistoryModel = _mapper.Map<List<SpecialApprovalHistoryDisplayModel>>(SpecialApprovalHistory.ToList());
            return SpecialApprovalHistoryModel;
        }

    }
}
