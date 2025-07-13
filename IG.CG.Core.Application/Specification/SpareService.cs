using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Specification
{
    public class SpareService : ISpareService
    {
        private readonly IMapper _mapper;
        private readonly ISpareRepository _spareRepository;
        public SpareService(IMapper mapper, ISpareRepository spareRepository)
        {
            _mapper = mapper;
            _spareRepository = spareRepository;

        }

        public async Task<string?> UpsertSpareAsync(SpareModel spareModel, string? userId)
        {
            SpareEntity spareObj = _mapper.Map<SpareEntity>(spareModel);
            spareObj.UserId = userId;
            return await _spareRepository.UpsertSpareAsync(spareObj);
        }

        public async Task<SpareModel> GetSpareByIdAsync(int SpareId)
        {
            var Spare = await _spareRepository.GetSpareByIdAsync(SpareId);
            var spareModel = _mapper.Map<SpareModel>(Spare);
            return spareModel;
        }

        public async Task<IList<SpareDisplayModel>> GetAllSpareAsync(SpareFilter spareFilter)
        {
            var Spare = await _spareRepository.GetAllSpareAsync(spareFilter);
            var spareModel = _mapper.Map<List<SpareDisplayModel>>(Spare.ToList());
            return spareModel;
        }

        public async Task<string?> DeleteSpareAsync(int SpareId, string? userId, int isActive)
        {
            return await _spareRepository.DeleteSpareAsync(SpareId, userId, isActive);
        }

    }
}
