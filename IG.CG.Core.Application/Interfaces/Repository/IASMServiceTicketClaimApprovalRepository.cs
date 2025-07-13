using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Interfaces.Repository
{
    public interface IASMServiceTicketClaimApprovalRepository
    {
        Task<IList<ASMServiceRequestClaimInfoEntity>> GetAllServiceRequestClaimInfoAsync(ASMServiceRequestClaimFilter asmServiceRequestClaimFilter, string? userId);
        Task<IList<ClaimAttachmentListEntity>> GetAllServiceRequestClaimAttachmentListAsync(int serviceTicketId);
        Task<int?> UpdateServiceTicketClaimApprovalAsync(ASMServiceRequestClaimApprovalEntity claimApprovalObj, string? userId);
        Task<IList<ASMServiceRequestClaimLineItemsEntity>> GetAllServiceRequestClaimLineItemsAsync(int serviceTicketId, string? serviceTicketIDS, string userId);
        Task<IList<ASCServiceRequestClaimInfoEntity>> GetAllASCServiceRequestClaimInfoAsync(ASMServiceRequestClaimFilter asmServiceRequestClaimFilter, string? userId);
        Task<IList<AscClaimApprovalLineItemsEntity>> GetAllASCServiceRequestClaimLineItemsAsync(string AscCode);
        Task<IList<ASCServiceRequestClaimItemsManageApprovalEntity>> GetAllASCServiceRequestClaimManageApprovalAsync(int serviceTicketId, string? serviceTicketIDS);
        Task<int?> UpdateAscServiceTicketClaimReApprovalAsync(AscServiceRequestClaimReApprovalEntity AscClaimReApprovalEntity);
        Task<int?> UpdateAscServiceTicketAcceptRejectionAsync(int serviceTicketId, int serviceTicketClaimInfo, bool IsAcceptRejection);
        Task<string?> InsertAscSpecialApprovalClaimAsync(AscSpecialApprovalClaimModel ascSpecialApprovalClaimModel, string? UserId);
        Task<string?> InsertSpecialApprovalDocumentAsync(string? filePath, string serviceTicketId, string serviceTicketClaimId);
        Task<string?> InsertAscIBNGenerationAsync(string AscCode, string IBNGenerationDate);
        Task<IList<AscIBNListEntity>> GetAllAscIBNGeneratedListAsync(AscIBNGeneratedListFilter AscIBNGeneratedListFilter, string? UserId);
        Task<IBNPdfInfoEntity> GetIBNPdfDetailsAsync(string? IBNNumber, string? AscCode);
        Task<IList<ClaimDetailsEntity>> GetIBNPdfClaimDetailsAsync(string? IBNNumber, string? AscCode);
        //Task<IList<ASMServiceRequestClaimInfoEntity>> GetAllServiceRequestClaimInfoViewAsync(ASMServiceRequestClaimFilter asmServiceRequestClaimFilter, string? userId);
        Task<IList<ASCServiceRequestClaimItemsManageApprovalEntity>> GetAllServiceRequestClaimLineItemsViewAsync(ClaimLineItemsViewFilter ClaimLineItemsViewFilter, string userId);
        Task<int?> UpdateAsmServiceTicketClaimAmountDistanceAsync(AsmServiceTicketClaimAmountDistanceEntity AsmClaimDistanceUpdateEntity);
        Task<IList<ASMSpecialApprovalLineItemsEntity>> GetAllASMSpecialApprovalAsync(string? UserId);
        Task<IList<RSMSpecialApprovalLineItemsEntity>> GetAllRSMSpecialApprovalAsync(string? UserId);
        Task<int?> UpdateRSMSpecialApprovalAsync(UpdateRSMSpecialApprovalEntity updateRSMSpecialApprovalEntity, string? UserId);
        Task<int?> UpdateASMAcceptRejectionResubmissionAsync(UpdateASMAcceptRejectionResubmissionEntity UpdateASMAcceptRejectionResubmissionEntity);
        Task<IList<SpecialApprovalClaimAttachmentListEntity>> GetAllSpecialApprovalClaimAttachmentListAsync(string? specialApprovalId, string? serviceTicketId);
        Task<IList<ASMSpecialApprovalLineItemsEntity>> GetAllASMSpecialApprovalByServiceTicketIdAsync(string? UserId, string? serviceTicketId);
        Task<IList<ASCSpecialApprovalLineItemsEntity>> GetAllSpecialApprovalClaimAsync(int serviceTicketId, string? UserId);


        Task<int?> UpdateAsmIBNTicketClaimAmountAsync(AsmIBNTicketClaimAmountEntity AsmIBNAmountEntity);

        Task<int?> DeleteAsmIBNTicketClaimAmountAsync(AsmIBNTicketClaimAmountEntity AsmIBNAmountEntity);


    }
}
