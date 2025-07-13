using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly ISqlDbContext _activityRepository;
        public ActivityRepository(ISqlDbContext activityRepository)
        {
            _activityRepository = activityRepository;
        }


        public async Task<int?> UpsertActivityAsync(ActivityEntity activity, string? userId)
        {
            var para = new DynamicParameters();
            para.Add("@ActivityId", activity.ActivityId);
            para.Add("@DivisionCode", activity.DivisionCode);
            para.Add("@ProductLineCode", activity.ProductLineCode);
            para.Add("@ActivityTypeId", activity.ActivityTypeId);
            para.Add("@ActivityName", activity.ActivityName);
            para.Add("@IsActive", activity.IsActive);
            para.Add("@UserId", userId);
            var result = await _activityRepository.ExecuteScalarAsync<int?>(ActivityQueries.ActivityInsertUpdate, para);
            return result;
        }

        public async Task<IList<ActivityDisplayEntity>> GetAllActivityAsync(ActivityFilter activityFilter)
        {
            var para = new DynamicParameters();
            para.Add("@DivisionCode", activityFilter.DivisionCode);
            para.Add("@ProductLineCode", activityFilter.ProductLineCode);
            para.Add("@ActivityTypeId", activityFilter.ActivityTypeId);

            para.Add("@PageSize", activityFilter.PageSize);
            para.Add("@PageNumber", activityFilter.PageNumber);
            var lstActivity = await _activityRepository.GetAllAsync<ActivityDisplayEntity>(ActivityQueries.AllActivity, para);

            return lstActivity.ToList();
        }

        public async Task<ActivityEntity?> GetActivityByIdAsync(int activityId)
        {
            var para = new DynamicParameters();
            para.Add("@ActivityId", activityId);
            return await _activityRepository.GetAsync<ActivityEntity>(ActivityQueries.GetActivityById, para);
        }

        public async Task<string?> DeleteActivityAsync(int activityId, string userId, int isActive)
        {
            var para = new DynamicParameters();
            para.Add("@ActivityId", activityId);
            para.Add("@UserId", userId);
            para.Add("@IsActive", isActive);
            return await _activityRepository.ExecuteScalarAsync<string?>(ActivityQueries.DeleteActivity, para);
        }

        public async Task<IList<ActivityDisplayEntity>> GetActivityByTypeAsync(string? ProductLineCode, string? DivisionCode, string? SubStatusid, string? StatusId, string? ActivityTypeId, string? ServiceTicketId)
        {
            var para = new DynamicParameters();
            para.Add("@ProductLineCode", ProductLineCode);
            para.Add("@DivisionCode", DivisionCode);
            para.Add("@SubStatusid", SubStatusid);
            para.Add("@StatuId", StatusId);
            para.Add("@ActivityTypeId", ActivityTypeId);
            para.Add("@ServiceTicketId", ServiceTicketId);
            var lstActivity = await _activityRepository.GetAllAsync<ActivityDisplayEntity>(ActivityQueries.GetActivityByType, para);

            return lstActivity.ToList();
        }


        public async Task<IList<ActivityDisplayEntity>> GetActivitymstAsync(string? DivisionCode, string? ActivityTypeId)
        {
            var para = new DynamicParameters();

            para.Add("@DivisionCode", DivisionCode);
            para.Add("@ActivityTypeId", ActivityTypeId);
            var lstActivity = await _activityRepository.GetAllAsync<ActivityDisplayEntity>(ActivityQueries.AllActivityByTypemstGet, para);

            return lstActivity.ToList();
        }






        public async Task<IList<TypeOfWorkDoneEntity>> GetAllTypeOfWorkDoneAsync(int serviceTicketId, string FrameSizeType, string KVAType)
        {
            var para = new DynamicParameters();
            para.Add("@ServiceTicketId", serviceTicketId);
            para.Add("@KVAType", KVAType);
            para.Add("@FrameSizeType", FrameSizeType);
            var lstTypeOfWorkDone = await _activityRepository.GetAllAsync<TypeOfWorkDoneEntity>(ActivityQueries.AllTypeOfWorkDone, para);

            return lstTypeOfWorkDone.ToList();
        }

    }
}
