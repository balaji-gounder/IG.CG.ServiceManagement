using IG.CG.Core.Application.Models;

namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface IClosureTATBranchWiseService
    {
        Task<IList<ClosureTATBranchWiseModel>> GetClosureTATBranchWiseReportAsync(ClosureTATBranchWiseFilter ClosureTATBranchWiseFilter);

        Task<IList<ClosureTATBranchWiseModel>> GetFIRClosureTATBranchWiseReportAsync(ClosureTATBranchWiseFilter ClosureTATBranchWiseFilter);


    }
}
