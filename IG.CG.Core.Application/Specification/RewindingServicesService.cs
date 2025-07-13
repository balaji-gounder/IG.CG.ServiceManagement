
using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Application.Models;

namespace IG.CG.Core.Application.Specification
{
    public class RewindingServicesService : IRewindingServicesService
    {
        private readonly IMapper _mapper;
        private readonly IRewindingServicesRepository _rewindingServicesRepository;
        public RewindingServicesService(IMapper mapper, IRewindingServicesRepository rewindingServicesRepository)
        {
            _mapper = mapper;
            _rewindingServicesRepository = rewindingServicesRepository;

        }

        public async Task<IList<RewindingServicesDisplayModel>> GetAllRewindingServicesAsync(RewindingServicesFilter rewindingServicesFilter)
        {
            var rewindingServices = await _rewindingServicesRepository.GetAllRewindingServicesAsync(rewindingServicesFilter);
            var rewindingServicesModel = _mapper.Map<List<RewindingServicesDisplayModel>>(rewindingServices.ToList());
            return rewindingServicesModel;
        }

    }
}
