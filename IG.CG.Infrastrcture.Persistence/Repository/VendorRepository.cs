using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class VendorRepository : IVendorRepository
    {
        private readonly ISqlDbContext _vendorRepository;
        public VendorRepository(ISqlDbContext vendorRepository)
        {
            _vendorRepository = vendorRepository;

        }

        public async Task<IList<VendorDisplayEntity>> GetAllVendorAsync(VendorFilter vendorFilter)
        {
            var para = new DynamicParameters();
            para.Add("@VendorName", vendorFilter.VendorName);
            para.Add("@VendorCode", vendorFilter.VendorCode);
            para.Add("@StateId", vendorFilter.StateId);
            para.Add("@PageSize", vendorFilter.PageSize);
            para.Add("@PageNumber", vendorFilter.PageNumber);
            var lstVendor = await _vendorRepository.GetAllAsync<VendorDisplayEntity>(VendorQueries.AllVendor, para);

            return lstVendor.ToList();

        }

        public async Task<string?> UpsertVendorAsync(VendorEntity vendorObj)
        {
            var para = new DynamicParameters();
            para.Add("@VendorId", vendorObj.VendorId);
            para.Add("@VendorCode", vendorObj.VendorCode);
            para.Add("@SAPVendorCode", vendorObj.SAPVendorCode);
            para.Add("@VendorName", vendorObj.VendorName);
            para.Add("@InitialBatch", vendorObj.InitialBatch);
            para.Add("@MobileNo", vendorObj.MobileNo);
            para.Add("@EmailId", vendorObj.EmailId);
            para.Add("@PanNo", vendorObj.PanNo);
            para.Add("@IsGstApplicable", vendorObj.IsGstApplicable);
            para.Add("@GstNo", vendorObj.GstNo);
            para.Add("@IsMSME", vendorObj.IsMSME);
            para.Add("@MsmeCode", vendorObj.MsmeCode);
            para.Add("@VendorAddress", vendorObj.VendorAddress);
            para.Add("@StateId", vendorObj.StateId);
            para.Add("@CityId", vendorObj.CityId);
            para.Add("@PinId", vendorObj.PinId);
            para.Add("@DivisionCode", vendorObj.DivisionCode);
            para.Add("@ProductLineCode", vendorObj.ProductLineCode);
            para.Add("@ProductGroupCode", vendorObj.ProductGroupCode);
            para.Add("@IsActive", vendorObj.IsActive);
            para.Add("@UserId", vendorObj.UserId);
            return await _vendorRepository.ExecuteScalarAsync<string?>(VendorQueries.UpsertVendor, para);
        }


        public async Task<VendorDisplayEntity?> GetVendorByIdAsync(int vendorId)
        {
            var sp_params = new DynamicParameters();
            sp_params.Add("@VendorId", vendorId);

            var lstVendor = await _vendorRepository.GetAsync<VendorDisplayEntity>(VendorQueries.GetVendorById, sp_params);


            VendorDisplayEntity ObjV = null;

            ObjV = new VendorDisplayEntity();
            ObjV.VendorId = lstVendor.VendorId;
            ObjV.VendorCode = lstVendor.VendorCode;
            ObjV.SAPVendorCode = lstVendor.SAPVendorCode;
            ObjV.VendorName = lstVendor.VendorName;
            ObjV.InitialBatch = lstVendor.InitialBatch;

            ObjV.MobileNo = lstVendor.MobileNo;
            ObjV.EmailId = lstVendor.EmailId;
            ObjV.PanNo = lstVendor.PanNo;
            ObjV.IsGstApplicable = lstVendor.IsGstApplicable;
            ObjV.GstNo = lstVendor.GstNo;

            ObjV.IsMSME = lstVendor.IsMSME;
            ObjV.MsmeCode = lstVendor.MsmeCode;
            ObjV.VendorAddress = lstVendor.VendorAddress;
            ObjV.StateId = lstVendor.StateId;
            ObjV.CityId = lstVendor.CityId;
            ObjV.PinId = lstVendor.PinId;

            ObjV.IsActive = lstVendor.IsActive;


            // ------------------------------------Division ----------
            var paraD = new DynamicParameters();
            paraD.Add("@Id", lstVendor.VendorId);
            paraD.Add("@Mode", "1");
            var lstDivVen = await _vendorRepository.GetAllAsync<ParaTypeEntity>(VendorQueries.AllVendorByProductList, paraD);

            List<ParaTypeEntity> Divisionlist = new List<ParaTypeEntity>();
            ParaTypeEntity ObjDiv = null;
            if (lstDivVen != null)
            {
                foreach (var itemldp in lstDivVen)
                {
                    ObjDiv = new ParaTypeEntity();
                    ObjDiv.ParameterTypeId = itemldp.ParameterTypeId;
                    ObjDiv.ParameterType = itemldp.ParameterType;

                    Divisionlist.Add(ObjDiv);
                }
            }
            // ----------------------------------------- Product Line --------------

            var paraPL = new DynamicParameters();
            paraPL.Add("@Id", lstVendor.VendorId);
            paraPL.Add("@Mode", "3");
            var lstProLineVen = await _vendorRepository.GetAllAsync<ParaTypeEntity>(VendorQueries.AllVendorByProductList, paraPL);

            List<ParaTypeEntity> ProductLinelist = new List<ParaTypeEntity>();
            ParaTypeEntity ObjPL = null;
            if (lstProLineVen != null)
            {
                foreach (var itemlPL in lstProLineVen)
                {
                    ObjPL = new ParaTypeEntity();
                    ObjPL.ParameterTypeId = itemlPL.ParameterTypeId;
                    ObjPL.ParameterType = itemlPL.ParameterType;

                    ProductLinelist.Add(ObjPL);
                }
            }

            // ----------------------------------------- Product Group --------------

            var paraPG = new DynamicParameters();
            paraPG.Add("@Id", lstVendor.VendorId);
            paraPG.Add("@Mode", "2");
            var lstProGroupVen = await _vendorRepository.GetAllAsync<ParaTypeEntity>(VendorQueries.AllVendorByProductList, paraPG);

            List<ParaTypeEntity> ProductGrouplist = new List<ParaTypeEntity>();
            ParaTypeEntity ObjPG = null;
            if (lstProGroupVen != null)
            {
                foreach (var itemlPG in lstProGroupVen)
                {
                    ObjPG = new ParaTypeEntity();
                    ObjPG.ParameterTypeId = itemlPG.ParameterTypeId;
                    ObjPG.ParameterType = itemlPG.ParameterType;

                    ProductGrouplist.Add(ObjPG);
                }
            }

            ObjV.ProductGroupCodeList = ProductGrouplist;
            ObjV.ProductLineCodeList = ProductLinelist;

            ObjV.DivisionCodeList = Divisionlist;
            return ObjV;
        }

        public async Task<string?> DeleteVendorAsync(int vendorId, string userId, int isActive)
        {
            var para = new DynamicParameters();
            para.Add("@VendorId", vendorId);
            para.Add("@UserId", userId);
            para.Add("@IsActive", isActive);
            return await _vendorRepository.ExecuteScalarAsync<string?>(VendorQueries.DeleteVendor, para);
        }

        public async Task<IList<VendorDisplayEntity>> GetAllVendorAsyncByProductAsync(string? DivisionCode, string? ProductLineCode, string? ProductGroupCode)
        {
            var para = new DynamicParameters();

            para.Add("@ProductGroupCode", ProductGroupCode);
            para.Add("@ProductLineCode", ProductLineCode);
            para.Add("@DivisionCode", DivisionCode);
            var lstDefectCat = await _vendorRepository.GetAllAsync<VendorDisplayEntity>(VendorQueries.AllVendorByProduct, para);

            return lstDefectCat.ToList();
        }
    }
}
