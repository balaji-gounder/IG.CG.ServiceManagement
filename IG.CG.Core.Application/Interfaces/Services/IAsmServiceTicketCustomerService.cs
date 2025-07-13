
using IG.CG.Core.Application.Models;


namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface IAsmServiceTicketCustomerService
    {
        Task<string?> UpdateAsmServiceTicketCancellationApprovalAsync(AsmServiceTicketCancellationApprovalModel asmServiceTicketCancellationApprovalModel, string? UserId);
        Task<string?> UpdateAsmServiceTicketCancellationRejectedAsync(AsmServiceTicketCancellationRejectedModel asmServiceTicketCancellationRejectedModel);
        Task<IList<AscListByTicketCountModel>> GetAllAscByTicketCountAsync(string? UserId);
        Task<string?> InsertAscServiceTicketFIRAsync(AscServiceTicketFirModel ascServiceTicketFirModel, string? userId);
        Task<CancellationRemarksModel> GetCancellationRemarksAsync(int serviceTicketId);
        Task<IList<InternalEngineerASMListModel>> GetAllInternalEngineerASMListAsync(string? DivisionCode);

        Task<string?> InsertFIRDocumentAsync(FIRDocumentWithTypeModel firDocumentWithTypeListModel);
        Task<string?> DeleteAscServiceTicketFIRDocumentAsync(int FIRDocumentId);


        Task<IList<FIRDocumentListDisplaynModel>> GetAllFIRDocumentListAsync(string? serviceTicketId);

        Task<string?> InsertAscServiceTicketProductFIRAsync(AscServiceTicketProductFirModel ascServiceTicketFirModel, string? userId);

        Task<IList<AscListByTicketCountModel>> GetAllAscByTicketCountASMAsync(string? DivCode, string? ProLineCode, string? PinCode, string? Userid);

        Task<IList<AscListByTicketCountModel>> GetAllAscByReportSearchAsync(string? UserId);

        Task<IList<AscListByTicketCountModel>> GetAllAscBranchByReportSearchAsync(string? UserId, string? RegionCode, string? BranchCode);

        Task<string?> InsertAscServiceTicketDefectFIRAsync(AscServiceTicketFirDefectModel ascServiceTicketFirObj);

        Task<string?> InsertAscServiceTicketDefectAsync(AscServiceTicketFirDefectOneModel ascServiceTicketFirObj);

        //Task<string?> InsertAscServiceTicketDefectOneAsync(string? ServiceTicketId, string? FailureObservation);
        Task<string?> DeleteAscServiceTicketDefectAsync(int FIRDefectId);
    }
}
