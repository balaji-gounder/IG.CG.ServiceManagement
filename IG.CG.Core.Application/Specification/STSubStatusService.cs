
using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Specification
{
    public class STSubStatusService : ISTSubStatusService
    {
        private readonly IMapper _mapper;
        private readonly ISTSubStatusRepository _stSubStatusRepository;
        public STSubStatusService(IMapper mapper, ISTSubStatusRepository stSubStatusRepository)
        {
            _mapper = mapper;
            _stSubStatusRepository = stSubStatusRepository;

        }

        public async Task<string?> UpsertSTSubStatusAsync(STSubStatusModel stSubStatusModel, string? userId)
        {
            STSubStatusEntity stSubStatusObj = _mapper.Map<STSubStatusEntity>(stSubStatusModel);
            stSubStatusObj.UserId = userId;
            return await _stSubStatusRepository.UpsertSTSubStatusAsync(stSubStatusObj);
        }

        public async Task<IList<STSubStatusModel>> GetAllSTSubStatusAsync(STSubStatusFilter stSubStatusFilter)
        {
            var stSubStatus = await _stSubStatusRepository.GetAllSTSubStatusAsync(stSubStatusFilter);
            var stSubStatusModel = _mapper.Map<List<STSubStatusModel>>(stSubStatus.ToList());
            return stSubStatusModel;
        }
        public async Task<STSubStatusModel> GetSTSubStatusByIdAsync(int stSubStatusId)
        {
            var stSubStatus = await _stSubStatusRepository.GetSTSubStatusByIdAsync(stSubStatusId);
            var stSubStatusModel = _mapper.Map<STSubStatusModel>(stSubStatus);
            return stSubStatusModel;
        }
        public async Task<string?> DeleteSTSubStatusAsync(int stSubStatusId, string? userId, int isActive)
        {
            return await _stSubStatusRepository.DeleteSTSubStatusAsync(stSubStatusId, userId, isActive);
        }

        public async Task<IList<STSubStatusModel>> GetSTSubStatusByStatusAsync(int stStatusId)
        {
            var stSubStatus = await _stSubStatusRepository.GetSTSubStatusByStatusAsync(stStatusId);
            var stSubStatusModel = _mapper.Map<List<STSubStatusModel>>(stSubStatus.ToList());
            return stSubStatusModel;
        }

        public async Task<IList<STSubStatusByTypeModel>> GetAllSTSubStatusByTypeAsync(string? StatusType, int? ActiveId)
        {
            var stSubStatusByType = await _stSubStatusRepository.GetAllSTSubStatusByTypeAsync(StatusType, ActiveId);
            var stSubStatusByTypeModel = _mapper.Map<List<STSubStatusByTypeModel>>(stSubStatusByType.ToList());
            return stSubStatusByTypeModel;
        }
        public async Task<IList<ServiceTicketStatusModel>> GetServiceTicketStatusAsync(int? SubStatusid)
        {
            var stStatus = await _stSubStatusRepository.GetServiceTicketStatusAsync(SubStatusid);
            var stStatusModel = _mapper.Map<List<ServiceTicketStatusModel>>(stStatus.ToList());
            return stStatusModel;
        }
    }
}
