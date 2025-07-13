using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Interfaces.Repository
{
    public interface ICommonRepository
    {
        Task<IList<ParaTypeEntity>> GetAllCommonAsync(int Mode, int Id, string Code);

        Task<IList<ParaTypeEntity>> GetAllActivityStatusAsync(int ServiceTicketId, int ActivityType, string DivisionCode);
        Task<IList<ParaTypeEntity>> GetAllActivitySubStatusAsync(int ServiceTicketId, int ActivityStatusId);
        Task<IList<ParaTypeEntity>> GetAllClaimDeviationAsync(int ServiceTicketId, string DivisionCode);

        Task<IList<ProductLineFrontEntity>> GetAllProductLineFrontAsync(int? ProductLineFrontId);
    }
}
