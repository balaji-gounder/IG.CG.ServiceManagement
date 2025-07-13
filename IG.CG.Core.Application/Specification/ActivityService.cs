using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Specification
{
    public class ActivityService : IActivityService
    {

        private readonly IMapper _mapper;
        private readonly IActivityRepository _activityRepository;
        public ActivityService(IMapper mapper, IActivityRepository activityRepository)
        {
            _mapper = mapper;
            _activityRepository = activityRepository;

        }

        public async Task<int?> UpsertActivityAsync(List<ActivityModel> lstActivity, string? userId)
        {
            int? result = null;
            var activityEntity = _mapper.Map<List<ActivityEntity>>(lstActivity);

            foreach (var activity in activityEntity)
            {
                result = await _activityRepository.UpsertActivityAsync(activity, userId);
            }
            return result;
        }

        public async Task<IList<ActivityDisplayModel>> GetAllActivityAsync(ActivityFilter activityFilter)
        {
            var activity = await _activityRepository.GetAllActivityAsync(activityFilter);
            var activityModel = _mapper.Map<List<ActivityDisplayModel>>(activity.ToList());
            return activityModel;
        }

        public async Task<ActivityModel> GetActivityByIdAsync(int activityId)
        {
            var activity = await _activityRepository.GetActivityByIdAsync(activityId);
            var activityModel = _mapper.Map<ActivityModel>(activity);
            return activityModel;
        }
        public async Task<string?> DeleteActivityAsync(int activityId, string? userId, int isActive)
        {
            return await _activityRepository.DeleteActivityAsync(activityId, userId, isActive);
        }

        public async Task<IList<ActivityDisplayModel>> GetActivityByTypeAsync(string? ProductLineCode, string? DivisionCode, string? SubStatusid, string? StatusId, string? ActivityTypeId,string? ServiceTicketId)
        {
            var activity = await _activityRepository.GetActivityByTypeAsync(ProductLineCode, DivisionCode, SubStatusid, StatusId, ActivityTypeId, ServiceTicketId);
            var activityModel = _mapper.Map<List<ActivityDisplayModel>>(activity.ToList());
            return activityModel;
        }


        public async Task<IList<ActivityDisplayModel>> GetActivitymstAsync(string? DivisionCode, string? ActivityTypeId)
        {
            var activity = await _activityRepository.GetActivitymstAsync(DivisionCode, ActivityTypeId);
            var activityModel = _mapper.Map<List<ActivityDisplayModel>>(activity.ToList());
            return activityModel;
        }



        public async Task<IList<TypeOfWorkDoneModel>> GetAllTypeOfWorkDoneAsync(int serviceTicketId, string FrameSizeType, string KVAType)
        {
            var TypeOfWorkDone = await _activityRepository.GetAllTypeOfWorkDoneAsync(serviceTicketId, FrameSizeType, KVAType);
            var TypeOfWorkDoneModel = _mapper.Map<List<TypeOfWorkDoneModel>>(TypeOfWorkDone.ToList());
            return TypeOfWorkDoneModel;
        }
    }
}
