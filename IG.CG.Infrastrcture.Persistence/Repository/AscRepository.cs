using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class AscRepository : IASCRepository
    {
        private readonly ISqlDbContext _ascRepository;
        public AscRepository(ISqlDbContext ascRepository)
        {
            _ascRepository = ascRepository;
        }
        public async Task<string?> UpsertAscAsync(AscEntity ascObj)
        {

            var para = new DynamicParameters();
            para.Add("@AscId", ascObj.AscId);
            para.Add("@AscCode", ascObj.AscCode);
            para.Add("@CustCode", ascObj.CustCode);
            para.Add("@AscName", ascObj.Name);
            para.Add("@AscEmail", ascObj.EmailId);
            para.Add("@AscMobile", ascObj.MobileNo);
            para.Add("@ContactPersonName", ascObj.ContactPersonName);
            para.Add("@AscAadhar", ascObj.AadharNo);
            para.Add("@AscPAN", ascObj.PanNo);
            para.Add("@GSTApplicable", ascObj.IsGSTApplicable);
            para.Add("@GstNo", ascObj.GstNo);
            para.Add("@AgreementStartDate", ascObj.AgreementStartDate);
            para.Add("@AgreementEndDate", ascObj.AgreementEndDate);
            para.Add("@SecurityDeposit", ascObj.SecurityDeposit);
            para.Add("@HYAuditDate", ascObj.HYAuditDate);
            para.Add("@NoOfTechnicians", ascObj.NoOfTechnicians);
            para.Add("@AvailableMachines", ascObj.AvailableMachines);
            para.Add("@DocumentType", ascObj.DocumentType);
            para.Add("@DocumentPath", ascObj.DocumentPath);
            para.Add("@IsActive", ascObj.IsActive);
            para.Add("@CityId", ascObj.CityId);
            para.Add("@StateId", ascObj.StateId);
            para.Add("@PinId", ascObj.PinId);
            para.Add("@AscAddress", ascObj.AscAddress);
            para.Add("@UserId", ascObj.UserId);
            para.Add("@ProductLineCode", ascObj.ProductLineCode);
            para.Add("@DivisionCode", ascObj.DivisionCode);
            para.Add("@BranchCode", ascObj.BranchCode);
            para.Add("@TypeOfTicketTobeHandeled", ascObj.TypeOfTicketTobeHandeled);

            return await _ascRepository.ExecuteScalarAsync<string?>(AscQueries.UpsertAsc, para);


        }
        public async Task<string?> DeleteAscAsync(int ascId, string userId, int isActive)
        {
            var para = new DynamicParameters();
            para.Add("@AscId", ascId);
            para.Add("@UserId", userId);
            para.Add("@IsActive", isActive);
            return await _ascRepository.ExecuteScalarAsync<string?>(AscQueries.DeleteAsc, para);
        }
        public async Task<IList<AscDisplayEntity>> GetAllAscAsync(ASCFilter ascFilter, string UserId)
        {
            var para = new DynamicParameters();
            para.Add("@AscCode", ascFilter.AscCode);
            para.Add("@AscName", ascFilter.AscName);
            para.Add("@DivisionCode", ascFilter.DivisionCode);
            para.Add("@BranchCode", ascFilter.BranchCode);
            para.Add("@RegionCode", ascFilter.RegionCode);
            para.Add("@UserId", UserId);
            para.Add("@PageSize", ascFilter.PageSize);
            para.Add("@PageNumber", ascFilter.PageNumber);
            var lstAsc = await _ascRepository.GetAllAsync<AscDisplayEntity>(AscQueries.AllAsc, para);
            return lstAsc.ToList();
        }
        public async Task<AscDisplayEntity?> GetAscByIdAsync(int ascId)
        {
            var sp_params = new DynamicParameters();
            sp_params.Add("@AscId", ascId);

            var lstASD = await _ascRepository.GetAsync<AscDisplayEntity>(AscQueries.GetAscById, sp_params);


            AscDisplayEntity ObjASC = null;

            ObjASC = new AscDisplayEntity();

            ObjASC.AscId = lstASD.AscId;
            ObjASC.AscCode = lstASD.AscCode;
            ObjASC.CustCode = lstASD.CustCode;
            ObjASC.Name = lstASD.Name;
            ObjASC.EmailId = lstASD.EmailId;

            ObjASC.MobileNo = lstASD.MobileNo;
            ObjASC.ContactPersonName = lstASD.ContactPersonName;
            ObjASC.AadharNo = lstASD.AadharNo;
            ObjASC.IsGSTApplicable = lstASD.IsGSTApplicable;
            ObjASC.PanNo = lstASD.PanNo;

            ObjASC.GstNo = lstASD.GstNo;
            ObjASC.AgreementStartDate = lstASD.AgreementStartDate;
            ObjASC.AgreementEndDate = lstASD.AgreementEndDate;
            ObjASC.SecurityDeposit = lstASD.SecurityDeposit;
            ObjASC.HYAuditDate = lstASD.HYAuditDate;
            ObjASC.NoOfTechnicians = lstASD.NoOfTechnicians;


            ObjASC.AvailableMachines = lstASD.AvailableMachines;
            ObjASC.DocumentType = lstASD.DocumentType;
            ObjASC.StateId = lstASD.StateId;
            ObjASC.CityId = lstASD.CityId;
            ObjASC.PinId = lstASD.PinId;
            ObjASC.AscAddress = lstASD.AscAddress;
            ObjASC.DocumentPath = lstASD.DocumentPath;
            ObjASC.TypeOfTicketTobeHandeled = lstASD.TypeOfTicketTobeHandeled;

            ObjASC.IsActive = lstASD.IsActive;

            // ------------------------------------Division ----------
            var paraD = new DynamicParameters();
            paraD.Add("@Id", lstASD.AscCode);
            paraD.Add("@Mode", "1");
            var lstDivASC = await _ascRepository.GetAllAsync<ParaTypeEntity>(AscQueries.AllASCByProductList, paraD);

            List<ParaTypeEntity> Divisionlist = new List<ParaTypeEntity>();
            ParaTypeEntity ObjDiv = null;
            if (lstDivASC != null)
            {
                foreach (var itemldp in lstDivASC)
                {
                    ObjDiv = new ParaTypeEntity();
                    ObjDiv.ParameterTypeId = itemldp.ParameterTypeId;
                    ObjDiv.ParameterType = itemldp.ParameterType;

                    Divisionlist.Add(ObjDiv);
                }
            }
            // ----------------------------------------- Product Line --------------

            var paraPL = new DynamicParameters();
            paraPL.Add("@Id", lstASD.AscCode);
            paraPL.Add("@Mode", "3");
            var lstProLineASC = await _ascRepository.GetAllAsync<ParaTypeEntity>(AscQueries.AllASCByProductList, paraPL);

            List<ParaTypeEntity> ProductLinelist = new List<ParaTypeEntity>();
            ParaTypeEntity ObjPL = null;
            if (lstProLineASC != null)
            {
                foreach (var itemlPL in lstProLineASC)
                {
                    ObjPL = new ParaTypeEntity();
                    ObjPL.ParameterTypeId = itemlPL.ParameterTypeId;
                    ObjPL.ParameterType = itemlPL.ParameterType;

                    ProductLinelist.Add(ObjPL);
                }
            }


            var paraB = new DynamicParameters();
            paraB.Add("@Id", lstASD.AscCode);
            paraB.Add("@Mode", "4");
            var lstBranchUser = await _ascRepository.GetAllAsync<ParaTypeEntity>(AscQueries.AllASCByProductList, paraB);

            List<ParaTypeEntity> Branchlist = new List<ParaTypeEntity>();
            ParaTypeEntity ObjBranch = null;
            if (lstBranchUser != null)
            {
                foreach (var itemlPL in lstBranchUser)
                {
                    ObjBranch = new ParaTypeEntity();
                    ObjBranch.ParameterTypeId = itemlPL.ParameterTypeId;
                    ObjBranch.ParameterType = itemlPL.ParameterType;

                    Branchlist.Add(ObjBranch);
                }
            }



            ObjASC.BranchCodeList = Branchlist;
            ObjASC.ProductLineCodeList = ProductLinelist;

            ObjASC.DivisionCodeList = Divisionlist;

            return ObjASC;
        }



        public async Task<IList<ParaTypeEntity>> GetAllAscWishDivisionAsync(string AscCode)
        {
            var para = new DynamicParameters();
            para.Add("@Mode", "1");
            para.Add("@Id", AscCode);
            var lstType = await _ascRepository.GetAllAsync<ParaTypeEntity>(AscQueries.AllASCByProductList, para);
            return lstType.ToList();
        }






        public async Task<IList<ParaTypeEntity>> GetAllAscDivisionWishProductlineAsync(string AscCode, string DivCode)
        {
            var para = new DynamicParameters();
            para.Add("@ASCCode", AscCode);
            para.Add("@DivisionCode", DivCode);
            var lstType = await _ascRepository.GetAllAsync<ParaTypeEntity>(AscQueries.AllAscDivisionWishProductline, para);
            return lstType.ToList();

        }

        public async Task<IList<ParaTypeEntity>> GetAllAscWishPinCodeAsync(string AscCode)
        {
            var para = new DynamicParameters();
            para.Add("@Mode", "5");
            para.Add("@Id", AscCode);
            var lstType = await _ascRepository.GetAllAsync<ParaTypeEntity>(AscQueries.AllASCByProductList, para);
            return lstType.ToList();

        }

        public async Task<string?> UpsertAscApprovalAsync(AscApprovalEnitity ascObj)
        {
            var para = new DynamicParameters();
            para.Add("@UserId", ascObj.UserId);
            para.Add("@AscCode", ascObj.AscCode);
            para.Add("@WFAutoId", ascObj.WFAutoId);
            return await _ascRepository.ExecuteScalarAsync<string?>(AscQueries.UpsertASCApproval, para);

        }

        public async Task<IList<AscEntity>> GetAllProductlineWishAscAsync(string ProductlineCode)
        {
            var para = new DynamicParameters();

            para.Add("@ProductLineCode", ProductlineCode);
            var lstType = await _ascRepository.GetAllAsync<AscEntity>(AscQueries.AllProductlineByAscList, para);
            return lstType.ToList();

        }

        public async Task<IList<AscListEntity>> GetAllAscListAsync()
        {

            var lstAsc = await _ascRepository.GetAllAsync<AscListEntity>(AscQueries.AllAscList);
            return lstAsc.ToList();
        }

        public async Task<IList<AscWiseProductLineEntity>> GetAllAscWiseProductlineAsync(string AscCode)
        {
            var para = new DynamicParameters();

            para.Add("@AscCode", AscCode);
            var lstType = await _ascRepository.GetAllAsync<AscWiseProductLineEntity>(AscQueries.AllAscWiseProductLine, para);
            return lstType.ToList();

        }

        public async Task<IList<UserWiseDivisionEntity>> GetUserWiseDivisionAsync(string? UserCode)
        {
            var para = new DynamicParameters();

            para.Add("@UserId", UserCode);
            var lstDivision = await _ascRepository.GetAllAsync<UserWiseDivisionEntity>(AscQueries.GetAllUserWiseDivision, para);
            return lstDivision.ToList();

        }

        public async Task<IList<DivisionWiseProductLineEntity>> GetDivisionWiseProductLineAsync(string? DivisionCode, string? UserCode)
        {
            var para = new DynamicParameters();

            para.Add("@DivisionCode", DivisionCode);
            para.Add("@UserCode", UserCode);
            var lstProductLine = await _ascRepository.GetAllAsync<DivisionWiseProductLineEntity>(AscQueries.GetAllDivisionWiseProductLine, para);
            return lstProductLine.ToList();

        }

        public async Task<IList<AscListEntity>> GetUserWiseAscAsync(string? UserCode)
        {
            var para = new DynamicParameters();

            para.Add("@UserCode", UserCode);
            var lstAsc = await _ascRepository.GetAllAsync<AscListEntity>(AscQueries.GetAllUserWiseAsc, para);
            return lstAsc.ToList();

        }

    }
}
