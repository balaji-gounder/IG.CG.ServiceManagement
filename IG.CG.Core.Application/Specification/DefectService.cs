using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Specification
{
    public class DefectService : IDefectService
    {
        private readonly IMapper _mapper;
        private readonly IDefectRepository _defectRepository;
        public DefectService(IMapper mapper, IDefectRepository defectRepository)
        {
            _mapper = mapper;
            _defectRepository = defectRepository;

        }

        public async Task<IList<DefectDisplayModel>> GetAllDefectAsync(DefectFilter defectFilter)
        {
            var defect = await _defectRepository.GetAllDefectAsync(defectFilter);
            var defectModel = _mapper.Map<List<DefectDisplayModel>>(defect.ToList());
            return defectModel;
        }

        public async Task<DefectModel> GetDefectByIdAsync(int defectId)
        {
            var defect = await _defectRepository.GetDefectByIdAsync(defectId);
            var defectModel = _mapper.Map<DefectModel>(defect);
            return defectModel;
        }

        public async Task<string?> UpsertDefectAsync(DefectModel defectModel, string? userId)
        {
            DefectEntity defectObj = _mapper.Map<DefectEntity>(defectModel);
            defectObj.UserId = userId;
            return await _defectRepository.UpsertDefectAsync(defectObj);
        }
        public async Task<string?> DeleteDefectAsync(int defectId, string? userId, int isActive)
        {
            return await _defectRepository.DeleteDefectAsync(defectId, userId, isActive);
        }
        public async Task<IList<DefectDisplayModel>> GetAllDefectByProductLineAsync(string? ProductLineCode)
        {
            var defect = await _defectRepository.GetAllDefectByProductLineAsync(ProductLineCode);
            var defectModel = _mapper.Map<List<DefectDisplayModel>>(defect.ToList());
            return defectModel;
        }

    }
}
