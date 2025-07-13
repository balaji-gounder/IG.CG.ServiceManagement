

using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Specification
{
    public class STStatusService : ISTStatusService
    {
        private readonly IMapper _mapper;
        private readonly ISTStatusRepository _stStatusRepository;
        public STStatusService(IMapper mapper, ISTStatusRepository stStatusRepository)
        {
            _mapper = mapper;
            _stStatusRepository = stStatusRepository;

        }

        public async Task<string?> UpsertSTStatusAsync(STStatusModel stStatusModel, string? userId)
        {
            STStatusEntity stStatusObj = _mapper.Map<STStatusEntity>(stStatusModel);
            stStatusObj.UserId = userId;
            return await _stStatusRepository.UpsertSTStatusAsync(stStatusObj);
        }

        public async Task<IList<STStatusModel>> GetAllSTStatusAsync(STStatusFilter stStatusFilter)
        {
            var stStatus = await _stStatusRepository.GetAllSTStatusAsync(stStatusFilter);
            var stStatusModel = _mapper.Map<List<STStatusModel>>(stStatus.ToList());
            return stStatusModel;
        }

        public async Task<STStatusModel> GetSTStatusByIdAsync(int stStatusId)
        {
            var stStatus = await _stStatusRepository.GetSTStatusByIdAsync(stStatusId);
            var stStatusModel = _mapper.Map<STStatusModel>(stStatus);
            return stStatusModel;
        }

        public async Task<string?> DeleteSTStatusAsync(int stStatusId, string? userId, int isActive)
        {
            return await _stStatusRepository.DeleteSTStatusAsync(stStatusId, userId, isActive);
        }

    }
}
