using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Interfaces.Repository
{
    public interface IDivisionRepository
    {
        Task<IList<DivisionEntity>> GetAllDivisionAsync(DivisionFilter divisionFilter);
        Task<DivisionEntity?> GetDivisionByIdAsync(int divisionId);
        Task<string?> UpsertDivisionAsync(DivisionEntity divisionObj);
        Task<string?> DeleteDivisionAsync(int divisionId, string? userId, int isActive);

        Task<IList<DivisionEntity>> GetAllSAPDivisionAsync(SAPCommonFilter SapFilter);

        Task<IList<ProductTypeEntity>> GetAllProductTypeAsync();
    }
}
