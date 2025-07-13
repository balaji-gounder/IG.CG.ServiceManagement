using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Interfaces.Repository
{
    public interface IClosureTATBranchWiseRepository
    {
        Task<IList<ClosureTATBranchWiseEntity>> GetClosureTATBranchWiseReportAsync(ClosureTATBranchWiseFilter ClosureTATBranchWiseFilter);

        Task<IList<ClosureTATBranchWiseEntity>> GetFIRClosureTATBranchWiseReportAsync(ClosureTATBranchWiseFilter ClosureTATBranchWiseFilter);
    }
}
