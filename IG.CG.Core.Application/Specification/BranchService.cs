using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Specification
{
    public class BranchService : IBranchService
    {
        private readonly IMapper _mapper;
        private readonly IBranchRepository _branchRepository;
        public BranchService(IMapper mapper, IBranchRepository branchRepository)
        {
            _mapper = mapper;
            _branchRepository = branchRepository;

        }

        public async Task<IList<BranchDisplayModel>> GetAllBranchAsync(BranchFilter branchFilter)
        {
            var branch = await _branchRepository.GetAllBranchAsync(branchFilter);
            var branchModel = _mapper.Map<List<BranchDisplayModel>>(branch.ToList());
            return branchModel;
        }


        public async Task<BranchModel> GetBranchByIdAsync(int branchId)
        {
            var branch = await _branchRepository.GetBranchByIdAsync(branchId);
            var branchModel = _mapper.Map<BranchModel>(branch);
            return branchModel;
        }

        public async Task<string?> UpsertBranchAsync(BranchModel branchModel, string? userId)
        {
            BranchEntity branchObj = _mapper.Map<BranchEntity>(branchModel);
            branchObj.UserId = userId;
            return await _branchRepository.UpsertBranchAsync(branchObj);
        }
        public async Task<string?> DeleteBranchAsync(int branchId, string? userId, int isActive)
        {
            return await _branchRepository.DeleteBranchAsync(branchId, userId, isActive);
        }

        public async Task<IList<BranchDisplayModel>> GetAllUserWiseBranchAsync(BaseUserWishFilter branchFilter, string? userId)
        {
            var branch = await _branchRepository.GetAllUserWiseBranchAsync(branchFilter, userId);
            var branchModel = _mapper.Map<List<BranchDisplayModel>>(branch.ToList());
            return branchModel;
        }
    }
}
