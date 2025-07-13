using IG.CG.Core.Application.Models;

namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface IAscServiceTicketCustomerService
    {
        Task<string?> UpsertAscServiceTicketCustomerAsync(AscServiceTicketCustomerModel lstAscServiceTicketCustomer, string? userId);

        Task<string?> UpsertASCSiteVisitAndProductReceivedAsync(ASCSiteVisitAndProductReceivedModel lstASCSiteVisitAndProductReceived, string? userId);

        Task<ServiceTicketTaskDetailsModel> GetServiceTicketTaskDetailsByIdAsync(int? ServiceTicketId);

        Task<int?> UpdateReassignedTechnicianerviceTicketAsync(int serviceTicketId, int? TechnicianId, string? Remark, string? AssignDate, string? UserId, string? AppointmentTime);
        Task<int?> UpdateAssignedASCServiceAsync(ServiceTicketASCCodeModel AscObj, string? userId);

        Task<string?> UpsertAscServiceTicketActivity(string? userId, List<AscServiceTicketActivityModel> objAscActivity);
        Task<string?> InsertServiceTicketPendencyReasonAsync(ServiceTicketPendencyReasonModel serviceTicketPendencyReasonModel, string? userId);
        Task<IList<ServiceTicketPendencyReasonDisplayModel>> GetAllServiceTicketPendencyReasonAsync(int serviceTicketId);
        Task<IList<PendingWithWhomModel>> GetAllSTPendingWithWhomListAsync(int actualStatusOfComplaintId);
        Task<IList<PendencyActionRequiredModel>> GetAllPendencyActionRequiredAsync(int pendingWithWhomId);
        Task<int?> UpdateAssignedASMServiceAsync(ServiceTicketASMCodeModel AscObj, string? UserId);
        Task<int?> UpdateCancelServiceAsync(ServiceTicketCancelModel AsmObj, string Userid);
        Task<string?> DeleteAscServiceTicketActivityAsync(int AscActivitiesId);

        Task<ServiceTicketTaskDetailsReportModel> GetServiceTicketTaskDetailsTicketHistoryByIdAsync(int? ServiceTicketId);
    }
}
