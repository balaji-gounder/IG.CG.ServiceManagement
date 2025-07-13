using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;


namespace IG.CG.Core.Application.Interfaces.Repository
{
    public interface IDefectRepository
    {
        Task<IList<DefectDisplayEntity>> GetAllDefectAsync(DefectFilter defectFilter);
        Task<DefectEntity?> GetDefectByIdAsync(int defectId);
        Task<string?> UpsertDefectAsync(DefectEntity defectObj);
        Task<string?> DeleteDefectAsync(int defectId, string? userId, int isActive);

        Task<IList<DefectDisplayEntity>> GetAllDefectByProductLineAsync(string? ProductLineCode);

    }
}
