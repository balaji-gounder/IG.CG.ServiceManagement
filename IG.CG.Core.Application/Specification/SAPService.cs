using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;

namespace IG.CG.Core.Application.Specification
{
    public class SAPService : ISAPService
    {
        private readonly IMapper _mapper;
        private readonly ISAPRepository _sapRepository;
        public SAPService(IMapper mapper, ISAPRepository sapRepository)
        {
            _mapper = mapper;
            _sapRepository = sapRepository;

        }

        public async Task<IList<SAPDataModel>> GetAllSAPAsync(SAPCommonFilter SapFilter)
        {
            var sapData = await _sapRepository.GetAllSAPAsync(SapFilter);
            var sapModel = _mapper.Map<List<SAPDataModel>>(sapData.ToList());
            return sapModel;
        }


    }
}
