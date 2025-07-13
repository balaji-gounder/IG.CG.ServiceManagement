using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Interfaces.Repository
{
    public interface IDefectCategoryRepository
    {
        Task<IList<DefectCatDispEntity>> GetAllDefectCategoryAsync(DefectCategoryFilter DefectCategoryFilter);
        Task<DefectCategoryEntity?> GetDefectCategoryByIdAsync(int DefectCategoryId);
        Task<string?> UpsertDefectCategoryAsync(DefectCategoryEntity DefectCategoryObj);
        Task<string?> DeleteDefectCategoryAsync(int DefectCategoryId, string? userId, int isActive);

        Task<IList<DefectCatDispEntity>> GetAllDefectCategoryByProductAsync(string? DivisionCode, string? ProductLineCode, string? ProductGroupCode);

    }
}
