using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Specification
{
    public class DefectCategoryService : IDefectCategoryService
    {
        private readonly IMapper _mapper;
        private readonly IDefectCategoryRepository _defectCategoryRepository;
        public DefectCategoryService(IMapper mapper, IDefectCategoryRepository defectCategoryRepository)
        {
            _mapper = mapper;
            _defectCategoryRepository = defectCategoryRepository;

        }

        public async Task<IList<DefectCatDispModel>> GetAllDefectCategoryAsync(DefectCategoryFilter defectCategoryFilter)
        {
            var defectCategory = await _defectCategoryRepository.GetAllDefectCategoryAsync(defectCategoryFilter);
            var defectCategoryModel = _mapper.Map<List<DefectCatDispModel>>(defectCategory.ToList());
            return defectCategoryModel;
        }

        public async Task<DefectCategoryModel> GetDefectCategoryByIdAsync(int defectCategoryId)
        {
            var defectCategory = await _defectCategoryRepository.GetDefectCategoryByIdAsync(defectCategoryId);
            var defectCategoryModel = _mapper.Map<DefectCategoryModel>(defectCategory);
            return defectCategoryModel;
        }



        public async Task<string?> UpsertDefectCategoryAsync(DefectCategoryModel defectCategoryModel, string? userId)
        {
            DefectCategoryEntity defectCategoryObj = _mapper.Map<DefectCategoryEntity>(defectCategoryModel);
            defectCategoryObj.UserId = userId;
            return await _defectCategoryRepository.UpsertDefectCategoryAsync(defectCategoryObj);
        }
        public async Task<string?> DeleteDefectCategoryAsync(int defectCategoryId, string? userId, int isActive)
        {
            return await _defectCategoryRepository.DeleteDefectCategoryAsync(defectCategoryId, userId, isActive);
        }


        public async Task<IList<DefectCatDispModel>> GetAllDefectCategoryByProductAsync(string? DivisionCode, string? ProductLineCode, string? ProductGroupCode)
        {
            var defectCategory = await _defectCategoryRepository.GetAllDefectCategoryByProductAsync(DivisionCode, ProductLineCode, ProductGroupCode);
            var defectCategoryModel = _mapper.Map<List<DefectCatDispModel>>(defectCategory.ToList());
            return defectCategoryModel;
        }
    }
}
