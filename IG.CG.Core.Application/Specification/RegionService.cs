using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Specification
{
    public class RegionService : IRegionService
    {
        private readonly IMapper _mapper;
        private readonly IRegionRepository _regionRepository;
        public RegionService(IMapper mapper, IRegionRepository regionRepository)
        {
            _mapper = mapper;
            _regionRepository = regionRepository;
        }
        public async Task<IList<RegionModel>> GetAllRegionAsync(RegionFilter regionFilter)
        {
            var region = await _regionRepository.GetAllRegionAsync(regionFilter);
            var regionModel = _mapper.Map<List<RegionModel>>(region.ToList());
            return regionModel;
        }


        public async Task<IList<RegionModel>> GetAllUserwiseRegionAsync(string? userId)
        {
            var region = await _regionRepository.GetAllUserwiseRegionAsync(userId);
            var regionModel = _mapper.Map<List<RegionModel>>(region.ToList());
            return regionModel;
        }

        public async Task<RegionModel> GetRegionByIdAsync(int regionId)
        {
            var region = await _regionRepository.GetRegionByIdAsync(regionId);
            var regionModel = _mapper.Map<RegionModel>(region);
            return regionModel;
        }

        public async Task<string?> UpsertRegionAsync(RegionModel regionModel, string? userId)
        {
            RegionEntity regionObj = _mapper.Map<RegionEntity>(regionModel);
            regionObj.UserId = userId;
            return await _regionRepository.UpsertRegionAsync(regionObj);
        }
        public async Task<string?> DeleteRegionAsync(int regionId, string? userId, int isActive)
        {
            return await _regionRepository.DeleteRegionAsync(regionId, userId, isActive);
        }
    }
}
