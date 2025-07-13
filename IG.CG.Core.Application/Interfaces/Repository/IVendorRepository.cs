using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Interfaces.Repository
{
    public interface IVendorRepository
    {
        Task<IList<VendorDisplayEntity>> GetAllVendorAsync(VendorFilter vendorFilter);
        Task<VendorDisplayEntity?> GetVendorByIdAsync(int vendorId);
        Task<string?> UpsertVendorAsync(VendorEntity vendorObj);
        Task<string?> DeleteVendorAsync(int vendorId, string? userId, int isActive);

        Task<IList<VendorDisplayEntity>> GetAllVendorAsyncByProductAsync(string? DivisionCode, string? ProductLineCode, string? ProductGroupCode);

    }
}
