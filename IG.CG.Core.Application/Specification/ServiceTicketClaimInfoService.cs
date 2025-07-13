using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Specification
{

    public class ServiceTicketClaimInfoService : IServiceTicketClaimInfoService
    {
        private readonly IMapper _mapper;
        private readonly IServiceTicketClaimInfoRepository _StClaimRepository;
        public ServiceTicketClaimInfoService(IMapper mapper, IServiceTicketClaimInfoRepository StClaimRepository)
        {
            _mapper = mapper;
            _StClaimRepository = StClaimRepository;

        }

        public async Task<string?> UpsertServiceTicketClaimInfoAsync(List<ServiceTicketClaimInfoModel> lstActivity, string? userId, string? ServiceTicketId)
        {
            string? result = null;
            var activityEntity = _mapper.Map<List<ServiceTicketClaimInfoEntity>>(lstActivity);
            var CNo = 0;

            result = await _StClaimRepository.UpsertClaimStatusAsync(ServiceTicketId, userId);


            foreach (var activity in activityEntity)
            {
                CNo = CNo + 1;
                activity.ClaimNo = CNo.ToString();
                result = await _StClaimRepository.UpsertServiceTicketClaimInfoAsync(activity, userId);
            }
            return result;
        }





        public async Task<string?> UpsertServiceTicketDeviationClaimInfoAsync(ServiceTicketDeviationClaimInfoModel lstClaim, string? userId)
        {

            ServiceTicketDeviationClaimInfoEntity ClaimObj = _mapper.Map<ServiceTicketDeviationClaimInfoEntity>(lstClaim);
            ClaimObj.UserId = userId;
            return await _StClaimRepository.UpsertServiceTicketDeviationClaimInfoAsync(ClaimObj);

        }


    }
}
