using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Interfaces.Repository
{
    public interface IAsmServiceTicketCustomerRepository
    {
        Task<string?> UpdateAsmServiceTicketCancellationApprovalAsync(AsmServiceTicketCancellationApprovalEntity asmServiceTicketCancellationApprovalEntity);
        Task<string?> UpdateAsmServiceTicketCancellationRejectedAsync(AsmServiceTicketCancellationRejectedEntity asmServiceTicketCancellationRejectedEntity);
        Task<IList<AscListByTicketCountEntity>> GetAllAscByTicketCountAsync(string? UserId);
        Task<string?> InsertAscServiceTicketFIRAsync(AscServiceTicketFirEntity ascServiceTicketFirObj);
        Task<string?> InsertDefectListFIRAsync(FIRDefectListEntity ascServiceTicketFirObj, string AscServiceTicketFIRId, int serviceTicketId);

        Task<string?> InsertDefectOneFIRAsync(string DefectId, string DefectCategoryId, string AscServiceTicketFIRId, int serviceTicketId);

        Task<string?> InsertSpareListFIRAsync(SpareDetailsEntity ascServiceTicketFirObj, string AscServiceTicketFIRId, int serviceTicketId);
        //Task<string?> InsertFIRDocumentAsync(FIRDocumentListEntity FIRDocument);
        Task<string?> InsertFIRDocumentAsync(FIRDocumentListEntity FIRDocument, string? filePath);
        Task<CancellationRemarksEntity> GetCancellationRemarksAsync(int serviceTicketId);
        Task<IList<InternalEngineerASMListEntity>> GetAllInternalEngineerASMListAsync(string? DivisionCode);
        Task<string?> DeleteAscServiceTicketFIRDocumentAsync(int FIRDocumentId);
        Task<IList<FIRDocumentListDispalyEntity>> GetAllFIRDocumentListAsync(string? serviceTicketId);

        Task<string?> InsertAscServiceTicketProductFIRAsync(AscServiceTicketProductFirEntity ascServiceTicketFirObj, string? filePath);

        Task<IList<AscListByTicketCountEntity>> GetAllAscByTicketCountASMAsync(string? DivCode, string? ProLineCode, string? PinCode, string? Userid);

        Task<IList<AscListByTicketCountEntity>> GetAllAscByReportSearchAsync(string? UserId);

        Task<IList<AscListByTicketCountEntity>> GetAllAscBranchByReportSearchAsync(string? UserId, string? RegionCode, string? BranchCode);



        Task<string?> InsertAscServiceTicketDefectFIRAsync(AscServiceTicketFirDefectEntity ascServiceTicketFirObj);

        Task<string?> InsertAscServiceTicketDefectAsync(AscServiceTicketFirDefectOneEntity ascServiceTicketFirObj);






        Task<string?> DeleteAscServiceTicketDefectAsync(int FIRDefectId);
    }
}
