using IG.CG.Core.Application.Models;

namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface IProdCustInfoService
    {
        Task<IList<ProdCustInfoDisplayModel>> GetAllProdCustInfoAsync(ProdCustInfoFilter prodCustInfoFilter);
        Task<string?> UpsertCustVerificationAsync(CustVerificationModel CustvObj);
        Task<string?> UpsertProductCustomerInfoAsync(ProductCustomerInfoModel ProcutinfoObj, string? userId, string DocumentPath);

        Task<string?> UpsertProdCustInfoAsync(ProdCustInfoDisplayModel ProcutinfoObj);
        Task<ProdSerialNoWarrantySAPDisplayModel> GetAllProdSerialNoWarrantyAsync(ProdSerialNoFilter PsrnoFilter);
        Task<ProdCustInfoDisplayModel> GetProdCustInfoByIdAsync(int prodRegAutoId);
        Task<ProductCustomerInfoDisplayModel> GetProductCustomerDeviationInfoByIdAsync(int prodRegAutoId);
        Task<IList<ProdCustInfoDisplayModel>> GetAllProductDeviationAsync(ProductDeviationFilter prodCustInfoFilter);

        Task<IList<ProdCustInfoDisplayModel>> GetAllProductCustomerDetailsAsync(ProductDeviationFilter prodCustInfoFilter);


        Task<IList<ProductCustomerInfoDisplayModel>> GetAllProductCustomeAdminAsync(ProductCustomeAdminFilter prodCustInfoFilter);
        Task<ProdSerialNoWarrantySAPDisplayModel?> GetAllProdSerialNoWarrantyServiceTicketAsync(ProdSerialNoFilter PsrnoFilter);

        // Product Deviation
        Task<string?> UpsertProdDeviationAsync(ProdDeviationModel ProdDevObj, string? UserId);
        Task<string?> AddProductCustomerInfoDealer(ProductCustomerInfoDealerModel objProductCutDeal, string? userId, List<ProductDealerModel> lstProductDeal);
        Task<string?> UpsertSMSAsync(SMSDetailsModel CustvObj);

        Task<string?> UpsertProductCustomerASMInfoAsync(ProductCustomerAMSInfoModel ProcutinfoObj);
        Task<string?> AddAscTicketCreateInfo(List<AddAscTicketCreateModel> objProductCutDeal, string? userId);

        Task<string?> UpsertProductActivityAsync(ProductUpdateActivityModel ProcutinfoObj);

    }
}
