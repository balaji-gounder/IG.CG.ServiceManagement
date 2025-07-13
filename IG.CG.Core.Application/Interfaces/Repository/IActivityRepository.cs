using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Interfaces.Repository
{
    public interface IActivityRepository
    {
        Task<int?> UpsertActivityAsync(ActivityEntity activityObj, string? userId);
        Task<IList<ActivityDisplayEntity>> GetAllActivityAsync(ActivityFilter activityFilter);
        Task<ActivityEntity?> GetActivityByIdAsync(int activityId);
        Task<string?> DeleteActivityAsync(int activityId, string? userId, int isActive);
        Task<IList<ActivityDisplayEntity>> GetActivityByTypeAsync(string? ProductLineCode, string? DivisionCode, string? SubStatusid, string? StatusId, string? ActivityTypeId, string? ServiceTicketId);
        Task<IList<TypeOfWorkDoneEntity>> GetAllTypeOfWorkDoneAsync(int serviceTicketId, string FrameSizeType, string KVAType);

        Task<IList<ActivityDisplayEntity>> GetActivitymstAsync(string? DivisionCode, string? ActivityTypeId);
    }
}
