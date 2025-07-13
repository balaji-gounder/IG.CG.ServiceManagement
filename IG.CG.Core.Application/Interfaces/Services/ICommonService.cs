using IG.CG.Core.Application.Models;

namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface ICommonService
    {
        Task<IList<ParaTypeModel>> GetAllCommonAsync(int Mode, int Id, string Code);

        Task<IList<ParaTypeModel>> GetAllActivityStatusAsync(int ServiceTicketId, int ActivityType, string DivisionCode);

        Task<IList<ParaTypeModel>> GetAllActivitySubStatusAsync(int ServiceTicketId, int ActivityStatusId);

        Task<IList<ParaTypeModel>> GetAllClaimDeviationAsync(int ServiceTicketId, string DivisionCode);

        Task<IList<ProductLineFrontModel>> GetAllProductLineFrontAsync(int? ProductLineFrontId);
    }
}
