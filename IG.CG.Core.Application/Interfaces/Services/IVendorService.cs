using IG.CG.Core.Application.Models;


namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface IVendorService
    {

        Task<IList<VendorDisplayModel>> GetAllVendorAsync(VendorFilter vendorFilter);
        Task<string?> UpsertVendorAsync(VendorModel VendorModel, string? userId);
        Task<VendorDisplayModel> GetVendorByIdAsync(int VendorId);
        Task<string?> DeleteVendorAsync(int VendorId, string? userId, int isActive);

        Task<IList<VendorDisplayModel>> GetAllVendorAsyncByProductAsync(string? DivisionCode, string? ProductLineCode, string? ProductGroupCode);

    }
}
