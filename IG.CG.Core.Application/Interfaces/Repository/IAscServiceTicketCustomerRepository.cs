using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Interfaces.Repository
{
    public interface IAscServiceTicketCustomerRepository
    {
        Task<string?> UpsertAscServiceTicketCustomerAsync(AscServiceTicketCustomerEntity AscServiceTicketCustomerObj);
        Task<string?> UpsertASCSiteVisitAndProductReceivedAsync(ASCSiteVisitAndProductReceivedEntity AASCSiteVisitAndProductReceivedObj);

        Task<ServiceTicketTaskDetailsEntity?> GetServiceTicketTaskDetailsByIdAsync(int? ServiceTicketId);
        Task<int?> UpdateReassignedTechnicianerviceTicketAsync(int serviceTicketId, int? TechnicianId, string? Remark, string? AssignDate, string? UserId, string? AppointmentTime);
        Task<int?> UpdateAssignedASCServiceAsync(ServiceTicketASCCodeEntity AscObj);

        Task<string?> UpsertAscServiceTicketActivity(string? userId, AscServiceTicketActivityEntity objAscActivity);
        Task<string?> InsertServiceTicketPendencyReasonAsync(ServiceTicketPendencyReasonEntity serviceTicketPendencyReasonEntity);
        Task<IList<ServiceTicketPendencyReasonDisplayEntity>> GetAllServiceTicketPendencyReasonAsync(int serviceTicketId);
        Task<IList<PendingWithWhomEntity>> GetAllSTPendingWithWhomListAsync(int actualStatusOfComplaint);
        Task<IList<PendencyActionRequiredEntity>> GetAllPendencyActionRequiredAsync(int pendingWithWhomId);
        Task<int?> UpdateAssignedASMServiceAsync(ServiceTicketASMCodeEntity AsmObj, string Userid);

        Task<int?> UpdateCancelServiceAsync(ServiceTicketCancelEntity AsmObj, string Userid);


        
        Task<string?> DeleteAscServiceTicketActivityAsync(int AscActivitiesId);

        Task<ServiceTicketTaskDetailsReportEntity?> GetServiceTicketTaskDetailsTicketHistoryByIdAsync(int? ServiceTicketId);

    }
}
