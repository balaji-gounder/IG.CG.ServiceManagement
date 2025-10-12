
using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;
namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class ASMServiceTicketClaimApprovalRepository : IASMServiceTicketClaimApprovalRepository
    {

        private readonly ISqlDbContext _asmServiceTicketClaimApprovalRepository;
        public ASMServiceTicketClaimApprovalRepository(ISqlDbContext asmServiceTicketClaimApprovalRepository)
        {
            _asmServiceTicketClaimApprovalRepository = asmServiceTicketClaimApprovalRepository;
        }

        public async Task<IList<ASMServiceRequestClaimInfoEntity>> GetAllServiceRequestClaimInfoAsync(ASMServiceRequestClaimFilter asmServiceRequestClaimFilter, string? userId)
        {
            var para = new DynamicParameters();
            para.Add("@AscCode", asmServiceRequestClaimFilter.AscCode);
            para.Add("@Warranty", asmServiceRequestClaimFilter.ServiceTicketType);
            para.Add("@DivisionCode", asmServiceRequestClaimFilter.DivisionCode);
            para.Add("@RegionCode", asmServiceRequestClaimFilter.RegionCode);
            para.Add("@ProductlineCode", asmServiceRequestClaimFilter.ProductlineCode);
            para.Add("@Month", asmServiceRequestClaimFilter.Month);
            para.Add("@UserId", userId);
            para.Add("@PageSize", asmServiceRequestClaimFilter.PageSize);
            para.Add("@PageNumber", asmServiceRequestClaimFilter.PageNumber);
            para.Add("@ServiceTicketNo", asmServiceRequestClaimFilter.ServiceTicketNo);
            var lstASMServiceTicketClaimInfo = await _asmServiceTicketClaimApprovalRepository.GetAllAsync<ASMServiceRequestClaimInfoEntity>(ASMServiceTicketClaimApprovalQueries.GetAllAsmServiceTicketClaimInfo, para);

            return lstASMServiceTicketClaimInfo.ToList();
        }


        public async Task<IList<ASMServiceRequestClaimLineItemsEntity>> GetAllServiceRequestClaimLineItemsAsync(int serviceTicketId, string? serviceTicketIDS, string userId)
        {
            var para = new DynamicParameters();
            para.Add("@ServiceTicketId", serviceTicketId);
            para.Add("@ServiceTicketIDS", serviceTicketIDS);
            para.Add("@UserId", userId);

            var lstASMServiceTicketClaimLineItems = await _asmServiceTicketClaimApprovalRepository.GetAllAsync<ASMServiceRequestClaimLineItemsEntity>(ASMServiceTicketClaimApprovalQueries.GetAllAsmServiceTicketClaimLineItems, para);

            return lstASMServiceTicketClaimLineItems.ToList();
        }

        public async Task<IList<ClaimAttachmentListEntity>> GetAllServiceRequestClaimAttachmentListAsync(int serviceTicketId)
        {
            var para = new DynamicParameters();
            para.Add("@ServiceTicketId", serviceTicketId);

            var lstServiceTicketClaimAttachment = await _asmServiceTicketClaimApprovalRepository.GetAllAsync<ClaimAttachmentListEntity>(ASMServiceTicketClaimApprovalQueries.GetAllAsmServiceTicketClaimAttachmentList, para);

            return lstServiceTicketClaimAttachment.ToList();
        }

        public async Task<int?> UpdateServiceTicketClaimApprovalAsync(ASMServiceRequestClaimApprovalEntity claimApprovalEntity, string? userId)
        {
            var para = new DynamicParameters();
            para.Add("@ServiceTicketId", claimApprovalEntity.ServiceTicketId);
            para.Add("@ServiceTicketClaimId", claimApprovalEntity.ServiceTicketClaimId);
            para.Add("@Remarks", claimApprovalEntity.Remarks);
            para.Add("@IsApproved", claimApprovalEntity.IsApproved);
            para.Add("UserId", userId);

            var result = await _asmServiceTicketClaimApprovalRepository.ExecuteScalarAsync<int?>(ASMServiceTicketClaimApprovalQueries.UpdateServiceTicketClaimApproval, para);
            return result;
        }

        public async Task<IList<ASCServiceRequestClaimInfoEntity>> GetAllASCServiceRequestClaimInfoAsync(ASMServiceRequestClaimFilter asmServiceRequestClaimFilter, string? userId)
        {
            var para = new DynamicParameters();
            para.Add("@AscCode", asmServiceRequestClaimFilter.AscCode);
            para.Add("@Warranty", asmServiceRequestClaimFilter.ServiceTicketType);
            para.Add("@DivisionCode", asmServiceRequestClaimFilter.DivisionCode);
            para.Add("@RegionCode", asmServiceRequestClaimFilter.RegionCode);
            para.Add("@BranchCode", asmServiceRequestClaimFilter.BranchCode);
            para.Add("@Month", asmServiceRequestClaimFilter.Month);
            para.Add("@UserId", userId);

            var lstASCServiceTicketClaimInfo = await _asmServiceTicketClaimApprovalRepository.GetAllAsync<ASCServiceRequestClaimInfoEntity>(ASMServiceTicketClaimApprovalQueries.GetAllAscServiceTicketClaimInfo, para);

            return lstASCServiceTicketClaimInfo.ToList();
        }

        public async Task<IList<AscClaimApprovalLineItemsEntity>> GetAllASCServiceRequestClaimLineItemsAsync(string AscCode)
        {
            var para = new DynamicParameters();
            para.Add("@AscCode", AscCode);

            var lstASCServiceTicketClaimInfo = await _asmServiceTicketClaimApprovalRepository.GetAllAsync<AscClaimApprovalLineItemsEntity>(ASMServiceTicketClaimApprovalQueries.GetAllAscServiceTicketClaimLineItems, para);

            return lstASCServiceTicketClaimInfo.ToList();
        }

        public async Task<IList<ASCServiceRequestClaimItemsManageApprovalEntity>> GetAllASCServiceRequestClaimManageApprovalAsync(int serviceTicketId, string? serviceTicketIDS)
        {
            var para = new DynamicParameters();
            para.Add("@ServiceTicketId", serviceTicketId);
            para.Add("@ServiceTicketIDS", serviceTicketIDS);


            var lstServiceTicketClaimItemsManageApproval = await _asmServiceTicketClaimApprovalRepository.GetAllAsync<ASCServiceRequestClaimItemsManageApprovalEntity>(ASMServiceTicketClaimApprovalQueries.GetAllAscServiceTicketClaimItemsManageApproval, para);

            return lstServiceTicketClaimItemsManageApproval.ToList();
        }

        public async Task<int?> UpdateAscServiceTicketClaimReApprovalAsync(AscServiceRequestClaimReApprovalEntity claimReApprovalEntity)
        {
            var para = new DynamicParameters();
            para.Add("@ServiceTicketId", claimReApprovalEntity.ServiceTicketId);
            para.Add("@ServiceTicketClaimId", claimReApprovalEntity.ServiceTicketClaimId);
            para.Add("@ASMIsRejected", claimReApprovalEntity.ASMIsRejected);
            para.Add("@RSMIsRejected", claimReApprovalEntity.RSMIsRejected);
            para.Add("@ClaimAmount", claimReApprovalEntity.ClaimAmount);
            para.Add("@CurrentDistance", claimReApprovalEntity.CurrentDistance);
            para.Add("@AscJustification", claimReApprovalEntity.AscJustification);

            var result = await _asmServiceTicketClaimApprovalRepository.ExecuteScalarAsync<int?>(ASMServiceTicketClaimApprovalQueries.UpdateAscServiceTicketClaimReApproval, para);
            return result;
        }

        public async Task<int?> UpdateAscServiceTicketAcceptRejectionAsync(int serviceTicketId, int serviceTicketClaimId, bool IsAcceptRejection)
        {
            var para = new DynamicParameters();
            para.Add("@IsAcceptRejection", IsAcceptRejection);
            para.Add("@ServiceTicketId", serviceTicketId);
            para.Add("@ServiceTicketClaimId", serviceTicketClaimId);

            var result = await _asmServiceTicketClaimApprovalRepository.ExecuteScalarAsync<int?>(ASMServiceTicketClaimApprovalQueries.UpdateAscServiceTicketClaimAcceptRejection, para);
            return result;
        }

        public async Task<string?> InsertAscSpecialApprovalClaimAsync(AscSpecialApprovalClaimModel ascSpecialApprovalClaimModel, string? UserId)
        {
            var para = new DynamicParameters();
            para.Add("@ServiceTicketId", ascSpecialApprovalClaimModel.ServiceTicketId);
            para.Add("@ClaimAmount", ascSpecialApprovalClaimModel.ClaimAmount);
            para.Add("@Remarks", ascSpecialApprovalClaimModel.Remarks);
            para.Add("@UserId", UserId);

            var result = await _asmServiceTicketClaimApprovalRepository.ExecuteScalarAsync<string?>(ASMServiceTicketClaimApprovalQueries.InsertAscSpecialApprovalClaim, para);
            return result;
        }
        public async Task<string?> InsertSpecialApprovalDocumentAsync(string? filePath, string serviceTicketId, string specialApprovalId)
        {
            var para = new DynamicParameters();
            para.Add("@filePath", filePath);
            para.Add("@ServiceTicketId", serviceTicketId);
            para.Add("@SpecialApprovalId", specialApprovalId);

            var result = await _asmServiceTicketClaimApprovalRepository.ExecuteScalarAsync<string?>(ASMServiceTicketClaimApprovalQueries.InsertAscSpecialApprovalClaimDocument, para);
            return result;
        }

        public async Task<string?> InsertAscIBNGenerationAsync(string AscCode, string IBNGenerationDate)
        {
            var para = new DynamicParameters();
            para.Add("@AscCode", AscCode);
            para.Add("@IBNGenerationDate", IBNGenerationDate);


            var result = await _asmServiceTicketClaimApprovalRepository.ExecuteScalarAsync<string?>(ASMServiceTicketClaimApprovalQueries.InsertAscIBNGeneration, para);
            return result;
        }

        public async Task<IList<AscIBNListEntity>> GetAllAscIBNGeneratedListAsync(AscIBNGeneratedListFilter AscIBNGeneratedListFilter, string? UserId)
        {
            var para = new DynamicParameters();
            para.Add("@Month", AscIBNGeneratedListFilter.Month);
            para.Add("@Year", AscIBNGeneratedListFilter.Year);
            para.Add("@DivisionCode", AscIBNGeneratedListFilter.DivisionCode);
            para.Add("@AscCode", AscIBNGeneratedListFilter.AscCode);
            para.Add("@IBNNumber", AscIBNGeneratedListFilter.IBNNumber);
            para.Add("@UserId", UserId);
            para.Add("@PageSize", AscIBNGeneratedListFilter.PageSize);
            para.Add("@PageNumber", AscIBNGeneratedListFilter.PageNumber);

            var lstAscIBNGeneratedList = await _asmServiceTicketClaimApprovalRepository.GetAllAsync<AscIBNListEntity>(ASMServiceTicketClaimApprovalQueries.GetAllAscIBNGeneratedList, para);

            return lstAscIBNGeneratedList.ToList();
        }

        public async Task<IBNPdfInfoEntity> GetIBNPdfDetailsAsync(string? IBNNumber, string? AscCode)
        {
            var para = new DynamicParameters();
            para.Add("@IBNNumber", IBNNumber);
            para.Add("@AscCode", AscCode);
            var IBNPdfInfo = await _asmServiceTicketClaimApprovalRepository.GetAsync<IBNPdfInfoEntity>(ASMServiceTicketClaimApprovalQueries.GetIBNPdfInfo, para);

            return IBNPdfInfo;

        }

        public async Task<IList<ClaimDetailsEntity>> GetIBNPdfClaimDetailsAsync(string? IBNNumber, string? AscCode)
        {
            var para = new DynamicParameters();
            para.Add("@IBNNumber", IBNNumber);
            para.Add("@AscCode", AscCode);
            var lstIBNClaimDetails = await _asmServiceTicketClaimApprovalRepository.GetAllAsync<ClaimDetailsEntity>(ASMServiceTicketClaimApprovalQueries.GetAllIBNClaimDetails, para);

            return lstIBNClaimDetails.ToList();
        }

        //public async Task<IList<ASMServiceRequestClaimInfoEntity>> GetAllServiceRequestClaimInfoViewAsync(ASMServiceRequestClaimFilter asmServiceRequestClaimFilter, string? userId)
        //{
        //    var para = new DynamicParameters();
        //    para.Add("@AscCode", asmServiceRequestClaimFilter.AscCode);
        //    para.Add("@Warranty", asmServiceRequestClaimFilter.ServiceTicketType);
        //    para.Add("@DivisionCode", asmServiceRequestClaimFilter.DivisionCode);
        //    para.Add("@RegionCode", asmServiceRequestClaimFilter.RegionCode);
        //    para.Add("@Month", asmServiceRequestClaimFilter.Month);
        //    para.Add("@UserId", userId);
        //    para.Add("@PageSize", asmServiceRequestClaimFilter.PageSize);
        //    para.Add("@PageNumber", asmServiceRequestClaimFilter.PageNumber);
        //    var lstASMServiceTicketClaimInfo = await _asmServiceTicketClaimApprovalRepository.GetAllAsync<ASMServiceRequestClaimInfoEntity>(ASMServiceTicketClaimApprovalQueries.GetAllAsmServiceTicketClaimInfoView, para);

        //    return lstASMServiceTicketClaimInfo.ToList();
        //}

        public async Task<IList<ASCServiceRequestClaimItemsManageApprovalEntity>> GetAllServiceRequestClaimLineItemsViewAsync(ClaimLineItemsViewFilter ClaimLineItemsViewFilter, string userId)
        {
            var para = new DynamicParameters();
            para.Add("@ASMIsApproved", ClaimLineItemsViewFilter.ASMIsApproved);
            para.Add("@RSMIsApproved", ClaimLineItemsViewFilter.RSMIsApproved);
            para.Add("@IsAcceptRejection", ClaimLineItemsViewFilter.IsAcceptRejection);
            para.Add("@IsASMUnApproved", ClaimLineItemsViewFilter.IsASMUnApproved);
            para.Add("@IsRSMUnApproved", ClaimLineItemsViewFilter.IsRSMUnApproved);
            para.Add("@ServiceTicketNo", ClaimLineItemsViewFilter.ServiceTicketNo);
            para.Add("@Region", ClaimLineItemsViewFilter.Region);
            para.Add("@Branch", ClaimLineItemsViewFilter.Branch);
            para.Add("@AscCode", ClaimLineItemsViewFilter.AscCode);
            para.Add("@DivCode", ClaimLineItemsViewFilter.DivCode);
            para.Add("@ProductLineCode", ClaimLineItemsViewFilter.ProductLineCode);
            para.Add("@FromDate", ClaimLineItemsViewFilter.FromDate);
            para.Add("@ToDate", ClaimLineItemsViewFilter.ToDate);
            para.Add("@UserId", userId);
            para.Add("@PageSize", ClaimLineItemsViewFilter.PageSize);
            para.Add("@PageNumber", ClaimLineItemsViewFilter.PageNumber);


            var lstASMServiceTicketClaimLineItems = await _asmServiceTicketClaimApprovalRepository.GetAllAsync<ASCServiceRequestClaimItemsManageApprovalEntity>(ASMServiceTicketClaimApprovalQueries.GetAllAsmServiceTicketClaimLineItemsView, para);

            return lstASMServiceTicketClaimLineItems.ToList();
        }

        public async Task<int?> UpdateAsmServiceTicketClaimAmountDistanceAsync(AsmServiceTicketClaimAmountDistanceEntity AsmClaimDistanceUpdateEntity)
        {
            var para = new DynamicParameters();
            para.Add("@ServiceTicketId", AsmClaimDistanceUpdateEntity.ServiceTicketId);
            para.Add("@ServiceTicketClaimId", AsmClaimDistanceUpdateEntity.ServiceTicketClaimId);
            para.Add("@ClaimAmount", AsmClaimDistanceUpdateEntity.ClaimAmount);
            para.Add("@CurrentDistance", AsmClaimDistanceUpdateEntity.CurrentDistance);
            para.Add("@NoOfVisit", AsmClaimDistanceUpdateEntity.NoOfVisit);

            var result = await _asmServiceTicketClaimApprovalRepository.ExecuteScalarAsync<int?>(ASMServiceTicketClaimApprovalQueries.UpdateAsmServiceTicketClaimDistance, para);
            return result;
        }



        public async Task<int?> UpdateAsmIBNTicketClaimAmountAsync(AsmIBNTicketClaimAmountEntity AsmClaimDistanceUpdateEntity)
        {
            var para = new DynamicParameters();
            para.Add("@ServiceTicketId", AsmClaimDistanceUpdateEntity.ServiceTicketId);
            para.Add("@ServiceTicketClaimId", AsmClaimDistanceUpdateEntity.ServiceTicketClaimId);
            para.Add("@ClaimAmount", AsmClaimDistanceUpdateEntity.ClaimAmount);
            para.Add("@ClaimAmountIBN", AsmClaimDistanceUpdateEntity.ClaimAmountIBN);
            para.Add("@ASMApprovedBy", AsmClaimDistanceUpdateEntity.ASMApprovedBy);
            para.Add("@Remarks", AsmClaimDistanceUpdateEntity.Remarks);

            var result = await _asmServiceTicketClaimApprovalRepository.ExecuteScalarAsync<int?>(ASMServiceTicketClaimApprovalQueries.UpdateIBNTicketClaimAmount, para);
            return result;
        }




        public async Task<int?> DeleteAsmIBNTicketClaimAmountAsync(AsmIBNTicketClaimAmountEntity AsmClaimDistanceUpdateEntity)
        {
            var para = new DynamicParameters();

            para.Add("@ServiceTicketId", AsmClaimDistanceUpdateEntity.ServiceTicketId);
            para.Add("@ServiceTicketClaimId", AsmClaimDistanceUpdateEntity.ServiceTicketClaimId);
            para.Add("@ClaimAmount", AsmClaimDistanceUpdateEntity.ClaimAmount);
            para.Add("@ClaimAmountIBN", AsmClaimDistanceUpdateEntity.ClaimAmountIBN);
            para.Add("@ASMApprovedBy", AsmClaimDistanceUpdateEntity.ASMApprovedBy);
            para.Add("@Remarks", AsmClaimDistanceUpdateEntity.Remarks);

            var result = await _asmServiceTicketClaimApprovalRepository.ExecuteScalarAsync<int?>(ASMServiceTicketClaimApprovalQueries.DeleteIBNTicketClaimAmount, para);
            return result;
        }

        public async Task<IList<ASMSpecialApprovalLineItemsEntity>> GetAllASMSpecialApprovalAsync(string? UserId)
        {
            var para = new DynamicParameters();
            para.Add("@UserId", UserId);

            var ASMSpecialApprovalLineItems = await _asmServiceTicketClaimApprovalRepository.GetAllAsync<ASMSpecialApprovalLineItemsEntity>(ASMServiceTicketClaimApprovalQueries.GetAllASMSpecialApproval, para);

            return ASMSpecialApprovalLineItems.ToList();
        }

        public async Task<IList<RSMSpecialApprovalLineItemsEntity>> GetAllRSMSpecialApprovalAsync(string? UserId)
        {
            var para = new DynamicParameters();
            para.Add("@UserId", UserId);

            var RSMSpecialApprovalLineItems = await _asmServiceTicketClaimApprovalRepository.GetAllAsync<RSMSpecialApprovalLineItemsEntity>(ASMServiceTicketClaimApprovalQueries.GetAllRSMSpecialApproval, para);

            return RSMSpecialApprovalLineItems.ToList();
        }

        public async Task<int?> UpdateRSMSpecialApprovalAsync(UpdateRSMSpecialApprovalEntity updateRSMSpecialApprovalEntity, string? UserId)
        {
            var para = new DynamicParameters();
            para.Add("@SpecialApprovalId", updateRSMSpecialApprovalEntity.SpecialApprovalId);
            para.Add("@ServiceTicketId", updateRSMSpecialApprovalEntity.ServiceTicketId);
            para.Add("@ApprovalRemarks", updateRSMSpecialApprovalEntity.ApprovalRemarks);
            para.Add("@Claimamount1", updateRSMSpecialApprovalEntity.Claimamount1);
            para.Add("@IsApproved", updateRSMSpecialApprovalEntity.IsApproved);
            para.Add("@UserId", UserId);


            var result = await _asmServiceTicketClaimApprovalRepository.ExecuteScalarAsync<int?>(ASMServiceTicketClaimApprovalQueries.UpdateRsmSpecialApproval, para);
            return result;
        }

        public async Task<int?> UpdateASMAcceptRejectionResubmissionAsync(UpdateASMAcceptRejectionResubmissionEntity UpdateASMAcceptRejectionResubmissionEntity)
        {
            var para = new DynamicParameters();
            para.Add("@IsAccpetRejection", UpdateASMAcceptRejectionResubmissionEntity.IsAccpetRejection);
            para.Add("@IsClaimResubmission", UpdateASMAcceptRejectionResubmissionEntity.IsClaimResubmission);
            para.Add("@SpecialApprovalId", UpdateASMAcceptRejectionResubmissionEntity.SpecialApprovalId);
            para.Add("@ASMResubmitRemarks", UpdateASMAcceptRejectionResubmissionEntity.ASMResubmitRemarks);
            para.Add("@ClaimAmount", UpdateASMAcceptRejectionResubmissionEntity.ClaimAmount);

            var result = await _asmServiceTicketClaimApprovalRepository.ExecuteScalarAsync<int?>(ASMServiceTicketClaimApprovalQueries.UpdateAsmAcceptRejectionResubmission, para);
            return result;
        }

        public async Task<IList<SpecialApprovalClaimAttachmentListEntity>> GetAllSpecialApprovalClaimAttachmentListAsync(string? specialApprovalId, string? serviceTicketId)
        {
            var para = new DynamicParameters();
            para.Add("@SpecialApprovalId", specialApprovalId);
            para.Add("@ServiceTicketId", serviceTicketId);

            var lstSpecialApprovalClaimAttachment = await _asmServiceTicketClaimApprovalRepository.GetAllAsync<SpecialApprovalClaimAttachmentListEntity>(ASMServiceTicketClaimApprovalQueries.GetAllSpecialApprovalClaimAttachmentList, para);

            return lstSpecialApprovalClaimAttachment.ToList();
        }

        public async Task<IList<ASMSpecialApprovalLineItemsEntity>> GetAllASMSpecialApprovalByServiceTicketIdAsync(string? UserId, string? serviceTicketId)
        {
            var para = new DynamicParameters();
            para.Add("@UserId", UserId);
            para.Add("@ServiceTicketId", serviceTicketId);

            var ASMSpecialApprovalLineItems = await _asmServiceTicketClaimApprovalRepository.GetAllAsync<ASMSpecialApprovalLineItemsEntity>(ASMServiceTicketClaimApprovalQueries.GetAllASMSpecialApprovalByServiceTicketId, para);

            return ASMSpecialApprovalLineItems.ToList();
        }

        public async Task<IList<ASCSpecialApprovalLineItemsEntity>> GetAllSpecialApprovalClaimAsync(int serviceTicketId, string? UserId)
        {
            var para = new DynamicParameters();
            para.Add("@UserId", UserId);
            para.Add("@ServiceTicketId", serviceTicketId);

            var ASCSpecialApprovalLineItems = await _asmServiceTicketClaimApprovalRepository.GetAllAsync<ASCSpecialApprovalLineItemsEntity>(ASMServiceTicketClaimApprovalQueries.GetAllASCSpecialApproval, para);

            return ASCSpecialApprovalLineItems.ToList();
        }

    }
}
