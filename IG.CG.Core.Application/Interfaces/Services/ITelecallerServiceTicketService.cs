using IG.CG.Core.Application.Models;

namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface ITelecallerServiceTicketService
    {
        Task<ProductCustomerInfoDisplayModel?> GetAllProdSerialNoAsync(string? SerialNo, string? ProductCode);
        Task<string?> UpsertProductCustomerInfoAsync(ProductCustomerInfoModel ProcutinfoObj, string? userId, string DocumentPath);
        Task<IList<ProdCustInfoDisplayModel>> GetAllProdCustInfoAsync(string? MobileNo);

        Task<ProdSerialNoWarrantySAPDisplayModel?> GetAllProdSerialNoWarrantyServiceTicketAsync(ProdSerialNoFilter PsrnoFilter);
        Task<ProdSerialNoWarrantySAPDisplayModel?> GetAllProdSerialNoWarrantyServiceTicketTelecallerAsync(ProdSerialNoTelecallerFilter PsrnoFilter);

        Task<string?> UpsertProductTelecallerInfoAsync(ProductCustomerInfoModel ProcutinfoObj, string? userId, string DocumentPath);

    }
}
