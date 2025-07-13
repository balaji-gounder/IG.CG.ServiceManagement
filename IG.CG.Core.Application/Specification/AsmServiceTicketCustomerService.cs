
using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;
using IG.CG.Core.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace IG.CG.Core.Application.Specification
{
    public class AsmServiceTicketCustomerService : IAsmServiceTicketCustomerService
    {

        private readonly IMapper _mapper;
        private readonly IAsmServiceTicketCustomerRepository _asmServiceTicketCustomerRepository;
        private readonly ICommunication _communication;
        public AsmServiceTicketCustomerService(IMapper mapper, IAsmServiceTicketCustomerRepository asmServiceTicketCustomerRepository, ICommunication communication)
        {
            _mapper = mapper;
            _asmServiceTicketCustomerRepository = asmServiceTicketCustomerRepository;
            _communication = communication;

        }

        public async Task<string?> UpdateAsmServiceTicketCancellationApprovalAsync(AsmServiceTicketCancellationApprovalModel asmServiceTicketCancellationApprovalModel, string? UserId)
        {
            AsmServiceTicketCancellationApprovalEntity AsmServiceTicketCancellationApprovalObj = _mapper.Map<AsmServiceTicketCancellationApprovalEntity>(asmServiceTicketCancellationApprovalModel);
            AsmServiceTicketCancellationApprovalObj.UserId = UserId;
            return await _asmServiceTicketCustomerRepository.UpdateAsmServiceTicketCancellationApprovalAsync(AsmServiceTicketCancellationApprovalObj);
        }

        public async Task<string?> UpdateAsmServiceTicketCancellationRejectedAsync(AsmServiceTicketCancellationRejectedModel asmServiceTicketCancellationRejectedModel)
        {
            AsmServiceTicketCancellationRejectedEntity AsmServiceTicketCancellationRejectedObj = _mapper.Map<AsmServiceTicketCancellationRejectedEntity>(asmServiceTicketCancellationRejectedModel);
            return await _asmServiceTicketCustomerRepository.UpdateAsmServiceTicketCancellationRejectedAsync(AsmServiceTicketCancellationRejectedObj);
        }

        public async Task<IList<AscListByTicketCountModel>> GetAllAscByTicketCountAsync(string? userId)
        {
            var ascListByTicketCount = await _asmServiceTicketCustomerRepository.GetAllAscByTicketCountAsync(userId);
            var ascListByTicketCountModel = _mapper.Map<List<AscListByTicketCountModel>>(ascListByTicketCount.ToList());
            return ascListByTicketCountModel;
        }


        public async Task<IList<AscListByTicketCountModel>> GetAllAscByReportSearchAsync(string? userId)
        {
            var ascListByTicketCount = await _asmServiceTicketCustomerRepository.GetAllAscByReportSearchAsync(userId);
            var ascListByTicketCountModel = _mapper.Map<List<AscListByTicketCountModel>>(ascListByTicketCount.ToList());
            return ascListByTicketCountModel;
        }


        public async Task<IList<AscListByTicketCountModel>> GetAllAscBranchByReportSearchAsync(string? UserId, string? RegionCode, string? BranchCode)
        {
            var ascListByTicketCount = await _asmServiceTicketCustomerRepository.GetAllAscBranchByReportSearchAsync(UserId, RegionCode, BranchCode);
            var ascListByTicketCountModel = _mapper.Map<List<AscListByTicketCountModel>>(ascListByTicketCount.ToList());
            return ascListByTicketCountModel;
        }


        public async Task<IList<AscListByTicketCountModel>> GetAllAscByTicketCountASMAsync(string? DivCode, string? ProLineCode, string? PinCode, string? Userid)
        {
            var ascListByTicketCount = await _asmServiceTicketCustomerRepository.GetAllAscByTicketCountASMAsync(DivCode, ProLineCode, PinCode, Userid);
            var ascListByTicketCountModel = _mapper.Map<List<AscListByTicketCountModel>>(ascListByTicketCount.ToList());
            return ascListByTicketCountModel;
        }


        public async Task<string?> InsertAscServiceTicketFIRAsync(AscServiceTicketFirModel ascServiceTicketFirModel, string? userId)
        {
            string? defectInsertResult;
            string? AscServiceTicketFIRId = null;


            var lstDefectEntity = _mapper.Map<List<FIRDefectListEntity>>(ascServiceTicketFirModel.DefectList);

            var lstSparelist = _mapper.Map<List<SpareDetailsEntity>>(ascServiceTicketFirModel.Sparelist);

            var ascServiceTicketFirObj = _mapper.Map<AscServiceTicketFirEntity>(ascServiceTicketFirModel);
            ascServiceTicketFirObj.UserId = userId;

            AscServiceTicketFIRId = await _asmServiceTicketCustomerRepository.InsertAscServiceTicketFIRAsync(ascServiceTicketFirObj);
            int serviceTicketId = ascServiceTicketFirObj.ServiceTicketId;

            if (lstDefectEntity.Count != 0)
            {
                foreach (var defectEntity in lstDefectEntity)
                {
                    defectInsertResult = await _asmServiceTicketCustomerRepository.InsertDefectListFIRAsync(defectEntity, AscServiceTicketFIRId, serviceTicketId);
                }
            }


            if (lstSparelist.Count != 0)
            {
                foreach (var SpareEntity in lstSparelist)
                {
                    defectInsertResult = await _asmServiceTicketCustomerRepository.InsertSpareListFIRAsync(SpareEntity, AscServiceTicketFIRId, serviceTicketId);
                }
            }




            return AscServiceTicketFIRId;
        }


        public async Task<string?> InsertAscServiceTicketDefectFIRAsync(AscServiceTicketFirDefectModel ascServiceTicketFirModel)
        {
            string? AscServiceTicketFIRId = null;


            var lstDefectEntity = _mapper.Map<List<FIRDefectListEntity>>(ascServiceTicketFirModel.DefectList);


            var ascServiceTicketFirObj = _mapper.Map<AscServiceTicketFirDefectEntity>(ascServiceTicketFirModel);


            AscServiceTicketFIRId = await _asmServiceTicketCustomerRepository.InsertAscServiceTicketDefectFIRAsync(ascServiceTicketFirObj);

            //int serviceTicketId = ascServiceTicketFirObj.ServiceTicketId;

            //if (lstDefectEntity.Count != 0)
            //{
            //    foreach (var defectEntity in lstDefectEntity)
            //    {
            //        defectInsertResult = await _asmServiceTicketCustomerRepository.InsertDefectListFIRAsync(defectEntity, AscServiceTicketFIRId, serviceTicketId);
            //    }
            //}


            return AscServiceTicketFIRId;
        }



        public async Task<string?> InsertAscServiceTicketDefectAsync(AscServiceTicketFirDefectOneModel ascServiceTicketFirModel)
        {
            string? defectInsertResult;
            string? AscServiceTicketFIRId = null;


            defectInsertResult = await _asmServiceTicketCustomerRepository.InsertDefectOneFIRAsync(ascServiceTicketFirModel.DefectId.ToString(), ascServiceTicketFirModel.DefectCategoryId.ToString(), AscServiceTicketFIRId, ascServiceTicketFirModel.ServiceTicketId);


            return defectInsertResult;
        }





        public async Task<string?> InsertAscServiceTicketProductFIRAsync(AscServiceTicketProductFirModel ascServiceTicketFirModel, string? userId)
        {
            bool ifSuccess;
            string? AscServiceTicketFIRId = null;
            DocumentTypes docType = DocumentTypes.FIRDocument;
            string? filePath = "";

            List<Tuple<bool, string>> documentResult = await _communication.UploadDocument(ascServiceTicketFirModel.InvoiceFile, docType);

            foreach (var item in documentResult)
            {
                ifSuccess = item.Item1;
                if (ifSuccess == true)
                {
                    filePath = item.Item2;
                }
            }


            var ascServiceTicketFirObj = _mapper.Map<AscServiceTicketProductFirEntity>(ascServiceTicketFirModel);
            ascServiceTicketFirObj.UserId = userId;

            AscServiceTicketFIRId = await _asmServiceTicketCustomerRepository.InsertAscServiceTicketProductFIRAsync(ascServiceTicketFirObj, filePath);
            int serviceTicketId = ascServiceTicketFirObj.ServiceTicketId;

            return AscServiceTicketFIRId;
        }




        public async Task<CancellationRemarksModel> GetCancellationRemarksAsync(int serviceTicketId)
        {
            var CancellationRemarks = await _asmServiceTicketCustomerRepository.GetCancellationRemarksAsync(serviceTicketId);
            var CancellationRemarksModel = _mapper.Map<CancellationRemarksModel>(CancellationRemarks);
            return CancellationRemarksModel;
        }

        public async Task<IList<InternalEngineerASMListModel>> GetAllInternalEngineerASMListAsync(string? DivisionCode)
        {
            var internalEngineerASMList = await _asmServiceTicketCustomerRepository.GetAllInternalEngineerASMListAsync(DivisionCode);
            var internalEngineerASMListModel = _mapper.Map<List<InternalEngineerASMListModel>>(internalEngineerASMList.ToList());
            return internalEngineerASMListModel;
        }


        public async Task<string?> InsertFIRDocumentAsync(FIRDocumentWithTypeModel FirDocModel)
        {

            DocumentTypes docType = DocumentTypes.FIRDocument;
            string? FIRDocumentInsert = "";
            bool ifSuccess;
            string? filePath = "";
            List<IFormFile> DocumentWithType = new List<IFormFile>();
            DocumentWithType = FirDocModel.DocumentWithType;

            FIRDocumentListEntity fIRDocumentListObj = new FIRDocumentListEntity();
            fIRDocumentListObj.AscServiceTicketFIRId = FirDocModel.AscServiceTicketFIRId;
            fIRDocumentListObj.ServiceTicketId = FirDocModel.ServiceTicketId;
            fIRDocumentListObj.DocumentId = FirDocModel.DocumentId;
            fIRDocumentListObj.IsMandatory = FirDocModel.IsMandatory;

            foreach (var document in DocumentWithType)
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
                        filePath = item.Item2;
                        FIRDocumentInsert = await _asmServiceTicketCustomerRepository.InsertFIRDocumentAsync(fIRDocumentListObj, filePath);
                    }

                }
                documentFile.Clear();

            }

            //FIRDocumentWithTypeEntity FirObj = _mapper.Map<FIRDocumentWithTypeEntity>(FirDocModel);
            //List<IFormFile> InvoiceFile = new List<IFormFile>();
            //InvoiceFile.Add(FirObj.DocumentPath);
            //DocumentTypes documentType = DocumentTypes.FIRDocument;
            //string? FIRDocumentInsert = "";
            //bool ifSuccess;
            //string? filePath = "";
            //List<Tuple<bool, string>> documentResult = await _communication.UploadDocument(InvoiceFile, documentType);
            //foreach (var item in documentResult)
            //{
            //    ifSuccess = item.Item1;
            //    if (ifSuccess == true)
            //    {
            //        filePath = item.Item2;
            //        FIRDocumentInsert = await _asmServiceTicketCustomerRepository.InsertFIRDocumentAsync(FirObj, filePath);
            //    }

            //}



            //public async Task<string?> InsertFIRDocumentAsync(FIRDocumentListModel FirDoc)
            //{
            //    FIRDocumentListEntity FirObj = _mapper.Map<FIRDocumentListEntity>(FirDoc);


            return FIRDocumentInsert;
        }



        public async Task<IList<FIRDocumentListDisplaynModel>> GetAllFIRDocumentListAsync(string? serviceTicketId)
        {
            var FIRDocList = await _asmServiceTicketCustomerRepository.GetAllFIRDocumentListAsync(serviceTicketId);
            var FIRDocModel = _mapper.Map<List<FIRDocumentListDisplaynModel>>(FIRDocList.ToList());
            return FIRDocModel;
        }




        public async Task<string?> DeleteAscServiceTicketFIRDocumentAsync(int FIRDocumentId)
        {
            return await _asmServiceTicketCustomerRepository.DeleteAscServiceTicketFIRDocumentAsync(FIRDocumentId);
        }


        public async Task<string?> DeleteAscServiceTicketDefectAsync(int FIRDefectId)
        {
            return await _asmServiceTicketCustomerRepository.DeleteAscServiceTicketDefectAsync(FIRDefectId);
        }

    }
}
