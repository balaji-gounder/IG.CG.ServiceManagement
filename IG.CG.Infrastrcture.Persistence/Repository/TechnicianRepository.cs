using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class TechnicianRepository : ITechnicianRepository
    {
        private readonly ISqlDbContext _technicianRepository;
        public TechnicianRepository(ISqlDbContext technicianRepository)
        {
            _technicianRepository = technicianRepository;
        }

        public async Task<string?> UpsertTechnicianAsync(TechnicianEntity technicianObj)
        {
            var para = new DynamicParameters();
            para.Add("@TechnicianId", technicianObj.TechnicianId);
            para.Add("@TechnicianName", technicianObj.TechnicianName);
            para.Add("@TechnicianEmail", technicianObj.TechnicianEmail);
            para.Add("@AscCode", technicianObj.AscCode);
            para.Add("@Mobile", technicianObj.Mobile);
            para.Add("@DivisionCode", technicianObj.DivisionCode);
            para.Add("@ProductLineCode", technicianObj.ProductLineCode);
            para.Add("@SkillId", technicianObj.SkillId);
            para.Add("@PhoneNo", technicianObj.PhoneNo);
            para.Add("@ProductGroupCode", technicianObj.ProductGroupCode);
            para.Add("@IsActive", technicianObj.IsActive);
            para.Add("@UserId", technicianObj.UserId);
            return await _technicianRepository.ExecuteScalarAsync<string?>(TechnicianQueries.UpsertTechnician, para);
        }

        public async Task<string?> DeleteTechnicianAsync(int technicianId, string userId, int isActive)
        {
            var para = new DynamicParameters();
            para.Add("@TechnicianId", technicianId);
            para.Add("@UserId", userId);
            para.Add("@IsActive", isActive);
            return await _technicianRepository.ExecuteScalarAsync<string?>(TechnicianQueries.DeleteTechnician, para);
        }

        public async Task<IList<TechnicianDisplayEntity>> GetAllTechnicianAsync(TechnicianFilter technicianFilter,string? userId)
        {
            var para = new DynamicParameters();
            para.Add("@TechnicianName", technicianFilter.TechnicianName);
            para.Add("@DivisionCode", technicianFilter.DivisionCode);
            para.Add("@AscCode", technicianFilter.AscCode);
            para.Add("@ProductLineCode", technicianFilter.ProductLineCode);
            para.Add("@userId", userId);
            para.Add("@PageSize", technicianFilter.PageSize);
            para.Add("@PageNumber", technicianFilter.PageNumber);
            var lstRegion = await _technicianRepository.GetAllAsync<TechnicianDisplayEntity>(TechnicianQueries.AllTechnician, para);

            return lstRegion.ToList();
        }

        public async Task<TechnicianDisplayEntity?> GetTechnicianByIdAsync(int technicianId)
        {
            var sp_params = new DynamicParameters();
            sp_params.Add("@TechnicianId", technicianId);
            var lstTechnician = await _technicianRepository.GetAsync<TechnicianDisplayEntity>(TechnicianQueries.GetTechnicianById, sp_params);


            TechnicianDisplayEntity ObjTec = new TechnicianDisplayEntity();

            ObjTec.TechnicianId = lstTechnician.TechnicianId;
            ObjTec.TechnicianName = lstTechnician.TechnicianName;
            ObjTec.Mobile = lstTechnician.Mobile;
            ObjTec.TechnicianEmail = lstTechnician.TechnicianEmail;
            ObjTec.DivisionCode = lstTechnician.DivisionCode;
            ObjTec.AscCode = lstTechnician.AscCode;
            ObjTec.ProductGroupCode = lstTechnician.ProductGroupCode;
            ObjTec.PhoneNo = lstTechnician.PhoneNo;
            ObjTec.SkillId = lstTechnician.SkillId;
            ObjTec.IsActive = lstTechnician.IsActive;


            // ------------------------------------Division ----------
            var paraD = new DynamicParameters();
            paraD.Add("@Id", technicianId);
            paraD.Add("@Mode", "1");
            var lstDivTec = await _technicianRepository.GetAllAsync<ParaTypeEntity>(TechnicianQueries.AllTechnicianByProductList, paraD);

            List<ParaTypeEntity> Divisionlist = new List<ParaTypeEntity>();
            ParaTypeEntity ObjDiv = null;
            if (lstDivTec != null)
            {
                foreach (var itemldp in lstDivTec)
                {
                    ObjDiv = new ParaTypeEntity();
                    ObjDiv.ParameterTypeId = itemldp.ParameterTypeId;
                    ObjDiv.ParameterType = itemldp.ParameterType;

                    Divisionlist.Add(ObjDiv);
                }
            }
            // ----------------------------------------- Product Line --------------


            var paraPL = new DynamicParameters();
            paraPL.Add("@Id", technicianId);
            paraPL.Add("@Mode", "3");
            var lstProLineTec = await _technicianRepository.GetAllAsync<ParaTypeEntity>(TechnicianQueries.AllTechnicianByProductList, paraPL);

            List<ParaTypeEntity> ProductLinelist = new List<ParaTypeEntity>();
            ParaTypeEntity ObjPL = null;
            if (lstProLineTec != null)
            {
                foreach (var itemlPL in lstProLineTec)
                {
                    ObjPL = new ParaTypeEntity();
                    ObjPL.ParameterTypeId = itemlPL.ParameterTypeId;
                    ObjPL.ParameterType = itemlPL.ParameterType;

                    ProductLinelist.Add(ObjPL);
                }
            }


            // ----------------------------------------- Product Group --------------

            var paraPG = new DynamicParameters();
            paraPG.Add("@Id", technicianId);
            paraPG.Add("@Mode", "2");
            var lstProGroupTec = await _technicianRepository.GetAllAsync<ParaTypeEntity>(TechnicianQueries.AllTechnicianByProductList, paraPG);

            List<ParaTypeEntity> ProductGrouplist = new List<ParaTypeEntity>();
            ParaTypeEntity ObjPG = null;
            if (lstProGroupTec != null)
            {
                foreach (var itemlPG in lstProGroupTec)
                {
                    ObjPG = new ParaTypeEntity();
                    ObjPG.ParameterTypeId = itemlPG.ParameterTypeId;
                    ObjPG.ParameterType = itemlPG.ParameterType;

                    ProductGrouplist.Add(ObjPG);
                }
            }

            //----------------------------------------------

            var paraSk = new DynamicParameters();
            paraSk.Add("@Id", technicianId);
            paraSk.Add("@Mode", "4");
            var listSk = await _technicianRepository.GetAllAsync<ParaTypeEntity>(TechnicianQueries.AllTechnicianByProductList, paraSk);

            List<ParaTypeEntity> lstSk = new List<ParaTypeEntity>();
            ParaTypeEntity ObjSk = null;
            if (listSk != null)
            {
                foreach (var itemlSK in listSk)
                {
                    ObjSk = new ParaTypeEntity();
                    ObjSk.ParameterTypeId = itemlSK.ParameterTypeId;
                    ObjSk.ParameterType = itemlSK.ParameterType;

                    lstSk.Add(ObjSk);
                }
            }

            ObjTec.ProductGroupCodeList = ProductGrouplist;
            ObjTec.ProductLineCodeList = ProductLinelist;
            ObjTec.DivisionCodeList = Divisionlist;
            ObjTec.SkillList = lstSk;

            return ObjTec;



        }


        public async Task<IList<MasterEntity>> GetTechnicianWishSkillMstByTechnicianIdAsync(MasterFilter userFilter)
        {
            var para = new DynamicParameters();
            para.Add("@TechnicianId", userFilter.Id);

            var lstRegion = await _technicianRepository.GetAllAsync<MasterEntity>(TechnicianQueries.GetTechnicianById, para);
            return lstRegion.ToList();
        }

        public async Task<IList<AscWiseTechnicianEntity>> GetAscWiseTechnicianAsync(string ascCode)
        {
            var para = new DynamicParameters();
            para.Add("@AscCode", ascCode);
            
            var lstTechnician = await _technicianRepository.GetAllAsync<AscWiseTechnicianEntity>(TechnicianQueries.GetAscWiseTechnician, para);
            return lstTechnician.ToList();
        }

    }
}
