using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Interfaces.Repository
{
    public interface IProdCustInfoRepository
    {
        Task<IList<ProdCustInfoDisplayEnitity>> GetAllProdCustInfoAsync(ProdCustInfoFilter prodCustInfoFilter);
        Task<string?> UpsertCustVerificationAsync(CustVerificationEntity CustvObj);
        Task<string?> UpsertProductCustomerInfoAsync(ProductCustomerInfoEntity ProcutinfoObj);
        Task<string?> UpsertProdCustInfoAsync(ProdCustInfoDisplayEnitity ProcutinfoObj);
        Task<ProdSerialNoWarrantySAPDisplayEntity?> GetAllProdSerialNoWarrantyAsync(ProdSerialNoFilter PsrnoFilter);
        Task<ProdCustInfoDisplayEnitity?> GetProdCustInfoByIdAsync(int prodRegAutoId);
        Task<ProductCustomerInfoDisplayEntity> GetProductCustomerDeviationInfoByIdAsync(int prodRegAutoId);
        Task<IList<ProdCustInfoDisplayEnitity>> GetAllProductDeviationAsync(ProductDeviationFilter prodCustInfoFilter);
        Task<IList<ProdCustInfoDisplayEnitity>> GetAllProductCustomerDetailsAsync(ProductDeviationFilter prodCustInfoFilter);
        Task<IList<ProductCustomerInfoDisplayEntity>> GetAllProductCustomeAdminAsync(ProductCustomeAdminFilter prodCustInfoFilter);
        Task<ProdSerialNoWarrantySAPDisplayEntity?> GetAllProdSerialNoWarrantyServiceTicketAsync(ProdSerialNoFilter PsrnoFilter);

        // Product Deviation
        Task<string?> UpsertProdDeviationAsync(ProdDeviationEntity ProdDevObj);

        Task<string?> AddProductCustomerInfoDealer(ProductCustomerInfoDealerEntity objProductCutDeal, string? userId, ProductDealerEntity objProdDeal, string RandomNo, string ServiceTicketNo);

        Task<string?> ServiceTicketNoGetAsync();

        Task<string?> UpsertSMSAsync(SMSDetailsEntity CustvObj);

        Task<string?> UpsertProductCustomerASMInfoAsync(ProductCustomerAMSInfoEntity ProcutinfoObj);

        Task<string?> AddAscTicketCreateInfo(AddAscTicketCreateEntity objProductCutDeal, string? userId, string ServiceTicketNo);


        Task<string?> UpsertProductActivityAsync(ProductUpdateActivityEntity ProcutinfoObj, string? InvoiceFile, string? FIRCopy);

    }
}
