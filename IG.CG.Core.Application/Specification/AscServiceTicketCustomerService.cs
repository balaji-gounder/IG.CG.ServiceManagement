
using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Specification
{
    public class AscServiceTicketCustomerService : IAscServiceTicketCustomerService
    {

        private readonly IMapper _mapper;
        private readonly IAscServiceTicketCustomerRepository _ascServiceTicketCustomerRepository;
        public AscServiceTicketCustomerService(IMapper mapper, IAscServiceTicketCustomerRepository ascServiceTicketCustomerRepository)
        {
            _mapper = mapper;
            _ascServiceTicketCustomerRepository = ascServiceTicketCustomerRepository;

        }
        public async Task<string?> UpsertAscServiceTicketCustomerAsync(AscServiceTicketCustomerModel ascServiceTicketCustomerModel, string? userId)
        {
            AscServiceTicketCustomerEntity AscServiceTicketCustomerObj = _mapper.Map<AscServiceTicketCustomerEntity>(ascServiceTicketCustomerModel);
            AscServiceTicketCustomerObj.UserId = userId;
            return await _ascServiceTicketCustomerRepository.UpsertAscServiceTicketCustomerAsync(AscServiceTicketCustomerObj);
        }

        public async Task<string?> UpsertASCSiteVisitAndProductReceivedAsync(ASCSiteVisitAndProductReceivedModel ascServiceTicketCustomerModel, string? userId)
        {
            ASCSiteVisitAndProductReceivedEntity AscServiceTicketCustomerObj = _mapper.Map<ASCSiteVisitAndProductReceivedEntity>(ascServiceTicketCustomerModel);
            AscServiceTicketCustomerObj.UserId = userId;
            return await _ascServiceTicketCustomerRepository.UpsertASCSiteVisitAndProductReceivedAsync(AscServiceTicketCustomerObj);
        }

        public async Task<ServiceTicketTaskDetailsModel> GetServiceTicketTaskDetailsByIdAsync(int? ServiceTicketId)
        {
            var ascSTR = await _ascServiceTicketCustomerRepository.GetServiceTicketTaskDetailsByIdAsync(ServiceTicketId);
            var ascSTRModel = _mapper.Map<ServiceTicketTaskDetailsModel>(ascSTR);
            return ascSTRModel;
        }


        public async Task<ServiceTicketTaskDetailsReportModel> GetServiceTicketTaskDetailsTicketHistoryByIdAsync(int? ServiceTicketId)
        {
            var ascSTR = await _ascServiceTicketCustomerRepository.GetServiceTicketTaskDetailsTicketHistoryByIdAsync(ServiceTicketId);
            var ascSTRModel = _mapper.Map<ServiceTicketTaskDetailsReportModel>(ascSTR);
            return ascSTRModel;


        }

        public async Task<int?> UpdateReassignedTechnicianerviceTicketAsync(int serviceTicketId, int? TechnicianId, string? Remark, string? AssignDate, string? UserId, string? AppointmentTime)
        {
            return await _ascServiceTicketCustomerRepository.UpdateReassignedTechnicianerviceTicketAsync(serviceTicketId, TechnicianId, Remark, AssignDate, UserId, AppointmentTime);
        }

        public async Task<int?> UpdateAssignedASCServiceAsync(ServiceTicketASCCodeModel ASCModel, string? userId)
        {
            ServiceTicketASCCodeEntity AscObj = _mapper.Map<ServiceTicketASCCodeEntity>(ASCModel);
            AscObj.UserId = userId;
            return await _ascServiceTicketCustomerRepository.UpdateAssignedASCServiceAsync(AscObj);

        }

        public async Task<string?> UpsertAscServiceTicketActivity(string? userId, List<AscServiceTicketActivityModel> lstAscActivity)
        {
            string? result = null;
            var lstAscActivityModel = _mapper.Map<List<AscServiceTicketActivityEntity>>(lstAscActivity);

            foreach (var AscActivity in lstAscActivityModel)
            {
                result = await _ascServiceTicketCustomerRepository.UpsertAscServiceTicketActivity(userId, AscActivity);
            }
            return result;
        }

        public async Task<string?> InsertServiceTicketPendencyReasonAsync(ServiceTicketPendencyReasonModel serviceTicketPendencyReasonModel, string? userId)
        {
            ServiceTicketPendencyReasonEntity pendencyReasonObj = _mapper.Map<ServiceTicketPendencyReasonEntity>(serviceTicketPendencyReasonModel);
            pendencyReasonObj.UserId = userId;
            return await _ascServiceTicketCustomerRepository.InsertServiceTicketPendencyReasonAsync(pendencyReasonObj);

        }

        public async Task<IList<ServiceTicketPendencyReasonDisplayModel>> GetAllServiceTicketPendencyReasonAsync(int serviceTicketId)
        {
            var pendencyReason = await _ascServiceTicketCustomerRepository.GetAllServiceTicketPendencyReasonAsync(serviceTicketId);
            var pendencyReasonModel = _mapper.Map<List<ServiceTicketPendencyReasonDisplayModel>>(pendencyReason.ToList());
            return pendencyReasonModel;
        }

        public async Task<IList<PendingWithWhomModel>> GetAllSTPendingWithWhomListAsync(int actualStatusOfComplaintId)
        {
            var STpendingWithWhomList = await _ascServiceTicketCustomerRepository.GetAllSTPendingWithWhomListAsync(actualStatusOfComplaintId);
            var STpendingWithWhomListModel = _mapper.Map<List<PendingWithWhomModel>>(STpendingWithWhomList.ToList());
            return STpendingWithWhomListModel;
        }

        public async Task<IList<PendencyActionRequiredModel>> GetAllPendencyActionRequiredAsync(int pendingWithWhomId)
        {
            var pendencyActionRequired = await _ascServiceTicketCustomerRepository.GetAllPendencyActionRequiredAsync(pendingWithWhomId);
            var pendencyActionRequiredModel = _mapper.Map<List<PendencyActionRequiredModel>>(pendencyActionRequired.ToList());
            return pendencyActionRequiredModel;
        }

        public async Task<int?> UpdateAssignedASMServiceAsync(ServiceTicketASMCodeModel ASMModel, string? UserId)
        {
            ServiceTicketASMCodeEntity AscObj = _mapper.Map<ServiceTicketASMCodeEntity>(ASMModel);
            return await _ascServiceTicketCustomerRepository.UpdateAssignedASMServiceAsync(AscObj, UserId);

        }

        public async Task<int?> UpdateCancelServiceAsync(ServiceTicketCancelModel ASMModel, string? UserId)
        {
            ServiceTicketCancelEntity AscObj = _mapper.Map<ServiceTicketCancelEntity>(ASMModel);
            return await _ascServiceTicketCustomerRepository.UpdateCancelServiceAsync(AscObj, UserId);

        }


        public async Task<string?> DeleteAscServiceTicketActivityAsync(int serviceTicketId)
        {
            return await _ascServiceTicketCustomerRepository.DeleteAscServiceTicketActivityAsync(serviceTicketId);
        }
    }
}
