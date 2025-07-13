using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;
using IG.CG.Core.Domain.Utility;

namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly ISqlDbContext _UserRepository;
        EncDec _objED = new EncDec();
        public UserRepository(ISqlDbContext userRepository)
        {
            _UserRepository = userRepository;
        }

        public async Task<string?> UpsertUserAsync(UserEntity userObj)
        {

            var paraSConfig = new DynamicParameters();
            paraSConfig.Add("@ConfigKey", userObj.UserTypeCode);
            var UserPassword = await _UserRepository.ExecuteScalarAsync<string?>(UserQueries.GetSystemConfigGet, paraSConfig);


            var EncPassword = _objED.Encrypt(UserPassword);

            var para = new DynamicParameters();
            para.Add("@UserAutoId", userObj.UserAutoId);
            para.Add("@UserId", userObj.UserId);
            para.Add("@UserPassword", EncPassword);
            para.Add("@UserName", userObj.UserName);
            para.Add("@UserEmailId", userObj.UserEmailId);
            para.Add("@RoleCode", userObj.RoleCode);
            para.Add("@UserTypeCode", userObj.UserTypeCode);
            para.Add("@MappingId", userObj.MappingId);
            para.Add("@CreatedBy", userObj.CreatedBy);
            para.Add("@BranchCode", userObj.BranchCode);
            para.Add("@DivisionCode", userObj.DivisionCode);
            para.Add("@ProductLineCode", userObj.ProductLineCode);
            para.Add("@MobileNo", userObj.MobileNo);
            para.Add("@IsActive", userObj.IsActive);
            return await _UserRepository.ExecuteScalarAsync<string?>(UserQueries.UpsertUser, para);

        }

        public async Task<string?> DeleteUserAsync(int userAutoId, string userId, int isActive)
        {
            var para = new DynamicParameters();
            para.Add("@UserAutoId", userAutoId);
            para.Add("@CreateBy", userId);
            para.Add("@IsActive", isActive);
            return await _UserRepository.ExecuteScalarAsync<string?>(UserQueries.DeleteUser, para);
        }

        public async Task<IList<UserDisplayEntity>> GetAllUserAsync(UserFilter userFilter)
        {
            var para = new DynamicParameters();
            para.Add("@UserName", userFilter.UserName);
            para.Add("@UserTypeCode", userFilter.UserTypeCode);
            para.Add("@RoleCode", userFilter.RoleCode);
            para.Add("@RegionCode", userFilter.RegionCode);
            para.Add("@PageSize", userFilter.PageSize);
            para.Add("@PageNumber", userFilter.PageNumber);
            var lstRegion = await _UserRepository.GetAllAsync<UserDisplayEntity>(UserQueries.AllUser, para);
            return lstRegion.ToList();
        }

        public async Task<UserDisplayEntity?> GetUserByIdAsync(string userId)
        {
            var sp_params = new DynamicParameters();
            sp_params.Add("@userId", userId);
            sp_params.Add("@Mode", 1);
            var lstUser = await _UserRepository.GetAsync<UserDisplayEntity>(UserQueries.GetUserById, sp_params);
            UserDisplayEntity ObjUser = new UserDisplayEntity();
            if (lstUser is not null)
            {
                ObjUser.UserAutoId = lstUser.UserAutoId;
                ObjUser.UserId = lstUser.UserId;
                ObjUser.UserTypeCode = lstUser.UserTypeCode;
                ObjUser.UserEmailId = lstUser.UserEmailId;
                ObjUser.MobileNo = lstUser.MobileNo;
                ObjUser.UserName = lstUser.UserName;
                ObjUser.RoleCode = lstUser.RoleCode;
                ObjUser.MappingId = lstUser.MappingId;
                ObjUser.IsActive = lstUser.IsActive;
            }
            // ------------------------------------Division ----------
            var paraD = new DynamicParameters();
            paraD.Add("@Id", userId);
            paraD.Add("@Mode", "1");
            var lstDivUser = await _UserRepository.GetAllAsync<ParaTypeEntity>(UserQueries.AllUserByProductList, paraD);

            List<ParaTypeEntity> Divisionlist = new List<ParaTypeEntity>();
            ParaTypeEntity ObjDiv = null;
            if (lstDivUser != null)
            {
                foreach (var itemldp in lstDivUser)
                {
                    ObjDiv = new ParaTypeEntity();
                    ObjDiv.ParameterTypeId = itemldp.ParameterTypeId;
                    ObjDiv.ParameterType = itemldp.ParameterType;

                    Divisionlist.Add(ObjDiv);
                }
            }

            // ----------------------------------------- Product Line --------------

            var paraPL = new DynamicParameters();
            paraPL.Add("@Id", userId);
            paraPL.Add("@Mode", "3");
            var lstProLineUser = await _UserRepository.GetAllAsync<ParaTypeEntity>(UserQueries.AllUserByProductList, paraPL);

            List<ParaTypeEntity> ProductLinelist = new List<ParaTypeEntity>();
            ParaTypeEntity ObjPL = null;
            if (lstProLineUser != null)
            {
                foreach (var itemlPL in lstProLineUser)
                {
                    ObjPL = new ParaTypeEntity();
                    ObjPL.ParameterTypeId = itemlPL.ParameterTypeId;
                    ObjPL.ParameterType = itemlPL.ParameterType;

                    ProductLinelist.Add(ObjPL);
                }
            }


            // ----------------------------------------- Product Line --------------

            var paraB = new DynamicParameters();
            paraB.Add("@Id", userId);
            paraB.Add("@Mode", "4");
            var lstBranchUser = await _UserRepository.GetAllAsync<ParaTypeEntity>(UserQueries.AllUserByProductList, paraB);

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

            ObjUser.BranchCodeList = Branchlist;
            ObjUser.ProductLineCodeList = ProductLinelist;

            ObjUser.DivisionCodeList = Divisionlist;

            return ObjUser;

        }


        public async Task<IList<MasterEntity>> GetAllUserWishMstByUserIdAsync(MasterFilter userFilter)
        {
            var para = new DynamicParameters();
            para.Add("@userAutoId", userFilter.Id);
            para.Add("@Mode", userFilter.modeId);

            var lstRegion = await _UserRepository.GetAllAsync<MasterEntity>(UserQueries.GetUserById, para);
            return lstRegion.ToList();
        }


    }
}
