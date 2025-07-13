using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;

namespace IG.CG.Core.Application.Specification
{

    public class ServiceTicketClaimRateDetailService : IServiceTicketClaimRateDetailService
    {
        private readonly IMapper _mapper;
        private readonly IServiceTicketClaimRateDetailRepository _activityClaimRepository;
        public ServiceTicketClaimRateDetailService(IMapper mapper, IServiceTicketClaimRateDetailRepository activityClaimRepository)
        {
            _mapper = mapper;
            _activityClaimRepository = activityClaimRepository;

        }
        public async Task<IList<ServiceTicketClaimRateDetailModel>> GetAllServiceTicketClaimRateDetailAsync(int serviceTicketId)
        {
            var ServiceTicketClaimRate = await _activityClaimRepository.GetAllServiceTicketClaimRateDetailAsync(serviceTicketId);
            var ServiceTicketClaimRateModel = _mapper.Map<List<ServiceTicketClaimRateDetailModel>>(ServiceTicketClaimRate.ToList());
            return ServiceTicketClaimRateModel;
        }

    }
}
