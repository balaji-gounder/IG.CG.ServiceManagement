using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;

namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface IDefectCategoryService
    {
        Task<IList<DefectCatDispModel>> GetAllDefectCategoryAsync(DefectCategoryFilter defectCategoryFilter);
        Task<DefectCategoryModel> GetDefectCategoryByIdAsync(int defectCategoryId);
        Task<string?> UpsertDefectCategoryAsync(DefectCategoryModel defectCategoryModel, string? userId);
        Task<string?> DeleteDefectCategoryAsync(int defectCategoryId, string? userId, int isActive);

        Task<IList<DefectCatDispModel>> GetAllDefectCategoryByProductAsync(string? DivisionCode, string? ProductLineCode, string? ProductGroupCode);

    }
}
