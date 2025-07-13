using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class ClaimRateRepository : IClaimRateRepository
    {
        private readonly ISqlDbContext _claimRateRepository;
        public ClaimRateRepository(ISqlDbContext claimRepository)
        {
            _claimRateRepository = claimRepository;
        }

        public async Task<string?> UpsertclaimRateAsync(string? userId, ClaimRateEntity ClaimRateObj)
        {
            var para = new DynamicParameters();
            para.Add("@ClaimRateId", ClaimRateObj.ClaimRateId);
            para.Add("@ServiceClaimTypeId", ClaimRateObj.ServiceClaimTypeId);
            para.Add("@ServiceId", ClaimRateObj.ServiceId);
            para.Add("@ProductDivCode", ClaimRateObj.ProductDivCode);
            para.Add("@ProductLineCode", ClaimRateObj.ProductLineCode);
            para.Add("@IsMinor", ClaimRateObj.IsMinor);
            para.Add("@ActivityId", ClaimRateObj.ActivityId);
            para.Add("@UserId", userId);
            para.Add("@IsActive", ClaimRateObj.IsActive);

            return await _claimRateRepository.ExecuteScalarAsync<string?>(ClaimRateQueries.UpsertClaimRate, para);
        }

        public async Task<string?> UpsertclaimRateDetailsAsync(string? userId, string? claimRId, ClaimRateDetailsEntity ClaimRateDetailValObj)
        {
            var para = new DynamicParameters();
            para.Add("@ClaimRateId", claimRId);
            para.Add("@RepairTypeId", ClaimRateDetailValObj.RepairTypeId);
            para.Add("@TravelClaimId", ClaimRateDetailValObj.TravelClaimId);
            para.Add("@ActivityTypeId", ClaimRateDetailValObj.ActivityTypeId);
            para.Add("@ParaDetail", ClaimRateDetailValObj.ParaDetail);
            para.Add("@ParaValue", ClaimRateDetailValObj.ParaValue);
            para.Add("@ParaCondition", ClaimRateDetailValObj.ParaCondition);
            para.Add("@ParaUOMId", ClaimRateDetailValObj.ParaUOMId);
            para.Add("@FixedQty", ClaimRateDetailValObj.FixedQty);
            para.Add("@FixedQtyValue", ClaimRateDetailValObj.FixedQtyValue);
            para.Add("@MaxAmount", ClaimRateDetailValObj.MaxAmount);
            para.Add("@MaximumAmountValue", ClaimRateDetailValObj.MaximumAmountValue);
            para.Add("@UserId", userId);
            para.Add("@ClaimRateDetailId", ClaimRateDetailValObj.ClaimRateDetailId);
            para.Add("@isUpdate", ClaimRateDetailValObj.isUpdate);
            return await _claimRateRepository.ExecuteScalarAsync<string?>(ClaimRateQueries.UpsertClaimRateDetails, para);
        }


        public async Task<IList<ClaimRateDisplayEntity>> GetAllclaimRateAsync(ClaimRateFilter crFilter)
        {
            var para = new DynamicParameters();
            para.Add("@TypeOfActivityId", crFilter.TypeOfActivityId);
            para.Add("@ProductDivCode", crFilter.ProductDivCode);
            para.Add("@ProductLineCode", crFilter.ProductLineCode);
            para.Add("@PageSize", crFilter.PageSize);
            para.Add("@PageNumber", crFilter.PageNumber);
            var lstlead = await _claimRateRepository.GetAllAsync<ClaimRateDisplayEntity>(ClaimRateQueries.GetAllClaimRateInfoGet, para);


            List<ClaimRateDisplayEntity> CRIlist = new List<ClaimRateDisplayEntity>();
            ClaimRateDisplayEntity Objcr = null;
            foreach (var item in lstlead)
            {
                Objcr = new ClaimRateDisplayEntity();
                Objcr.TotalRows = item.TotalRows;
                Objcr.ClaimRateId = item.ClaimRateId;
                Objcr.ServiceClaimTypeName = item.ServiceClaimTypeName;
                Objcr.ActivityName = item.ActivityName;

                Objcr.ServiceClaimTypeId = item.ServiceClaimTypeId;
                Objcr.ActivityId = item.ActivityId;
                Objcr.ProductDivCode = item.ProductDivCode;
                Objcr.ProductDiv = item.ProductDiv;
                Objcr.ProductLineCode = item.ProductLineCode;
                Objcr.ProductLine = item.ProductLine;
                Objcr.IsMinor = item.IsMinor;
                Objcr.ServiceName = item.ServiceName;
                Objcr.ServiceId = item.ServiceId;
                Objcr.IsActive = item.IsActive;
                Objcr.NoOfClaimRate = item.NoOfClaimRate;
                Objcr.TotalRows = item.TotalRows;


                var paraCrd = new DynamicParameters();
                paraCrd.Add("@ClaimRateId", item.ClaimRateId);

                var lstClaimRateDetail = await _claimRateRepository.GetAllAsync<ClaimRateDetailsEntity>(ClaimRateQueries.GetClaimRateDetails, paraCrd);

                List<ClaimRateDetailsEntity> CliamRateDetaillist = new List<ClaimRateDetailsEntity>();
                ClaimRateDetailsEntity ObjCrd = null;

                if (lstClaimRateDetail != null)
                {
                    foreach (var itemlcrd in lstClaimRateDetail)
                    {
                        ObjCrd = new ClaimRateDetailsEntity();
                        ObjCrd.ClaimRateId = itemlcrd.ClaimRateId;
                        ObjCrd.RepairTypeId = itemlcrd.RepairTypeId;
                        ObjCrd.TravelClaimId = itemlcrd.TravelClaimId;
                        ObjCrd.ActivityTypeId = itemlcrd.ActivityTypeId;

                        ObjCrd.RepairTypeName = itemlcrd.RepairTypeName;
                        ObjCrd.TravelClaimName = itemlcrd.TravelClaimName;
                        ObjCrd.ActivityTypeName = itemlcrd.ActivityTypeName;

                        ObjCrd.ParaDetail = itemlcrd.ParaDetail;
                        ObjCrd.ParaValue = itemlcrd.ParaValue;
                        ObjCrd.ParaCondition = itemlcrd.ParaCondition;
                        ObjCrd.ParaUOMId = itemlcrd.ParaUOMId;
                        ObjCrd.ParaUOM = itemlcrd.ParaUOM;
                        ObjCrd.FixedQty = itemlcrd.FixedQty;
                        ObjCrd.FixedQtyValue = itemlcrd.FixedQtyValue;
                        ObjCrd.MaxAmount = itemlcrd.MaxAmount;
                        ObjCrd.MaximumAmountValue = itemlcrd.MaximumAmountValue;

                        CliamRateDetaillist.Add(ObjCrd);
                    }
                }


                Objcr.ClaimRateDetails = CliamRateDetaillist;

                CRIlist.Add(Objcr);

            }


            return CRIlist.ToList();
        }


        public async Task<ClaimRateDisplayEntity?> GetclaimRateByIdAsync(int ClaimRateId)
        {
            var para = new DynamicParameters();
            para.Add("@ClaimRateId", ClaimRateId);
            var lstcr = await _claimRateRepository.GetAsync<ClaimRateDisplayEntity>(ClaimRateQueries.GetClaimRateGet, para);

            ClaimRateDisplayEntity Objcr = null;

            Objcr = new ClaimRateDisplayEntity();
            Objcr.TotalRows = lstcr.TotalRows;
            Objcr.ClaimRateId = lstcr.ClaimRateId;
            Objcr.ServiceClaimTypeId = lstcr.ServiceClaimTypeId;
            Objcr.ActivityId = lstcr.ActivityId;
            Objcr.ProductDivCode = lstcr.ProductDivCode;
            Objcr.ProductDiv = lstcr.ProductDiv;
            Objcr.ProductLineCode = lstcr.ProductLineCode;
            Objcr.ProductLine = lstcr.ProductLine;
            Objcr.IsMinor = lstcr.IsMinor;
            Objcr.ServiceId = lstcr.ServiceId;


            var paraCrd = new DynamicParameters();
            paraCrd.Add("@ClaimRateId", lstcr.ClaimRateId);

            var lstClaimRateDetail = await _claimRateRepository.GetAllAsync<ClaimRateDetailsEntity>(ClaimRateQueries.GetClaimRateDetails, paraCrd);

            List<ClaimRateDetailsEntity> CliamRateDetaillist = new List<ClaimRateDetailsEntity>();
            ClaimRateDetailsEntity ObjCrd = null;

            if (lstClaimRateDetail != null)
            {
                foreach (var itemlcrd in lstClaimRateDetail)
                {
                    ObjCrd = new ClaimRateDetailsEntity();

                    ObjCrd.ClaimRateDetailId = itemlcrd.ClaimRateDetailId;
                    ObjCrd.ClaimRateId = itemlcrd.ClaimRateId;
                    ObjCrd.RepairTypeId = itemlcrd.RepairTypeId;
                    ObjCrd.ActivityTypeId = itemlcrd.ActivityTypeId;
                    ObjCrd.TravelClaimId = itemlcrd.TravelClaimId;
                    ObjCrd.ParaDetail = itemlcrd.ParaDetail;
                    ObjCrd.ParaValue = itemlcrd.ParaValue;
                    ObjCrd.ParaCondition = itemlcrd.ParaCondition;
                    ObjCrd.ParaUOMId = itemlcrd.ParaUOMId;
                    ObjCrd.ParaUOM = itemlcrd.ParaUOM;
                    ObjCrd.FixedQty = itemlcrd.FixedQty;
                    ObjCrd.FixedQtyValue = itemlcrd.FixedQtyValue;
                    ObjCrd.MaxAmount = itemlcrd.MaxAmount;
                    ObjCrd.MaximumAmountValue = itemlcrd.MaximumAmountValue;
                    ObjCrd.isUpdate = itemlcrd.isUpdate;
                    CliamRateDetaillist.Add(ObjCrd);
                }
            }


            Objcr.ClaimRateDetails = CliamRateDetaillist;


            return Objcr;
        }


        public async Task<string?> DeleteclaimRateDetails(int? ClaimRateDetailId)
        {
            var para = new DynamicParameters();
            para.Add("@ClaimRateDetailId", ClaimRateDetailId);
            var result = await _claimRateRepository.ExecuteScalarAsync<string?>(ClaimRateQueries.DeleteClaimRateDetailGet, para);
            return result;
        }

        public async Task<string?> DeleteclaimRateinfoAsync(int ClaimRateId, string userId, int isActive)
        {
            var para = new DynamicParameters();
            para.Add("@ClaimRateId", ClaimRateId);
            para.Add("@UserId", userId);
            para.Add("@IsActive", isActive);
            return await _claimRateRepository.ExecuteScalarAsync<string?>(ClaimRateQueries.DeleteClaimRateifoGet, para);
        }

    }
}
