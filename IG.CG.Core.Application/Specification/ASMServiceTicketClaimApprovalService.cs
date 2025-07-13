using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Entities;
using IG.CG.Core.Domain.Enums;
using Microsoft.AspNetCore.Http;
namespace IG.CG.Core.Application.Specification
{
    public class ASMServiceTicketClaimApprovalService : IASMServiceTicketClaimApprovalService
    {

        private readonly IMapper _mapper;
        private readonly IASMServiceTicketClaimApprovalRepository _ASMServiceTicketClaimApprovalRepository;
        private readonly ICommunication _communication;

        public ASMServiceTicketClaimApprovalService(IMapper mapper, IASMServiceTicketClaimApprovalRepository ASMServiceTicketClaimApprovalRepository, ICommunication communication)
        {
            _mapper = mapper;
            _ASMServiceTicketClaimApprovalRepository = ASMServiceTicketClaimApprovalRepository;
            _communication = communication;

        }

        public async Task<IList<ASMServiceRequestClaimInfoModel>> GetAllServiceRequestClaimInfoAsync(ASMServiceRequestClaimFilter asmServiceRequestClaimFilter, string? userId)
        {
            var ASMServiceRequestClaimInfo = await _ASMServiceTicketClaimApprovalRepository.GetAllServiceRequestClaimInfoAsync(asmServiceRequestClaimFilter, userId);
            var ASMServiceRequestClaimInfoModel = _mapper.Map<List<ASMServiceRequestClaimInfoModel>>(ASMServiceRequestClaimInfo.ToList());
            return ASMServiceRequestClaimInfoModel;
        }

        public async Task<IList<ASMServiceRequestClaimLineItemsModel>> GetAllServiceRequestClaimLineItemsAsync(int serviceTicketId, string? serviceTicketIDS, string userId)
        {
            var ASMServiceRequestClaimLineItems = await _ASMServiceTicketClaimApprovalRepository.GetAllServiceRequestClaimLineItemsAsync(serviceTicketId, serviceTicketIDS, userId);
            var ASMServiceRequestClaimLineItemsModel = _mapper.Map<List<ASMServiceRequestClaimLineItemsModel>>(ASMServiceRequestClaimLineItems.ToList());
            return ASMServiceRequestClaimLineItemsModel;
        }

        public async Task<IList<ClaimAttachmentListModel>> GetAllServiceRequestClaimAttachmentListAsync(int serviceTicketId)
        {
            var ServiceTicketClaimAttachmentList = await _ASMServiceTicketClaimApprovalRepository.GetAllServiceRequestClaimAttachmentListAsync(serviceTicketId);
            var ServiceTicketClaimAttachmentListModel = _mapper.Map<List<ClaimAttachmentListModel>>(ServiceTicketClaimAttachmentList.ToList());
            return ServiceTicketClaimAttachmentListModel;
        }

        public async Task<int?> UpdateServiceTicketClaimApprovalAsync(List<ASMServiceRequestClaimApprovalModel> lstClaimApprovalLineItems, string? userId)
        {
            int? result = null;
            var claimApprovalEntity = _mapper.Map<List<ASMServiceRequestClaimApprovalEntity>>(lstClaimApprovalLineItems);

            foreach (var claimApproval in claimApprovalEntity)
            {
                result = await _ASMServiceTicketClaimApprovalRepository.UpdateServiceTicketClaimApprovalAsync(claimApproval, userId);
            }
            return result;
        }

        public async Task<IList<ASCServiceRequestClaimInfoModel>> GetAllASCServiceRequestClaimInfoAsync(ASMServiceRequestClaimFilter asmServiceRequestClaimFilter, string? userId)
        {
            var ASCServiceRequestClaimInfo = await _ASMServiceTicketClaimApprovalRepository.GetAllASCServiceRequestClaimInfoAsync(asmServiceRequestClaimFilter, userId);
            var ASCServiceRequestClaimInfoModel = _mapper.Map<List<ASCServiceRequestClaimInfoModel>>(ASCServiceRequestClaimInfo.ToList());
            return ASCServiceRequestClaimInfoModel;
        }

        public async Task<IList<AscClaimApprovalLineItemsModel>> GetAllASCServiceRequestClaimLineItemsAsync(string AscCode)
        {
            var ASCServiceRequestClaimLineItems = await _ASMServiceTicketClaimApprovalRepository.GetAllASCServiceRequestClaimLineItemsAsync(AscCode);
            var ASCServiceRequestClaimLineItemsModel = _mapper.Map<List<AscClaimApprovalLineItemsModel>>(ASCServiceRequestClaimLineItems.ToList());
            return ASCServiceRequestClaimLineItemsModel;
        }

        public async Task<IList<ASCServiceRequestClaimItemsManageApprovalModel>> GetAllASCServiceRequestClaimManageApprovalAsync(int serviceTicketId, string? serviceTicketIDS)
        {
            var ASCServiceRequestClaimItemsManageApproval = await _ASMServiceTicketClaimApprovalRepository.GetAllASCServiceRequestClaimManageApprovalAsync(serviceTicketId, serviceTicketIDS);
            var ASCServiceRequestClaimItemsManageApprovalModel = _mapper.Map<List<ASCServiceRequestClaimItemsManageApprovalModel>>(ASCServiceRequestClaimItemsManageApproval.ToList());
            return ASCServiceRequestClaimItemsManageApprovalModel;
        }

        public async Task<int?> UpdateAscServiceTicketClaimReApprovalAsync(AscServiceRequestClaimReApprovalModel AscClaimReApprovalModel)
        {
            int? result = null;
            var claimReApprovalEntity = _mapper.Map<AscServiceRequestClaimReApprovalEntity>(AscClaimReApprovalModel);

            result = await _ASMServiceTicketClaimApprovalRepository.UpdateAscServiceTicketClaimReApprovalAsync(claimReApprovalEntity);

            return result;
        }

        public async Task<int?> UpdateAscServiceTicketAcceptRejectionAsync(int serviceTicketId, int serviceTicketClaimId, bool IsAcceptRejection)
        {
            int? result = null;

            result = await _ASMServiceTicketClaimApprovalRepository.UpdateAscServiceTicketAcceptRejectionAsync(serviceTicketId, serviceTicketClaimId, IsAcceptRejection);

            return result;
        }

        public async Task<string?> InsertAscSpecialApprovalClaimAsync(AscSpecialApprovalClaimModel ascSpecialApprovalClaimModel, string? UserId)
        {

            DocumentTypes docType = DocumentTypes.Document;
            string? SpecialApprovalClaimInsert = "";
            bool ifSuccess;
            string? filePath = "";
            List<IFormFile> DocumentList = new List<IFormFile>();
            DocumentList = ascSpecialApprovalClaimModel.DocumentFile;



            string? SpecialApprovalId = await _ASMServiceTicketClaimApprovalRepository.InsertAscSpecialApprovalClaimAsync(ascSpecialApprovalClaimModel, UserId);

            foreach (var document in DocumentList)
            {
                //fIRDocumentListObj.DocumentType = Path.GetFileNameWithoutExtension(document.FileName);

                List<IFormFile> documentFile = new List<IFormFile>();
                documentFile.Add(document);
                List<Tuple<bool, string>> documentResult = await _communication.UploadDocument(documentFile, docType);

                foreach (var item in documentResult)
                {
                    ifSuccess = item.Item1;
                    if (ifSuccess == true)
                    {
                        string? serviceTicketId = ascSpecialApprovalClaimModel.ServiceTicketId;
                        filePath = item.Item2;
                        SpecialApprovalClaimInsert = await _ASMServiceTicketClaimApprovalRepository.InsertSpecialApprovalDocumentAsync(filePath, serviceTicketId, SpecialApprovalId);
                    }

                }
                documentFile.Clear();

            }


            return SpecialApprovalClaimInsert;
        }

        public async Task<string?> InsertAscIBNGenerationAsync(string AscCode, string IBNGenerationDate)
        {
            string? result = null;

            result = await _ASMServiceTicketClaimApprovalRepository.InsertAscIBNGenerationAsync(AscCode, IBNGenerationDate);

            return result;
        }

        public async Task<IList<AscIBNListModel>> GetAllAscIBNGeneratedListAsync(AscIBNGeneratedListFilter AscIBNGeneratedListFilter, string? UserId)
        {
            var AscIBNGeneratedList = await _ASMServiceTicketClaimApprovalRepository.GetAllAscIBNGeneratedListAsync(AscIBNGeneratedListFilter, UserId);
            var AscIBNGeneratedListModel = _mapper.Map<List<AscIBNListModel>>(AscIBNGeneratedList.ToList());
            return AscIBNGeneratedListModel;
        }

        public async Task<IBNPdfInfoModel> GetIBNPdfDetailsAsync(string? IBNNumber, string? AscCode)
        {
            IBNPdfInfoModel IBNPdf = new IBNPdfInfoModel();
            var IBNPdfInfo = await _ASMServiceTicketClaimApprovalRepository.GetIBNPdfDetailsAsync(IBNNumber, AscCode);


            IBNPdf.PrintStatusCount = IBNPdfInfo.PrintStatusCount;
            IBNPdf.InternetBillNo = IBNPdfInfo.InternetBillNo;
            IBNPdf.Type = IBNPdfInfo.Type;
            IBNPdf.AscName = IBNPdfInfo.AscName;
            IBNPdf.AscAddress = IBNPdfInfo.AscAddress;
            IBNPdf.Branch = IBNPdfInfo.Branch;
            IBNPdf.Address = IBNPdfInfo.Address;
            IBNPdf.ProductDivision = IBNPdfInfo.ProductDivision;
            IBNPdf.ProductLine = IBNPdfInfo.ProductLine;
            IBNPdf.NoOfTickets = IBNPdfInfo.NoOfTickets;
            IBNPdf.NoOfClaims = IBNPdfInfo.NoOfClaims;
            IBNPdf.TotalAmount = IBNPdfInfo.TotalAmount;
            IBNPdf.ComplaintClosedDate = IBNPdfInfo.ComplaintClosedDate;
            IBNPdf.ComplaintClosedMonth = IBNPdfInfo.ComplaintClosedMonth;
            IBNPdf.IBNGeneratedDate = IBNPdfInfo.IBNGeneratedDate;
            IBNPdf.IBNGeneratedMonth = IBNPdfInfo.IBNGeneratedMonth;
            IBNPdf.BillRemark = IBNPdfInfo.BillRemark;
            IBNPdf.TotalNoOfRecords = IBNPdfInfo.TotalNoOfRecords;
            IBNPdf.IbnTitleDate = IBNPdfInfo.IbnTitleDate;

            var lstIBNPdfClaimDetails = await _ASMServiceTicketClaimApprovalRepository.GetIBNPdfClaimDetailsAsync(IBNNumber, AscCode);
            List<ClaimDetailsModel> IBNPdfClaimlist = new List<ClaimDetailsModel>();

            ClaimDetailsModel ObjClaimDetail = null;
            foreach (var IBNPdfClaimDetail in lstIBNPdfClaimDetails)
            {
                ObjClaimDetail = new ClaimDetailsModel();

                ObjClaimDetail.ServiceRequestNo = IBNPdfClaimDetail.ServiceRequestNo;
                ObjClaimDetail.ClaimApprovalDate = IBNPdfClaimDetail.ClaimApprovalDate;
                ObjClaimDetail.ApprovedBy = IBNPdfClaimDetail.ApprovedBy;
                ObjClaimDetail.Spare = IBNPdfClaimDetail.Spare;
                ObjClaimDetail.SpareDesc = IBNPdfClaimDetail.SpareDesc;
                ObjClaimDetail.Activity = IBNPdfClaimDetail.Activity;
                ObjClaimDetail.Parameter = IBNPdfClaimDetail.Parameter;
                ObjClaimDetail.PossibleValue = IBNPdfClaimDetail.PossibleValue;
                ObjClaimDetail.InvoiceNo = IBNPdfClaimDetail.InvoiceNo;
                ObjClaimDetail.ProductSerialNo = IBNPdfClaimDetail.ProductSerialNo;
                ObjClaimDetail.Qty = IBNPdfClaimDetail.Qty;
                ObjClaimDetail.Rate = IBNPdfClaimDetail.Rate;
                ObjClaimDetail.TotalAmount = IBNPdfClaimDetail.TotalAmount;
                ObjClaimDetail.IsConveyance = IBNPdfClaimDetail.IsConveyance;
                ObjClaimDetail.ServiceTicketId = IBNPdfClaimDetail.ServiceTicketId;
                ObjClaimDetail.ClaimRateDetailId = IBNPdfClaimDetail.ClaimRateDetailId;
                IBNPdfClaimlist.Add(ObjClaimDetail);
            }
            IBNPdf.ClaimDetailsList = IBNPdfClaimlist;

            return IBNPdf;
        }

        //public async Task<IList<ASMServiceRequestClaimInfoModel>> GetAllServiceRequestClaimInfoViewAsync(ASMServiceRequestClaimFilter asmServiceRequestClaimFilter, string? userId)
        //{
        //    var ASMServiceRequestClaimInfo = await _ASMServiceTicketClaimApprovalRepository.GetAllServiceRequestClaimInfoViewAsync(asmServiceRequestClaimFilter, userId);
        //    var ASMServiceRequestClaimInfoModel = _mapper.Map<List<ASMServiceRequestClaimInfoModel>>(ASMServiceRequestClaimInfo.ToList());
        //    return ASMServiceRequestClaimInfoModel;
        //}

        public async Task<IList<ASCServiceRequestClaimItemsManageApprovalModel>> GetAllServiceRequestClaimLineItemsViewAsync(ClaimLineItemsViewFilter ClaimLineItemsViewFilter, string userId)
        {
            var ASMServiceRequestClaimLineItems = await _ASMServiceTicketClaimApprovalRepository.GetAllServiceRequestClaimLineItemsViewAsync(ClaimLineItemsViewFilter, userId);
            var ASMServiceRequestClaimLineItemsModel = _mapper.Map<List<ASCServiceRequestClaimItemsManageApprovalModel>>(ASMServiceRequestClaimLineItems.ToList());
            return ASMServiceRequestClaimLineItemsModel;
        }

        public async Task<int?> UpdateAsmServiceTicketClaimAmountDistanceAsync(AsmServiceTicketClaimAmountDistanceModel AsmClaimDistanceUpdateModel)
        {
            int? result = null;
            var claimAmountDistanceEntity = _mapper.Map<AsmServiceTicketClaimAmountDistanceEntity>(AsmClaimDistanceUpdateModel);

            result = await _ASMServiceTicketClaimApprovalRepository.UpdateAsmServiceTicketClaimAmountDistanceAsync(claimAmountDistanceEntity);

            return result;
        }



        public async Task<int?> UpdateAsmIBNTicketClaimAmountAsync(AsmIBNTicketClaimAmountModel AsmClaimDistanceUpdateModel)
        {
            int? result = null;
            var claimAmountDistanceEntity = _mapper.Map<AsmIBNTicketClaimAmountEntity>(AsmClaimDistanceUpdateModel);

            result = await _ASMServiceTicketClaimApprovalRepository.UpdateAsmIBNTicketClaimAmountAsync(claimAmountDistanceEntity);

            return result;
        }


        public async Task<int?> DeleteAsmIBNTicketClaimAmountAsync(AsmIBNTicketClaimAmountModel AsmClaimDistanceUpdateModel)
        {
            int? result = null;
            var claimAmountDistanceEntity = _mapper.Map<AsmIBNTicketClaimAmountEntity>(AsmClaimDistanceUpdateModel);

            result = await _ASMServiceTicketClaimApprovalRepository.DeleteAsmIBNTicketClaimAmountAsync(claimAmountDistanceEntity);

            return result;
        }




        public async Task<IList<ASMSpecialApprovalLineItemsModel>> GetAllASMSpecialApprovalAsync(string? UserId)
        {
            var ASMSpecialApprovalLineItems = await _ASMServiceTicketClaimApprovalRepository.GetAllASMSpecialApprovalAsync(UserId);
            var ASMSpecialApprovalLineItemsModel = _mapper.Map<List<ASMSpecialApprovalLineItemsModel>>(ASMSpecialApprovalLineItems.ToList());
            return ASMSpecialApprovalLineItemsModel;
        }

        public async Task<IList<RSMSpecialApprovalLineItemsModel>> GetAllRSMSpecialApprovalAsync(string? UserId)
        {
            var RSMSpecialApprovalLineItems = await _ASMServiceTicketClaimApprovalRepository.GetAllRSMSpecialApprovalAsync(UserId);
            var RSMSpecialApprovalLineItemsModel = _mapper.Map<List<RSMSpecialApprovalLineItemsModel>>(RSMSpecialApprovalLineItems.ToList());
            return RSMSpecialApprovalLineItemsModel;
        }

        public async Task<int?> UpdateRSMSpecialApprovalAsync(UpdateRSMSpecialApprovalModel updateRSMSpecialApprovalModel, string? UserId)
        {
            int? result = null;
            var updateRSMSpecialApprovalEntity = _mapper.Map<UpdateRSMSpecialApprovalEntity>(updateRSMSpecialApprovalModel);

            result = await _ASMServiceTicketClaimApprovalRepository.UpdateRSMSpecialApprovalAsync(updateRSMSpecialApprovalEntity, UserId);

            return result;
        }

        public async Task<int?> UpdateASMAcceptRejectionResubmissionAsync(UpdateASMAcceptRejectionResubmissionModel UpdateASMAcceptRejectionResubmissionModel)
        {
            int? result = null;
            var UpdateASMAcceptRejectionResubmissionEntity = _mapper.Map<UpdateASMAcceptRejectionResubmissionEntity>(UpdateASMAcceptRejectionResubmissionModel);

            result = await _ASMServiceTicketClaimApprovalRepository.UpdateASMAcceptRejectionResubmissionAsync(UpdateASMAcceptRejectionResubmissionEntity);

            return result;
        }

        public async Task<IList<SpecialApprovalClaimAttachmentListModel>> GetAllSpecialApprovalClaimAttachmentListAsync(string? specialApprovalId, string? serviceTicketId)
        {
            var SpecialApprovalClaimAttachmentList = await _ASMServiceTicketClaimApprovalRepository.GetAllSpecialApprovalClaimAttachmentListAsync(specialApprovalId, serviceTicketId);
            var SpecialApprovalClaimAttachmentListModel = _mapper.Map<List<SpecialApprovalClaimAttachmentListModel>>(SpecialApprovalClaimAttachmentList.ToList());
            return SpecialApprovalClaimAttachmentListModel;
        }

        public async Task<IList<ASMSpecialApprovalLineItemsModel>> GetAllASMSpecialApprovalByServiceTicketIdAsync(string? UserId, string? serviceTicketId)
        {
            var ASMSpecialApprovalLineItems = await _ASMServiceTicketClaimApprovalRepository.GetAllASMSpecialApprovalByServiceTicketIdAsync(UserId, serviceTicketId);
            var ASMSpecialApprovalLineItemsModel = _mapper.Map<List<ASMSpecialApprovalLineItemsModel>>(ASMSpecialApprovalLineItems.ToList());
            return ASMSpecialApprovalLineItemsModel;
        }

        public async Task<IList<ASCSpecialApprovalLineItemsModel>> GetAllSpecialApprovalClaimAsync(int serviceTicketId, string? UserId)
        {
            var ASCSpecialApprovalLineItems = await _ASMServiceTicketClaimApprovalRepository.GetAllSpecialApprovalClaimAsync(serviceTicketId, UserId);
            var ASCSpecialApprovalLineItemsModel = _mapper.Map<List<ASCSpecialApprovalLineItemsModel>>(ASCSpecialApprovalLineItems.ToList());
            return ASCSpecialApprovalLineItemsModel;
        }

    }
}
