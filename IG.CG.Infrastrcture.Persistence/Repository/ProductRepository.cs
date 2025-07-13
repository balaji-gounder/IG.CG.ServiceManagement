using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Infrastrcture.Persistence.Repository
{

    public class ProductRepository : IProductRepository
    {
        private readonly ISqlDbContext _ProductRepository;
        public ProductRepository(ISqlDbContext productRepository)
        {
            _ProductRepository = productRepository;
        }


        public async Task<string?> UpsertProductAsync(ProductEntity productObj)
        {
            var para = new DynamicParameters();
            para.Add("@ProductId", productObj.ProductId);
            para.Add("@ProductCode", productObj.ProductCode);
            para.Add("@ProductDescription", productObj.ProductDescription);
            para.Add("@ProductGroupCode", productObj.ProductGroupCode);
            para.Add("@ProductLineCode", productObj.ProductLineCode);
            para.Add("@DivisionCode", productObj.DivisionCode);
            para.Add("@ServiceGroupId", productObj.ServiceGroupId);
            para.Add("@HP", productObj.HP);
            para.Add("@FrameSize", productObj.FrameSize);
            para.Add("@RewindingGroup", productObj.RewindingGroup);
            para.Add("@WarrantyFromBatch", productObj.WarrantyFromBatch);
            para.Add("@WarrantyFromDOI", productObj.WarrantyFromDOI);
            para.Add("@IsActive", productObj.IsActive);
            para.Add("@UserId", productObj.UserId);
            para.Add("@VendorId", productObj.VendorId);
            para.Add("@Kilowatt", productObj.Kilowatt);
            para.Add("@AscDays", productObj.AscDays);
            para.Add("@DeviationMonth", productObj.DeviationMonth);
            para.Add("@DeviationUpto", productObj.DeviationUpto);

            return await _ProductRepository.ExecuteScalarAsync<string?>(ProductQueries.UpsertProduct, para);
        }

        public async Task<string?> DeleteProductAsync(int productId, string userId, int isActive)
        {
            var para = new DynamicParameters();
            para.Add("@ProductId", productId);
            para.Add("@UserId", userId);
            para.Add("@IsActive", isActive);
            return await _ProductRepository.ExecuteScalarAsync<string?>(ProductQueries.DeleteProduct, para);
        }

        public async Task<IList<ProductDisplayEntity>> GetAllProductAsync(ProductFilter productFilter)
        {
            var para = new DynamicParameters();
            para.Add("@ProductDescription", productFilter.ProductDescription);
            para.Add("@ProductGroupCode", productFilter.ProductGroupCode);
            para.Add("@ProductLineCode", productFilter.ProductLineCode);
            para.Add("@DivisionCode", productFilter.DivisionCode);
            para.Add("@ServiceGroupId", productFilter.ServiceGroupId);
            para.Add("@ProductCode", productFilter.ProductCode);
            para.Add("@PageSize", productFilter.PageSize);
            para.Add("@PageNumber", productFilter.PageNumber);
            var lstRegion = await _ProductRepository.GetAllAsync<ProductDisplayEntity>(ProductQueries.AllProduct, para);

            return lstRegion.ToList();
        }


        public async Task<IList<ProductDisplayEntity>> GetAllProductListAsync(string? DivisionCode, string? ProductLineCode)
        {
            var para = new DynamicParameters();

            para.Add("@ProductLineCode", ProductLineCode);
            para.Add("@DivisionCode", DivisionCode);

            var lstRegion = await _ProductRepository.GetAllAsync<ProductDisplayEntity>(ProductQueries.ProductSearchGetAll, para);

            return lstRegion.ToList();
        }


        public async Task<ProductDisplayEntity?> GetProductByIdAsync(int productId)
        {
            var sp_params = new DynamicParameters();
            sp_params.Add("@ProductId", productId);
            var lstProduct = await _ProductRepository.GetAsync<ProductDisplayEntity>(ProductQueries.GetProductById, sp_params);

            ProductDisplayEntity ObjPro = null;

            ObjPro = new ProductDisplayEntity();
            ObjPro.ProductId = lstProduct.ProductId;
            ObjPro.ProductCode = lstProduct.ProductCode;
            ObjPro.DivisionCode = lstProduct.DivisionCode;
            ObjPro.ProductLineCode = lstProduct.ProductLineCode;
            ObjPro.ProductGroupCode = lstProduct.ProductGroupCode;
            ObjPro.ProductDescription = lstProduct.ProductDescription;
            ObjPro.ServiceGroupId = lstProduct.ServiceGroupId;
            ObjPro.WarrantyFromBatch = lstProduct.WarrantyFromBatch;
            ObjPro.WarrantyFromDOI = lstProduct.WarrantyFromDOI;
            ObjPro.HP = lstProduct.HP;
            ObjPro.RewindingGroup = lstProduct.RewindingGroup;
            ObjPro.FrameSize = lstProduct.FrameSize;
            ObjPro.IsActive = lstProduct.IsActive;
            ObjPro.VendorId = lstProduct.VendorId;
            ObjPro.Kilowatt = lstProduct.Kilowatt;
            ObjPro.AscDays = lstProduct.AscDays;
            ObjPro.DeviationMonth = lstProduct.DeviationMonth;
            ObjPro.DeviationUpto = lstProduct.DeviationUpto;
            // ------------------------------------Vendor ----------
            var paraD = new DynamicParameters();
            paraD.Add("@ProductCode", lstProduct.ProductCode);

            var lstDivVen = await _ProductRepository.GetAllAsync<ParaTypeEntity>(ProductQueries.AllProductByVendorList, paraD);

            List<ParaTypeEntity> Vendorlist = new List<ParaTypeEntity>();
            ParaTypeEntity ObjDiv = null;
            if (Vendorlist != null)
            {
                foreach (var itemldp in lstDivVen)
                {
                    ObjDiv = new ParaTypeEntity();
                    ObjDiv.ParameterTypeId = itemldp.ParameterTypeId;
                    ObjDiv.ParameterType = itemldp.ParameterType;

                    Vendorlist.Add(ObjDiv);
                }
            }


            ObjPro.VendorList = Vendorlist;
            return ObjPro;

        }


    }
}
