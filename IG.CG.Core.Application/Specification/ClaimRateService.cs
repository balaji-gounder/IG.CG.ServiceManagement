using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Specification
{
    public class ClaimRateService : IClaimRateService
    {
        private readonly IMapper _mapper;
        private readonly IClaimRateRepository _claimRateRepository;
        public ClaimRateService(IMapper mapper, IClaimRateRepository claimRateRepository)
        {
            _mapper = mapper;
            _claimRateRepository = claimRateRepository;

        }

        public async Task<string?> UpsertclaimRateAsync(ClaimRateModel ClaimRModel, string? userId)
        {
            string? result = null;
            string? claimRId = null;
            var lstclaimRateDetailsModel = _mapper.Map<List<ClaimRateDetailsEntity>>(ClaimRModel.ClaimRateDetails);

            var lstclaimRateModel = _mapper.Map<ClaimRateEntity>(ClaimRModel);

            claimRId = await _claimRateRepository.UpsertclaimRateAsync(userId, lstclaimRateModel);


            await _claimRateRepository.DeleteclaimRateDetails(ClaimRModel.ClaimRateId);


            foreach (var paraVal in lstclaimRateDetailsModel)
            {
                result = await _claimRateRepository.UpsertclaimRateDetailsAsync(userId, claimRId, paraVal);
            }

            return claimRId;

        }

        public async Task<IList<ClaimRateDisplayModel>> GetAllclaimRateAsync(ClaimRateFilter ClaimRateFilter)
        {
            var ClaimR = await _claimRateRepository.GetAllclaimRateAsync(ClaimRateFilter);
            var ClaimRModel = _mapper.Map<List<ClaimRateDisplayModel>>(ClaimR.ToList());
            return ClaimRModel;
        }

        public async Task<ClaimRateDisplayModel> GetclaimRateByIdAsync(int ClaimRateId)
        {
            var ClaimR = await _claimRateRepository.GetclaimRateByIdAsync(ClaimRateId);
            var ClaimRModel = _mapper.Map<ClaimRateDisplayModel>(ClaimR);
            return ClaimRModel;
        }
        public async Task<string?> DeleteclaimRateinfoAsync(int ClaimRateId, string? userId, int isActive)
        {
            return await _claimRateRepository.DeleteclaimRateinfoAsync(ClaimRateId, userId, isActive);
        }

        public async Task<string?> DeleteclaimRateDetails(int? ClaimRateDetailId)
        {
            return await _claimRateRepository.DeleteclaimRateDetails(ClaimRateDetailId);
        }
    }
}
