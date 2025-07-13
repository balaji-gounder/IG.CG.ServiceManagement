using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;

namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface IParaValService
    {
        Task<IList<ParaValDispModel>> GetAllParaValAsync(ParaValFilter paraValFilter);
        Task<IList<ParaValModel>> GetParaValByIdAsync(int paraValId);
        Task<string?> UpsertParaValAsync(int? ParameterTypeId, List<ParaValModel> paraValModel, string? userId);
        Task<int?> DeleteParaValAsync(int paraValId, string? userId, int isActive);
        Task<IList<ParaValModel>> GetAllParaByTypeAsync(string paraType);
        Task<IList<ParaTypeModel>> GetAllParaTypeAsync(int mode);

    }
}
