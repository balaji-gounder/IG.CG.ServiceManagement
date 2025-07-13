using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;

namespace IG.CG.Core.Application.Specification
{
    public class ClosureTATBranchWiseService : IClosureTATBranchWiseService
    {
        private readonly IMapper _mapper;
        private readonly IClosureTATBranchWiseRepository _closureRepository;

        public ClosureTATBranchWiseService(IMapper mapper, IClosureTATBranchWiseRepository ClosureRepository)
        {
            _mapper = mapper;
            _closureRepository = ClosureRepository;
        }
        public async Task<IList<ClosureTATBranchWiseModel>> GetClosureTATBranchWiseReportAsync(ClosureTATBranchWiseFilter ClosureTATBranchWiseFilter)
        {
            var ClosureTATBranch = await _closureRepository.GetClosureTATBranchWiseReportAsync(ClosureTATBranchWiseFilter);
            var ClosureTATBranchModel = _mapper.Map<List<ClosureTATBranchWiseModel>>(ClosureTATBranch.ToList());
            return ClosureTATBranchModel;
        }


        public async Task<IList<ClosureTATBranchWiseModel>> GetFIRClosureTATBranchWiseReportAsync(ClosureTATBranchWiseFilter ClosureTATBranchWiseFilter)
        {
            var ClosureTATBranch = await _closureRepository.GetFIRClosureTATBranchWiseReportAsync(ClosureTATBranchWiseFilter);
            var ClosureTATBranchModel = _mapper.Map<List<ClosureTATBranchWiseModel>>(ClosureTATBranch.ToList());
            return ClosureTATBranchModel;
        }
    }
}
