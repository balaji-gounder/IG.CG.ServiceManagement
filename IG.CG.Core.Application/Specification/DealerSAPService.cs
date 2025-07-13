using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;

namespace IG.CG.Core.Application.Specification
{
    public class DealerSAPService : IDealerSAPService
    {
        private readonly IMapper _mapper;
        private readonly IDealerSAPRepository _dealerSAPRepository;

        public DealerSAPService(IMapper mapper, IDealerSAPRepository dealerSAPRepository)
        {
            this._mapper = mapper;
            this._dealerSAPRepository = dealerSAPRepository;
        }

        public async Task<IList<DealerSAPModel>> GetAllDealerSAPAsync(DealerSAPFilter dealerFilter)
        {
            var dealer = await _dealerSAPRepository.GetAllDealerSAPAsync(dealerFilter);
            var dealerModel = _mapper.Map<List<DealerSAPModel>>(dealer.ToList());
            return dealerModel;
        }
    }
}
