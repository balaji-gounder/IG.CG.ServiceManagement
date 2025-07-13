using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Interfaces.Repository
{
    public interface ISAPRepository
    {
        Task<IList<SAPDataEnitity>> GetAllSAPAsync(SAPCommonFilter SapFilter);
    }
}
