using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;


namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class AsmServiceTicketCustomerRepository : IAsmServiceTicketCustomerRepository
    {
        private readonly ISqlDbContext _asmServiceTicketCustomerRepository;
        public AsmServiceTicketCustomerRepository(ISqlDbContext asmServiceTicketCustomerRepository)
        {
            _asmServiceTicketCustomerRepository = asmServiceTicketCustomerRepository;
        }

        public async Task<string?> UpdateAsmServiceTicketCancellationApprovalAsync(AsmServiceTicketCancellationApprovalEntity AsmServiceTicketCancellationApprovalObj)
        {
            var para = new DynamicParameters();
            para.Add("@AscCustomerContactedId", AsmServiceTicketCancellationApprovalObj.AscCustomerContactedId);
            para.Add("@ServiceTicketId", AsmServiceTicketCancellationApprovalObj.ServiceTicketId);
            para.Add("@ApprovedBy", AsmServiceTicketCancellationApprovalObj.ApprovedBy);
            para.Add("@ApprovedComments", AsmServiceTicketCancellationApprovalObj.ApprovedComments);
            para.Add("@ApprovedDate", AsmServiceTicketCancellationApprovalObj.ApprovedDate);
            para.Add("@UserId", AsmServiceTicketCancellationApprovalObj.UserId);


            return await _asmServiceTicketCustomerRepository.ExecuteScalarAsync<string?>(AsmServiceTicketCustomerQueries.AsmServiceTicketCancellationApprovalUpdate, para);
        }

        public async Task<string?> UpdateAsmServiceTicketCancellationRejectedAsync(AsmServiceTicketCancellationRejectedEntity AsmServiceTicketCancellationRejectedObj)
        {
            var para = new DynamicParameters();
            para.Add("@AscCustomerContactedId", AsmServiceTicketCancellationRejectedObj.AscCustomerContactedId);
            para.Add("@ServiceTicketId", AsmServiceTicketCancellationRejectedObj.ServiceTicketId);
            para.Add("@RejectedBy", AsmServiceTicketCancellationRejectedObj.RejectedBy);
            para.Add("@RejectedComments", AsmServiceTicketCancellationRejectedObj.RejectedComments);
            para.Add("@RejectedDate", AsmServiceTicketCancellationRejectedObj.RejectedDate);

            return await _asmServiceTicketCustomerRepository.ExecuteScalarAsync<string?>(AsmServiceTicketCustomerQueries.AsmServiceTicketCancellationRejectedUpdate, para);
        }

        public async Task<IList<AscListByTicketCountEntity>> GetAllAscByTicketCountAsync(string? UserId)
        {
            var para = new DynamicParameters();
            para.Add("@UserId", UserId);
            var lstAsc = await _asmServiceTicketCustomerRepository.GetAllAsync<AscListByTicketCountEntity>(AsmServiceTicketCustomerQueries.AllAscByTicketCount, para);
            return lstAsc.ToList();
        }


        public async Task<IList<AscListByTicketCountEntity>> GetAllAscByReportSearchAsync(string? UserId)
        {
            var para = new DynamicParameters();
            para.Add("@UserId", UserId);
            var lstAsc = await _asmServiceTicketCustomerRepository.GetAllAsync<AscListByTicketCountEntity>(AsmServiceTicketCustomerQueries.AllASCTicketReportSearch, para);
            return lstAsc.ToList();
        }


        public async Task<IList<AscListByTicketCountEntity>> GetAllAscBranchByReportSearchAsync(string? UserId, string? RegionCode, string? BranchCode)
        {
            var para = new DynamicParameters();
            para.Add("@UserId", UserId);
            para.Add("@RegionCode", RegionCode);
            para.Add("@BranchCode", BranchCode);
            var lstAsc = await _asmServiceTicketCustomerRepository.GetAllAsync<AscListByTicketCountEntity>(AsmServiceTicketCustomerQueries.AllBhranchASCTicketReportSearch, para);
            return lstAsc.ToList();
        }




        public async Task<IList<AscListByTicketCountEntity>> GetAllAscByTicketCountASMAsync(string? DivCode, string? ProLineCode, string? PinCode, string Userid)
        {
            var para = new DynamicParameters();
            para.Add("@DivCode", DivCode);
            para.Add("@ProLineCode", ProLineCode);
            para.Add("@PinCode", PinCode);
            para.Add("@Userid", Userid);
            var lstAsc = await _asmServiceTicketCustomerRepository.GetAllAsync<AscListByTicketCountEntity>(AsmServiceTicketCustomerQueries.AllAscByTicketASMCount, para);
            return lstAsc.ToList();
        }


        public async Task<string?> InsertAscServiceTicketFIRAsync(AscServiceTicketFirEntity ascServiceTicketFirObj)
        {
            var para = new DynamicParameters();
            para.Add("@AscServiceTicketFIRId", ascServiceTicketFirObj.AscServiceTicketFIRId);
            para.Add("@ServiceTicketId", ascServiceTicketFirObj.ServiceTicketId);
            para.Add("@SerialNo", ascServiceTicketFirObj.SerialNo);
            para.Add("@ProductCode", ascServiceTicketFirObj.ProductCode);
            para.Add("@InvoiceDate", ascServiceTicketFirObj.InvoiceDate);
            para.Add("@FailureObservation", ascServiceTicketFirObj.FailureObservation);
            para.Add("@DetailsOfWorkDone", ascServiceTicketFirObj.DetailsOfWorkDone);
            para.Add("@ReplacementTagApplied", ascServiceTicketFirObj.ReplacementTagApplied);
            para.Add("@ClosureStatusId", ascServiceTicketFirObj.ClosureStatusId);
            para.Add("@TypeOfWorkDoneId", ascServiceTicketFirObj.TypeOfWorkDoneId);
            para.Add("@IsActive", ascServiceTicketFirObj.IsActive);
            para.Add("@InvoiceNo", ascServiceTicketFirObj.InvoiceNo);
            para.Add("@DivisionCode", ascServiceTicketFirObj.DivisionCode);
            para.Add("@ProductLineCode", ascServiceTicketFirObj.ProductLineCode);
            para.Add("@TypeOfApplication", ascServiceTicketFirObj.TypeOfApplication);
            para.Add("@NoOfHours", ascServiceTicketFirObj.NoOfHours);
            para.Add("@UserId", ascServiceTicketFirObj.UserId);
            para.Add("@HP", ascServiceTicketFirObj.Hp);
            para.Add("@Frame", ascServiceTicketFirObj.Frame);
            para.Add("@Kva", ascServiceTicketFirObj.Kva);
            para.Add("@TypeOfKVA", ascServiceTicketFirObj.TypeOfKVA);
            para.Add("@TypeOfFrame", ascServiceTicketFirObj.TypeOfFrame);
            para.Add("@NoOfVisit", ascServiceTicketFirObj.NoOfVisit);
            //para.Add("@FrameSizeId", ascServiceTicketFirObj.FrameSizeId);
            var result = await _asmServiceTicketCustomerRepository.ExecuteScalarAsync<string?>(AsmServiceTicketCustomerQueries.InsertAscServiceTicketFir, para);
            return result;
        }

        public async Task<string?> InsertAscServiceTicketDefectFIRAsync(AscServiceTicketFirDefectEntity ascServiceTicketFirObj)
        {
            var para = new DynamicParameters();

            para.Add("@ServiceTicketId", ascServiceTicketFirObj.ServiceTicketId);

            para.Add("@FailureObservation", ascServiceTicketFirObj.FailureObservation);
            var result = await _asmServiceTicketCustomerRepository.ExecuteScalarAsync<string?>(AsmServiceTicketCustomerQueries.InsertAscServiceTicketFIRDefectInsert, para);
            return result;
        }






        public async Task<string?> InsertAscServiceTicketDefectAsync(AscServiceTicketFirDefectOneEntity ascServiceTicketFirObj)
        {
            var para = new DynamicParameters();

            para.Add("@ServiceTicketId", ascServiceTicketFirObj.ServiceTicketId);

            para.Add("@FailureObservation", ascServiceTicketFirObj.FailureObservation);
            var result = await _asmServiceTicketCustomerRepository.ExecuteScalarAsync<string?>(AsmServiceTicketCustomerQueries.InsertAscServiceTicketFIRDefectInsert, para);
            return result;
        }



        public async Task<string?> InsertAscServiceTicketDefectOneAsync(string? ServiceTicketId, string? FailureObservation)
        {
            var para = new DynamicParameters();

            para.Add("@ServiceTicketId", ServiceTicketId);

            para.Add("@FailureObservation", FailureObservation);
            var result = await _asmServiceTicketCustomerRepository.ExecuteScalarAsync<string?>(AsmServiceTicketCustomerQueries.InsertAscServiceTicketFIRDefectInsert, para);
            return result;
        }




        public async Task<string?> InsertAscServiceTicketProductFIRAsync(AscServiceTicketProductFirEntity ascServiceTicketFirObj, string? filePath)
        {
            var para = new DynamicParameters();
            para.Add("@AscServiceTicketFIRId", ascServiceTicketFirObj.AscServiceTicketFIRId);
            para.Add("@ServiceTicketId", ascServiceTicketFirObj.ServiceTicketId);
            para.Add("@SerialNo", ascServiceTicketFirObj.SerialNo);
            para.Add("@ProductCode", ascServiceTicketFirObj.ProductCode);
            para.Add("@InvoiceDate", ascServiceTicketFirObj.InvoiceDate);
            para.Add("@IsActive", ascServiceTicketFirObj.IsActive);
            para.Add("@InvoiceNo", ascServiceTicketFirObj.InvoiceNo);
            para.Add("@DivisionCode", ascServiceTicketFirObj.DivisionCode);
            para.Add("@ProductLineCode", ascServiceTicketFirObj.ProductLineCode);
            para.Add("@TypeOfApplication", ascServiceTicketFirObj.TypeOfApplication);
            para.Add("@NoOfHours", ascServiceTicketFirObj.NoOfHours);
            para.Add("@UserId", ascServiceTicketFirObj.UserId);
            para.Add("@HP", ascServiceTicketFirObj.Hp);
            para.Add("@Frame", ascServiceTicketFirObj.Frame);
            para.Add("@Kva", ascServiceTicketFirObj.Kva);
            para.Add("@filePath", filePath);
            para.Add("@ManufacturingDate", ascServiceTicketFirObj.ManufacturingDate);
            para.Add("@DateOfDispatch", ascServiceTicketFirObj.DateOfDispatch);
            para.Add("@DateOfCommissioning", ascServiceTicketFirObj.DateOfCommissioning);
            para.Add("@FailureReportedDate", ascServiceTicketFirObj.FailureReportedDate);
            para.Add("@ProductFailureDate", ascServiceTicketFirObj.ProductFailureDate);
            para.Add("@FrameSizeId", ascServiceTicketFirObj.FrameSizeId);

            var result = await _asmServiceTicketCustomerRepository.ExecuteScalarAsync<string?>(AsmServiceTicketCustomerQueries.InsertAscServiceTicketProductFir, para);
            return result;
        }



        public async Task<string?> InsertDefectListFIRAsync(FIRDefectListEntity FIRDefectEntity, string AscServiceTicketFIRId, int serviceTicketId)
        {
            var para = new DynamicParameters();
            para.Add("@AscServiceTicketFIRId", AscServiceTicketFIRId);
            para.Add("@ServiceTicketId", serviceTicketId);
            para.Add("@DefectCategoryId", FIRDefectEntity.DefectCategoryId);
            para.Add("@DefectId", FIRDefectEntity.DefectId);
            para.Add("@IsActive", 1);

            var result = await _asmServiceTicketCustomerRepository.ExecuteScalarAsync<string?>(AsmServiceTicketCustomerQueries.InsertFirDefectList, para);
            return result;
        }



        public async Task<string?> InsertDefectOneFIRAsync(string DefectId, string DefectCategoryId, string AscServiceTicketFIRId, int serviceTicketId)
        {
            var para = new DynamicParameters();
            para.Add("@AscServiceTicketFIRId", AscServiceTicketFIRId);
            para.Add("@ServiceTicketId", serviceTicketId);
            para.Add("@DefectCategoryId", DefectCategoryId);
            para.Add("@DefectId", DefectId);
            para.Add("@IsActive", 1);

            var result = await _asmServiceTicketCustomerRepository.ExecuteScalarAsync<string?>(AsmServiceTicketCustomerQueries.InsertFirDefectList, para);
            return result;
        }




        public async Task<string?> InsertSpareListFIRAsync(SpareDetailsEntity SpareEntity, string AscServiceTicketFIRId, int serviceTicketId)
        {
            var para = new DynamicParameters();
            para.Add("@AscServiceTicketFIRId", AscServiceTicketFIRId);
            para.Add("@ServiceTicketId", serviceTicketId);
            para.Add("@Spareid", SpareEntity.Spareid);
            para.Add("@quantity", SpareEntity.quantity);
            para.Add("@serialNumbers", SpareEntity.serialNumbers);
            para.Add("@Remarks", SpareEntity.Remarks);
            var result = await _asmServiceTicketCustomerRepository.ExecuteScalarAsync<string?>(AsmServiceTicketCustomerQueries.InsertAscServiceTicketSpareFIR, para);
            return result;
        }


        //public async Task<string?> InsertFIRDocumentAsync(FIRDocumentListEntity FIRDocument, string? filePath, string AscServiceTicketFIRId, int serviceTicketId)
        //{
        //    var para = new DynamicParameters();
        //    para.Add("@AscServiceTicketFIRId", AscServiceTicketFIRId);
        //    para.Add("@ServiceTicketId", serviceTicketId);
        //    para.Add("@DocumentType", FIRDocument.Label);
        //    para.Add("@DocumentPath", filePath);
        //    para.Add("@IsMandatory", FIRDocument.IsMandatory);
        //    para.Add("@IsActive", 1);
        public async Task<string?> InsertFIRDocumentAsync(FIRDocumentListEntity FIRDocument, string? filePath)
        {
            var para = new DynamicParameters();
            para.Add("@AscServiceTicketFIRId", FIRDocument.AscServiceTicketFIRId);
            para.Add("@ServiceTicketId", FIRDocument.ServiceTicketId);
            para.Add("@DocumentId", FIRDocument.DocumentId);
            para.Add("@IsMandatory", FIRDocument.IsMandatory);
            para.Add("@DocumentPath", filePath);
            para.Add("@IsActive", 1);
            var result = await _asmServiceTicketCustomerRepository.ExecuteScalarAsync<string?>(AsmServiceTicketCustomerQueries.InsertFirDocumentList, para);
            return result;
        }



        public async Task<CancellationRemarksEntity?> GetCancellationRemarksAsync(int serviceTicketId)
        {
            var para = new DynamicParameters();
            para.Add("@ServiceTicketId", serviceTicketId);
            return await _asmServiceTicketCustomerRepository.GetAsync<CancellationRemarksEntity>(AsmServiceTicketCustomerQueries.GetCancellationRemarks, para);

        }

        public async Task<IList<InternalEngineerASMListEntity>> GetAllInternalEngineerASMListAsync(string? DivisionCode)
        {
            var para = new DynamicParameters();
            para.Add("@DivisionCode", DivisionCode);
            var lstInternalEngineer = await _asmServiceTicketCustomerRepository.GetAllAsync<InternalEngineerASMListEntity>(AsmServiceTicketCustomerQueries.AllInternalEngineerASMList, para);
            return lstInternalEngineer.ToList();
        }

        public async Task<IList<FIRDocumentListDispalyEntity>> GetAllFIRDocumentListAsync(string? serviceTicketId)
        {
            var para = new DynamicParameters();
            para.Add("@serviceTicketId", serviceTicketId);
            var lstAsc = await _asmServiceTicketCustomerRepository.GetAllAsync<FIRDocumentListDispalyEntity>(AsmServiceTicketCustomerQueries.GetAscServiceTicketDocumentFIR, para);
            return lstAsc.ToList();
        }

        public async Task<string?> DeleteAscServiceTicketFIRDocumentAsync(int FIRDocumentId)
        {
            var para = new DynamicParameters();
            para.Add("@FIRDocumentId", FIRDocumentId);

            return await _asmServiceTicketCustomerRepository.ExecuteScalarAsync<string?>(AsmServiceTicketCustomerQueries.DeleteAscServiceTicketFIRDocument, para);
        }


        public async Task<string?> DeleteAscServiceTicketDefectAsync(int FIRDefectId)
        {
            var para = new DynamicParameters();
            para.Add("@FIRDefectId", FIRDefectId);

            return await _asmServiceTicketCustomerRepository.ExecuteScalarAsync<string?>(AsmServiceTicketCustomerQueries.DeleteAscServiceTicketFIRDefect, para);
        }


    }
}
