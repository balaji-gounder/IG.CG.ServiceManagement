using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Specification
{
    public class DivisionService : IDivisionService
    {
        private readonly IMapper _mapper;
        private readonly IDivisionRepository _divisionRepository;
        public DivisionService(IMapper mapper, IDivisionRepository divisionRepository)
        {
            _mapper = mapper;
            _divisionRepository = divisionRepository;

        }
        public async Task<IList<DivisionModel>> GetAllDivisionAsync(DivisionFilter divisionFilter)
        {
            var division = await _divisionRepository.GetAllDivisionAsync(divisionFilter);
            var divisionModel = _mapper.Map<List<DivisionModel>>(division.ToList());
            return divisionModel;
        }


        public async Task<DivisionModel> GetDivisionByIdAsync(int divisionId)
        {
            var division = await _divisionRepository.GetDivisionByIdAsync(divisionId);
            var divisionModel = _mapper.Map<DivisionModel>(division);
            return divisionModel;
        }

        public async Task<string?> UpsertDivisionAsync(DivisionModel divisionModel, string? userId)
        {
            DivisionEntity divisionObj = _mapper.Map<DivisionEntity>(divisionModel);
            divisionObj.UserId = userId;
            return await _divisionRepository.UpsertDivisionAsync(divisionObj);
        }
        public async Task<string?> DeleteDivisionAsync(int divisionId, string? userId, int isActive)
        {
            return await _divisionRepository.DeleteDivisionAsync(divisionId, userId, isActive);
        }

        public async Task<IList<DivisionModel>> GetAllSAPDivisionAsync(SAPCommonFilter SapFilter)
        {
            var division = await _divisionRepository.GetAllSAPDivisionAsync(SapFilter);
            var divisionModel = _mapper.Map<List<DivisionModel>>(division.ToList());
            return divisionModel;
        }


        public async Task<IList<ProductTypeModel>> GetAllProductTypeAsync()
        {
            var division = await _divisionRepository.GetAllProductTypeAsync();
            var divisionModel = _mapper.Map<List<ProductTypeModel>>(division.ToList());
            return divisionModel;
        }
    }
}
