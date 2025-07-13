
using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;

namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface IActivityService
    {
        Task<int?> UpsertActivityAsync(List<ActivityModel> lstActivityModel, string? userId);
        Task<IList<ActivityDisplayModel>> GetAllActivityAsync(ActivityFilter activityFilter);
        Task<ActivityModel> GetActivityByIdAsync(int activityId);
        Task<string?> DeleteActivityAsync(int activityId, string? userId, int isActive);
        Task<IList<ActivityDisplayModel>> GetActivityByTypeAsync(string? ProductLineCode, string? DivisionCode, string? SubStatusid, string? StatusId, string? ActivityTypeId, string? ServiceTicketId);
        Task<IList<TypeOfWorkDoneModel>> GetAllTypeOfWorkDoneAsync(int serviceTicketId, string FrameSizeType, string KVAType);

        Task<IList<ActivityDisplayModel>> GetActivitymstAsync(string? DivisionCode, string? ActivityTypeId);


    }
}
