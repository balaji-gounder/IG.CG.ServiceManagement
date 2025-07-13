using IG.CG.Core.Application.Models;

namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface IDefectService
    {
        Task<IList<DefectDisplayModel>> GetAllDefectAsync(DefectFilter defectFilter);
        Task<DefectModel> GetDefectByIdAsync(int defectId);
        Task<string?> UpsertDefectAsync(DefectModel defectModel, string? userId);
        Task<string?> DeleteDefectAsync(int defectId, string? userId, int isActive);

        Task<IList<DefectDisplayModel>> GetAllDefectByProductLineAsync(string? ProductLineCode);

    }
}
