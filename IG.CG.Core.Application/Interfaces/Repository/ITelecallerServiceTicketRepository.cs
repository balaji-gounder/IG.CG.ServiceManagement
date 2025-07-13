using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Interfaces.Repository
{
    public interface ITelecallerServiceTicketRepository
    {
        Task<ProductCustomerInfoDisplayEntity?> GetAllProdSerialNoAsync(string? SerialNo, string? ProductCode);
        Task<string?> UpsertProductCustomerInfoAsync(ProductCustomerInfoEntity ProcutinfoObj);
        Task<IList<ProdCustInfoDisplayEnitity>> GetAllProdCustInfoAsync(string? MobileNo);

        Task<ProdSerialNoWarrantySAPDisplayEntity?> GetAllProdSerialNoWarrantyServiceTicketAsync(ProdSerialNoFilter PsrnoFilter);

        Task<ProdSerialNoWarrantySAPDisplayEntity?> GetAllProdSerialNoWarrantyServiceTicketTelecallerAsync(ProdSerialNoTelecallerFilter PsrnoFilter);


        Task<string?> UpsertProductTelecallerInfoAsync(ProductCustomerInfoEntity ProcutinfoObj);

    }
}
