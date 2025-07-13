
using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Entities;


namespace IG.CG.Core.Application.Interfaces.Repository
{
    public interface IParaValRepository
    {
        Task<IList<ParaValDispEntity>> GetAllParaValAsync(ParaValFilter paraValFilter);
        Task<IList<ParaValEntity>> GetParaValByIdAsync(int ParameterValId);
        Task<string?> UpsertParaValAsync(int? ParameterTypeId, string? userId, ParaValEntity paraValObj);
        Task<int?> DeleteParaValAsync(int ParameterValId, string? userId, int isActive);
        Task<IList<ParaValEntity>?> GetAllParaByTypeAsync(string paraType);
        Task<IList<ParaTypeEntity>> GetAllParaTypeAsync(int mode);

        Task<string?> DeleteParaTypeParaVal(int? ParameterTypeId);
    }
}
