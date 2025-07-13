using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Specification
{
    public class AddRightsService: IAddRightsService
    {
        private readonly IMapper _mapper;
        private readonly IUAddRightsRepository _uAddRightRepository;
        public AddRightsService(IMapper mapper, IUAddRightsRepository uAddRightRepository)
        {
            _mapper = mapper;
            _uAddRightRepository = uAddRightRepository;
        }

        public async Task<string?> DeleteUAddRightsAsync(int UAddAutoId, string? userId, int isActive)
        {
            return await _uAddRightRepository.DeleteUAddRightsAsync(UAddAutoId, userId, isActive);
        }

        public async Task<IList<UserAdditionalRightsModel>> GetAllUAddRightsAsync(UAddRightsFilter uaddRightsFilter)
        {
            var userAddRights = await _uAddRightRepository.GetAllUAddRightsAsync(uaddRightsFilter);
            var userAddModel = _mapper.Map<List<UserAdditionalRightsModel>>(userAddRights.ToList());
            return userAddModel;
        }

        public async Task<string?> InsertUAddRightsAsync(UserAdditionalRightsModel userAddRightsModel, string? userId)
        {
            UserAdditionalRightsEntity uAddRightsEntity = _mapper.Map<UserAdditionalRightsEntity>(userAddRightsModel);
            uAddRightsEntity.UserId = userId;
            return await _uAddRightRepository.UpsertUAddRightsAsync(uAddRightsEntity);
        }
    }
}
