using IG.CG.Core.Application.Models;

namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface IDivisionService
    {
        Task<IList<DivisionModel>> GetAllDivisionAsync(DivisionFilter divisionFilter);
        Task<DivisionModel> GetDivisionByIdAsync(int divisionhId);
        Task<string?> UpsertDivisionAsync(DivisionModel divisionModel, string? userId);
        Task<string?> DeleteDivisionAsync(int divisionId, string? userId, int isActive);

        Task<IList<DivisionModel>> GetAllSAPDivisionAsync(SAPCommonFilter SapFilter);

        Task<IList<ProductTypeModel>> GetAllProductTypeAsync();
    }
}
