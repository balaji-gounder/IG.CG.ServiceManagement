using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Specification
{
    public class ParaValService : IParaValService
    {
        private readonly IMapper _mapper;
        private readonly IParaValRepository _paraValRepository;
        public ParaValService(IMapper mapper, IParaValRepository paraValRepository)
        {
            _mapper = mapper;
            _paraValRepository = paraValRepository;
        }
        public async Task<int?> DeleteParaValAsync(int paraValId, string? userId, int isActive)
        {
            return await _paraValRepository.DeleteParaValAsync(paraValId, userId, isActive);
        }

        public async Task<IList<ParaValDispModel>> GetAllParaValAsync(ParaValFilter paraValFilter)
        {
            var paraVal = await _paraValRepository.GetAllParaValAsync(paraValFilter);
            var paraValModel = _mapper.Map<List<ParaValDispModel>>(paraVal.ToList());
            return paraValModel;
        }

        public async Task<IList<ParaValModel>> GetParaValByIdAsync(int paraValId)
        {
            var paraVal = await _paraValRepository.GetParaValByIdAsync(paraValId);
            var paraModel = _mapper.Map<List<ParaValModel>>(paraVal);
            return paraModel;
        }

        public async Task<string?> UpsertParaValAsync(int? ParameterTypeId, List<ParaValModel> paraValModel, string? userId)
        {
            string? result = null;

            var lstparaValModel = _mapper.Map<List<ParaValEntity>>(paraValModel);

            await _paraValRepository.DeleteParaTypeParaVal(ParameterTypeId);

            foreach (var paraVal in lstparaValModel)
            {
                result = await _paraValRepository.UpsertParaValAsync(ParameterTypeId, userId, paraVal);
            }

            return result;

        }
        public async Task<IList<ParaValModel>> GetAllParaByTypeAsync(string paraType)
        {
            var paraVal = await _paraValRepository.GetAllParaByTypeAsync(paraType);
            var paraValModel = _mapper.Map<List<ParaValModel>>(paraVal?.ToList());
            return paraValModel;
        }

        public async Task<IList<ParaTypeModel>> GetAllParaTypeAsync(int mode)
        {
            var paraType = await _paraValRepository.GetAllParaTypeAsync(mode);
            var paraTypeModel = _mapper.Map<List<ParaTypeModel>>(paraType?.ToList());
            return paraTypeModel;
        }
    }
}
