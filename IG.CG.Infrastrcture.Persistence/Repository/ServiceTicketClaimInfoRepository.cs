using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Infrastrcture.Persistence.Repository
{

    public class ServiceTicketClaimInfoRepository : IServiceTicketClaimInfoRepository
    {
        private readonly ISqlDbContext _ClaimRepository;
        public ServiceTicketClaimInfoRepository(ISqlDbContext claimRepository)
        {
            _ClaimRepository = claimRepository;
        }


        public async Task<string?> UpsertServiceTicketClaimInfoAsync(ServiceTicketClaimInfoEntity activity, string? userId)
        {
            var para = new DynamicParameters();
            para.Add("@ServiceTicketClaimId", activity.ServiceTicketClaimId);
            para.Add("@ServiceTicketId", activity.ServiceTicketId);
            para.Add("@ClaimRateDetailId", activity.ClaimRateDetailId);
            para.Add("@SerialNo", activity.SerialNo);
            para.Add("@ActivityTypeId", activity.ActivityTypeId);
            para.Add("@ParaDetail", activity.ParaDetail);
            para.Add("@ParaValue", activity.ParaValue);
            para.Add("@RateAmount", activity.RateAmount);
            para.Add("@ClaimAmount", activity.ClaimAmount);
            para.Add("@ClaimNo", activity.ClaimNo);
            para.Add("@UserId", userId);
            para.Add("@IsDeviation", activity.IsDeviation);
            para.Add("@ActivityName", activity.ActivityName);
            para.Add("@CurrentDistance", activity.Distance);
            para.Add("@SysDistance", activity.SysDistance);
            para.Add("@SysDistanceValue", activity.SysDistanceValue);
            para.Add("@IsConveyance", activity.IsConveyance);
            para.Add("@IsEditable", activity.IsEditable);
            para.Add("@Remarks", activity.Remarks);
            var result = await _ClaimRepository.ExecuteScalarAsync<string?>(ServiceTicketClaimRateQueries.ServiceTicketClaimInsertUpdate, para);
            return result;
        }


        public async Task<string?> UpsertClaimStatusAsync(string? ServiceTicketId, string? userId)
        {
            var para = new DynamicParameters();
            para.Add("@ServiceTicketId", ServiceTicketId);
            para.Add("@userId", userId);
            var result = await _ClaimRepository.ExecuteScalarAsync<string?>(ServiceTicketClaimRateQueries.ClaimStatusInsertUpdate, para);
            return result;
        }




        public async Task<string?> UpsertServiceTicketDeviationClaimInfoAsync(ServiceTicketDeviationClaimInfoEntity activity)
        {
            var para = new DynamicParameters();
            para.Add("@ServiceTicketId", activity.ServiceTicketId);

            para.Add("@TypeClaim", activity.TypeClaim);
            para.Add("@SerialNo", activity.SerialNo);
            para.Add("@ClaimNo", activity.ClaimNo);
            para.Add("@ParaDetail", activity.ParaDetail);
            para.Add("@ClaimAmount", activity.ClaimAmount);
            para.Add("@AttachmentType", activity.AttachmentType);
            para.Add("@AttachmentName", activity.AttachmentName);
            para.Add("@AttachmentFile", activity.AttachmentFile);
            para.Add("@CurrentDistance", activity.CurrentDistance);
            para.Add("@SysDistance", activity.SysDistance);
            para.Add("@Remarks", activity.Remarks);
            para.Add("@UserId", activity.UserId);
            para.Add("@activityTypeId", activity.activityTypeId);
            para.Add("@ClaimDeviationTypeId", activity.ClaimDeviationTypeId);
            para.Add("@wayToDistance", activity.wayToDistance);
            para.Add("@modeOftravel", activity.modeOftravel);
            para.Add("@ParaValue", activity.ParaValue);
            var result = await _ClaimRepository.ExecuteScalarAsync<string?>(ServiceTicketClaimRateQueries.ServiceTicketDeviationClaimInsertUpdate, para);

            return result;
        }
    }
}
