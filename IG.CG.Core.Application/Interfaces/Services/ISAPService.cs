using IG.CG.Core.Application.Models;

namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface ISAPService
    {
        Task<IList<SAPDataModel>> GetAllSAPAsync(SAPCommonFilter SapFilter);
    }
}
