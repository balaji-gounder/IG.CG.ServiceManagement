using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;

namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface IASMServiceTicketClaimApprovalService
    {
        Task<IList<ASMServiceRequestClaimInfoModel>> GetAllServiceRequestClaimInfoAsync(ASMServiceRequestClaimFilter asmServiceRequestClaimFilter, string? userId);
        Task<IList<ClaimAttachmentListModel>> GetAllServiceRequestClaimAttachmentListAsync(int serviceTicketId);
        //Task<int?> UpdateServiceTicketClaimApprovalAsync(int serviceTicketId, string? Remark, string? UserId);
        Task<int?> UpdateServiceTicketClaimApprovalAsync(List<ASMServiceRequestClaimApprovalModel> lstClaimApprovalLineItems, string? userId);
        Task<IList<ASMServiceRequestClaimLineItemsModel>> GetAllServiceRequestClaimLineItemsAsync(int serviceTicketId, string? serviceTicketIDS, string userId);
        Task<IList<ASCServiceRequestClaimInfoModel>> GetAllASCServiceRequestClaimInfoAsync(ASMServiceRequestClaimFilter asmServiceRequestClaimFilter, string? userId);
        Task<IList<AscClaimApprovalLineItemsModel>> GetAllASCServiceRequestClaimLineItemsAsync(string AscCode);
        Task<IList<ASCServiceRequestClaimItemsManageApprovalModel>> GetAllASCServiceRequestClaimManageApprovalAsync(int serviceTicketId, string? serviceTicketIDS);
        Task<int?> UpdateAscServiceTicketClaimReApprovalAsync(AscServiceRequestClaimReApprovalModel AscClaimReApprovalModel);
        Task<int?> UpdateAscServiceTicketAcceptRejectionAsync(int serviceTicketId, int serviceTicketClaimId, bool IsAcceptRejection);
        Task<string?> InsertAscSpecialApprovalClaimAsync(AscSpecialApprovalClaimModel ascSpecialApprovalClaimModel, string? UserId);
        Task<string?> InsertAscIBNGenerationAsync(string AscCode, string IBNGenerationDate);
        Task<IList<AscIBNListModel>> GetAllAscIBNGeneratedListAsync(AscIBNGeneratedListFilter AscIBNGeneratedListFilter, string? UserId);
        Task<IBNPdfInfoModel> GetIBNPdfDetailsAsync(string? IBNNumber, string? AscCode);
        //Task<IList<ASMServiceRequestClaimInfoModel>> GetAllServiceRequestClaimInfoViewAsync(ASMServiceRequestClaimFilter asmServiceRequestClaimFilter, string? userId);
        Task<IList<ASCServiceRequestClaimItemsManageApprovalModel>> GetAllServiceRequestClaimLineItemsViewAsync(ClaimLineItemsViewFilter ClaimLineItemsViewFilter, string userId);
        Task<int?> UpdateAsmServiceTicketClaimAmountDistanceAsync(AsmServiceTicketClaimAmountDistanceModel AsmClaimDistanceUpdateModel);
        Task<IList<ASMSpecialApprovalLineItemsModel>> GetAllASMSpecialApprovalAsync(string? UserId);
        Task<IList<RSMSpecialApprovalLineItemsModel>> GetAllRSMSpecialApprovalAsync(string? UserId);
        Task<int?> UpdateRSMSpecialApprovalAsync(UpdateRSMSpecialApprovalModel updateRSMSpecialApprovalModel, string? UserId);
        Task<int?> UpdateASMAcceptRejectionResubmissionAsync(UpdateASMAcceptRejectionResubmissionModel UpdateASMAcceptRejectionResubmissionModel);
        Task<IList<SpecialApprovalClaimAttachmentListModel>> GetAllSpecialApprovalClaimAttachmentListAsync(string? specialApprovalId, string? serviceTicketId);
        Task<IList<ASMSpecialApprovalLineItemsModel>> GetAllASMSpecialApprovalByServiceTicketIdAsync(string? UserId, string? serviceTicketId);
        Task<IList<ASCSpecialApprovalLineItemsModel>> GetAllSpecialApprovalClaimAsync(int serviceTicketId, string? UserId);

        Task<int?> UpdateAsmIBNTicketClaimAmountAsync(AsmIBNTicketClaimAmountModel AsmIBNAmountModel);
        Task<int?> DeleteAsmIBNTicketClaimAmountAsync(AsmIBNTicketClaimAmountModel AsmIBNAmountModel);

    }
}
