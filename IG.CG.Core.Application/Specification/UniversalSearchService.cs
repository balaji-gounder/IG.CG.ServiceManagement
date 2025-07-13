using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Specification
{
    public class UniversalSearchService : IUniversalSearchService
    {
        private readonly IMapper _mapper;
        private readonly IUniversalSearchRepository _universalSearchRepository;

        public UniversalSearchService(IMapper mapper, IUniversalSearchRepository universalSearchRepository)
        {
            _mapper = mapper;
            _universalSearchRepository = universalSearchRepository;
        }

        public async Task<IList<UniversalSearchModel>> GetUniversalSearchAsync (UniversalSearchFilter universalSearchFilter)
        {
            var universal = await _universalSearchRepository.GetUniversalSearchAsync(universalSearchFilter);
            var UniversalSearchModel = _mapper.Map<List<UniversalSearchModel>>(universal.ToList());
            return UniversalSearchModel;
        }
    }
}
