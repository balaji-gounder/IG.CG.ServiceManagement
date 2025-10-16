
using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class AscServiceTicketCustomerRepository : IAscServiceTicketCustomerRepository
    {
        private readonly ISqlDbContext _ascServiceTicketCustomerRepository;
        public AscServiceTicketCustomerRepository(ISqlDbContext ascServiceTicketCustomerRepository)
        {
            _ascServiceTicketCustomerRepository = ascServiceTicketCustomerRepository;
        }
        public async Task<string?> UpsertAscServiceTicketCustomerAsync(AscServiceTicketCustomerEntity AscServiceTicketCustomerObj)
        {
            var para = new DynamicParameters();
            para.Add("@AscCustomerContactedId", AscServiceTicketCustomerObj.AscCustomerContactedId);
            para.Add("@ServiceTicketId", AscServiceTicketCustomerObj.ServiceTicketId);
            para.Add("@ComplainType", AscServiceTicketCustomerObj.ComplainType);
            para.Add("@ContactDate", AscServiceTicketCustomerObj.ContactDate);
            para.Add("@SerialNo", AscServiceTicketCustomerObj.SerialNo);
            para.Add("@Frame", AscServiceTicketCustomerObj.Frame);
            para.Add("@ProductCode", AscServiceTicketCustomerObj.ProductCode);
            para.Add("@InvoiceDate", AscServiceTicketCustomerObj.InvoiceDate);
            para.Add("@InvoiceNo", AscServiceTicketCustomerObj.InvoiceNo);
            para.Add("@Remarks", AscServiceTicketCustomerObj.Remarks);
            para.Add("@ServiceRequestSubStatusId", AscServiceTicketCustomerObj.ServiceRequestSubStatusId);
            para.Add("@ServiceRequestCustStatusid", AscServiceTicketCustomerObj.ServiceRequestCustStatusid);
            para.Add("@UserId", AscServiceTicketCustomerObj.UserId);
            para.Add("@ProductRquestDate", AscServiceTicketCustomerObj.ProductRquestDate);
            para.Add("@TechnicianId", AscServiceTicketCustomerObj.TechnicianId);
            para.Add("@KW", AscServiceTicketCustomerObj.KW);
            para.Add("@KVA", AscServiceTicketCustomerObj.KVA);
            para.Add("@EFFE", AscServiceTicketCustomerObj.EFFE);
            para.Add("@FLPS", AscServiceTicketCustomerObj.FLPS);
            para.Add("@HP", AscServiceTicketCustomerObj.HP);
            para.Add("@appointmentTime", AscServiceTicketCustomerObj.AppointmentTime);

            return await _ascServiceTicketCustomerRepository.ExecuteScalarAsync<string?>(AscServiceTicketCustomerQueries.AscServiceTicketCustomerInsertUpdate, para);
        }


        public async Task<string?> UpsertASCSiteVisitAndProductReceivedAsync(ASCSiteVisitAndProductReceivedEntity AscServiceTicketVisitAndReceivedObj)
        {
            var para = new DynamicParameters();
            //para.Add("@ASCSiteVisitAndProductReceivedId", AscServiceTicketVisitAndReceivedObj.ASCSiteVisitAndProductReceivedId);
            //para.Add("@ServiceTicketId", AscServiceTicketVisitAndReceivedObj.ServiceTicketId);
            //para.Add("@TypeService", AscServiceTicketVisitAndReceivedObj.TypeService);
            //para.Add("@ServiceDate", AscServiceTicketVisitAndReceivedObj.ServiceDate);
            //para.Add("@AssignTechician", AscServiceTicketVisitAndReceivedObj.AssignTechician);
            //para.Add("@ProductReceivedDate", AscServiceTicketVisitAndReceivedObj.ProductReceivedDate ?? (object)DBNull.Value);
            //para.Add("@ProductReceivedType", AscServiceTicketVisitAndReceivedObj.ProductReceviedType);
            //para.Add("@Remarks", AscServiceTicketVisitAndReceivedObj.Remarks);
            //para.Add("@ProductReceviedASCDate", AscServiceTicketVisitAndReceivedObj.ProductReceviedASCDate ?? (object)DBNull.Value);
            //para.Add("@UserId", AscServiceTicketVisitAndReceivedObj.UserId);
            //para.Add("@AscActivitiesName", AscServiceTicketVisitAndReceivedObj.AscActivitiesName);


            return await _ascServiceTicketCustomerRepository.ExecuteScalarAsync<string?>(AscServiceTicketCustomerQueries.AscSiteVisitAndProductReceivedInsertUpdate, para);
        }

        public async Task<ServiceTicketTaskDetailsEntity> GetServiceTicketTaskDetailsByIdAsync(int? ServiceTicketId)
        {
            ServiceTicketTaskDetailsEntity ObjASC = null;
            ObjASC = new ServiceTicketTaskDetailsEntity();
            ObjASC.ServiceTicketId = ServiceTicketId.ToString();
            ObjASC.ServiceTicketNo = "1";

            var sp_params = new DynamicParameters();
            sp_params.Add("@ServiceTicketId", ServiceTicketId);
            var lstASCTCR = await _ascServiceTicketCustomerRepository.GetAllAsync<AscServiceTicketCustomerEntity>(AscServiceTicketCustomerQueries.GetAscServiceTicketCustomerContactedById, sp_params);

            List<AscServiceTicketCustomerEntity> STClist = new List<AscServiceTicketCustomerEntity>();
            AscServiceTicketCustomerEntity ObjSTC = null;

            if (lstASCTCR != null)
            {
                foreach (var itemldp in lstASCTCR)
                {

                    ObjSTC = new AscServiceTicketCustomerEntity();
                    ObjSTC.AscCustomerContactedId = itemldp.AscCustomerContactedId;
                    ObjSTC.ServiceTicketId = itemldp.ServiceTicketId;
                    ObjSTC.ComplainType = itemldp.ComplainType;
                    ObjSTC.ContactDate = itemldp.ContactDate;
                    ObjSTC.SerialNo = itemldp.SerialNo;
                    ObjSTC.ProductCode = itemldp.ProductCode;
                    ObjSTC.InvoiceDate = itemldp.InvoiceDate;
                    ObjSTC.InvoiceNo = itemldp.InvoiceNo;
                    ObjSTC.Remarks = itemldp.Remarks;
                    ObjSTC.ServiceRequestSubStatusId = itemldp.ServiceRequestSubStatusId;
                    ObjSTC.ServiceRequestCustStatusid = itemldp.ServiceRequestCustStatusid;
                    ObjSTC.ProductRquestDate = itemldp.ProductRquestDate;
                    ObjSTC.TechnicianId = itemldp.TechnicianId;
                    ObjSTC.WarrantyDateStatus = itemldp.WarrantyDateStatus;
                    ObjSTC.InvoiceDateStatus = itemldp.InvoiceDateStatus;
                    ObjSTC.AppointmentTime = itemldp.AppointmentTime;


                    STClist.Add(ObjSTC);
                }
            }

            var paraPL = new DynamicParameters();
            paraPL.Add("@ServiceTicketId", ServiceTicketId);

            var lstSVPRASC = await _ascServiceTicketCustomerRepository.GetAllAsync<ASCSiteVisitAndProductReceivedEntity>(AscServiceTicketCustomerQueries.GetAscServiceTicketActivitiesGetById, paraPL);

            List<ASCSiteVisitAndProductReceivedEntity> SVPRASClist = new List<ASCSiteVisitAndProductReceivedEntity>();
            ASCSiteVisitAndProductReceivedEntity ObjASTC = null;
            if (lstSVPRASC != null)
            {

                foreach (var itemldpA in lstSVPRASC)
                {

                    ObjASTC = new ASCSiteVisitAndProductReceivedEntity();
                    ObjASTC.AscActivitiesId = itemldpA.AscActivitiesId;
                    ObjASTC.ServiceTicketId = itemldpA.ServiceTicketId;
                    ObjASTC.ComplainType = itemldpA.ComplainType;
                    ObjASTC.Date = itemldpA.Date;
                    ObjASTC.SubStatusName = itemldpA.SubStatusName;
                    ObjASTC.StatusName = itemldpA.StatusName;
                    ObjASTC.ActivityName = itemldpA.ActivityName;
                    ObjASTC.IsSubmited = itemldpA.IsSubmited;
                    ObjASTC.Remarks = itemldpA.Remarks;
                    SVPRASClist.Add(ObjASTC);
                }

            }


            //------------------------
            var paraFir = new DynamicParameters();
            paraFir.Add("@ServiceTicketId", ServiceTicketId);

            var lstSTFir = await _ascServiceTicketCustomerRepository.GetAllAsync<AscServiceTicketFirDisplayEntity>(AscServiceTicketCustomerQueries.GetAscServiceTicketFirGetById, paraFir);

            List<AscServiceTicketFirDisplayEntity> STFirlist = new List<AscServiceTicketFirDisplayEntity>();
            AscServiceTicketFirDisplayEntity ObjStFir = null;
            if (lstSTFir != null)
            {

                foreach (var itemFir in lstSTFir)
                {

                    ObjStFir = new AscServiceTicketFirDisplayEntity();
                    ObjStFir.ServiceTicketId = itemFir.ServiceTicketId;
                    ObjStFir.SerialNo = itemFir.SerialNo;
                    ObjStFir.ProductCode = itemFir.ProductCode;
                    ObjStFir.BatchCode = itemFir.BatchCode;
                    ObjStFir.ProductGroupName = itemFir.ProductGroupName;
                    ObjStFir.DivisionName = itemFir.DivisionName;
                    ObjStFir.ProductLineName = itemFir.ProductLineName;
                    ObjStFir.ProductDescription = itemFir.ProductDescription;
                    ObjStFir.InvoiceNo = itemFir.InvoiceNo;
                    ObjStFir.InvoiceDate = itemFir.InvoiceDate;
                    ObjStFir.FailureObservation = itemFir.FailureObservation;
                    ObjStFir.DetailsOfWorkDone = itemFir.DetailsOfWorkDone;
                    ObjStFir.ReplacementTagApplied = itemFir.ReplacementTagApplied;
                    ObjStFir.ClosureStatusName = itemFir.ClosureStatusName;
                    ObjStFir.TypeOfWorkDoneId = itemFir.TypeOfWorkDoneId;
                    ObjStFir.ReplacementTagFile = itemFir.ReplacementTagFile;
                    ObjStFir.Frame = itemFir.Frame;
                    ObjStFir.Kva = itemFir.Kva;
                    ObjStFir.Hp = itemFir.Hp;
                    ObjStFir.warrantyDate = itemFir.warrantyDate;
                    ObjStFir.InvoiceFile = itemFir.InvoiceFile;
                    ObjStFir.TypeOfApplication = itemFir.TypeOfApplication;
                    ObjStFir.NoOfHours = itemFir.NoOfHours;
                    ObjStFir.ManufacturingDate = itemFir.ManufacturingDate;
                    ObjStFir.DateOfDispatch = itemFir.DateOfDispatch;
                    ObjStFir.DateOfCommissioning = itemFir.DateOfCommissioning;
                    ObjStFir.FailureReportedDate = itemFir.FailureReportedDate;
                    ObjStFir.ProductFailureDate = itemFir.ProductFailureDate;
                    ObjStFir.FrameSizeId = itemFir.FrameSizeId;
                    ObjStFir.NoOfVisit = itemFir.NoOfVisit;


                    var paraFirDef = new DynamicParameters();
                    paraFirDef.Add("@ServiceTicketId", ServiceTicketId);
                    var lstSTFirDef = await _ascServiceTicketCustomerRepository.GetAllAsync<FIRDefectListDisplayEntity>(AscServiceTicketCustomerQueries.GetAscServiceTicketDefectFIRGetById, paraFirDef);

                    List<FIRDefectListDisplayEntity> STFirDeflist = new List<FIRDefectListDisplayEntity>();
                    FIRDefectListDisplayEntity ObjStFirdef = null;

                    if (lstSTFirDef != null)
                    {

                        foreach (var itemFirdef in lstSTFirDef)
                        {
                            ObjStFirdef = new FIRDefectListDisplayEntity();
                            ObjStFirdef.FIRDefectId = itemFirdef.FIRDefectId;
                            ObjStFirdef.defectCategoryItem = itemFirdef.defectCategoryItem;
                            ObjStFirdef.defectItem = itemFirdef.defectItem;
                            STFirDeflist.Add(ObjStFirdef);
                        }
                    }


                    var paraFirSP = new DynamicParameters();
                    paraFirSP.Add("@ServiceTicketId", ServiceTicketId);
                    var lstSTFirSP = await _ascServiceTicketCustomerRepository.GetAllAsync<SpareDetailsDisplayEntity>(AscServiceTicketCustomerQueries.GetAscServiceTicketSpareFIRGetById, paraFirSP);

                    List<SpareDetailsDisplayEntity> STFirSPlist = new List<SpareDetailsDisplayEntity>();
                    SpareDetailsDisplayEntity ObjStFirSP = null;

                    if (lstSTFirSP != null)
                    {
                        foreach (var itemFirSp in lstSTFirSP)
                        {
                            ObjStFirSP = new SpareDetailsDisplayEntity();

                            ObjStFirSP.serialNumbers = itemFirSp.serialNumbers;
                            ObjStFirSP.SpareName = itemFirSp.SpareName;
                            ObjStFirSP.quantity = itemFirSp.quantity;
                            ObjStFirSP.Remarks = itemFirSp.Remarks;
                            ObjStFirSP.SpareCost = itemFirSp.SpareCost;
                            STFirSPlist.Add(ObjStFirSP);
                        }
                    }

                    ObjStFir.DefectList = STFirDeflist;
                    ObjStFir.Sparelist = STFirSPlist;


                    STFirlist.Add(ObjStFir);
                }

            }

            //-------------

            ObjASC.AscServiceTicketCustomer = STClist;
            ObjASC.ASCSiteVisitAndProductReceived = SVPRASClist;

            ObjASC.AscServiceTicketFirlist = STFirlist;

            return ObjASC;
        }


        public async Task<ServiceTicketTaskDetailsReportEntity> GetServiceTicketTaskDetailsTicketHistoryByIdAsync(int? ServiceTicketId)
        {
            ServiceTicketTaskDetailsReportEntity ObjASC = null;
            ObjASC = new ServiceTicketTaskDetailsReportEntity();
            ObjASC.ServiceTicketId = ServiceTicketId.ToString();
            ObjASC.ServiceTicketNo = "1";


            var sp_paramsPI = new DynamicParameters();
            sp_paramsPI.Add("@ServiceTicketId", ServiceTicketId);
            var lstProInfo = await _ascServiceTicketCustomerRepository.GetAllAsync<AscServiceTicketInfoReportEntity>(AscServiceTicketCustomerQueries.GetServiceTicketInfoGet, sp_paramsPI);

            List<AscServiceTicketInfoReportEntity> PInfolist = new List<AscServiceTicketInfoReportEntity>();
            AscServiceTicketInfoReportEntity ObjPI = null;

            if (lstProInfo != null)
            {
                foreach (var itemldp in lstProInfo)
                {

                    ObjPI = new AscServiceTicketInfoReportEntity();
                    ObjPI.ProductCode = itemldp.ProductCode;
                    ObjPI.InvoiceDate = itemldp.InvoiceDate;
                    ObjPI.InvoiceNo = itemldp.InvoiceNo;
                    ObjPI.Frame = itemldp.Frame;
                    ObjPI.SerialNo = itemldp.SerialNo;
                    ObjPI.KW = itemldp.KW;
                    ObjPI.KVA = itemldp.KVA;
                    ObjPI.EFFE = itemldp.EFFE;
                    ObjPI.FLPS = itemldp.FLPS;
                    ObjPI.HP = itemldp.HP;
                    ObjPI.ProductName = itemldp.ProductName;
                    ObjPI.ProductLineName = itemldp.ProductLineName;
                    ObjPI.ProductGroupName = itemldp.ProductGroupName;
                    ObjPI.InvoiceFilePath = itemldp.InvoiceFilePath;
                    ObjPI.DivisionName = itemldp.DivisionName;
                    ObjPI.BatchStartDate = itemldp.BatchStartDate;
                    ObjPI.BatchEndDate = itemldp.BatchEndDate;
                    ObjPI.ManufacturingDate = itemldp.ManufacturingDate;
                    ObjPI.DateOfDispatch = itemldp.DateOfDispatch;
                    ObjPI.DateOfCommissioning = itemldp.DateOfCommissioning;
                    ObjPI.ProductFailureDate = itemldp.ProductFailureDate;
                    ObjPI.CustomerName = itemldp.CustomerName;
                    ObjPI.ContactPerson = itemldp.ContactPerson;
                    ObjPI.PrimaryMobileNo = itemldp.PrimaryMobileNo;
                    ObjPI.EmailId = itemldp.EmailId;
                    ObjPI.AltContactNo = itemldp.AltContactNo;
                    ObjPI.SiteAddress = itemldp.SiteAddress;
                    ObjPI.BranchName = itemldp.BranchName;
                    ObjPI.DefectName = itemldp.DefectName;
                    ObjPI.RequestDate = itemldp.RequestDate;
                    ObjPI.ASCName = itemldp.ASCName;
                    ObjPI.ASMName = itemldp.ASMName;
                    ObjPI.Distance = itemldp.Distance;
                    ObjPI.ServiceTicketNumber = itemldp.ServiceTicketNumber;
                    ObjPI.TicketStatusName = itemldp.TicketStatusName;

                    ObjPI.SourceName = itemldp.SourceName;
                    ObjPI.SourceTypeName = itemldp.SourceTypeName;
                    ObjPI.CallModeName = itemldp.CallModeName;
                    ObjPI.WarrantyDateStatus = itemldp.WarrantyDateStatus;
                    ObjPI.InvoiceDateStatus = itemldp.InvoiceDateStatus;
                    ObjPI.ActualStatusOfComplaint = itemldp.ActualStatusOfComplaint;
                    ObjPI.PendingWithWhom = itemldp.PendingWithWhom;

                    ObjPI.ActionRequired = itemldp.ActionRequired;
                    ObjPI.PendencyRemarks = itemldp.PendencyRemarks;
                    ObjPI.SpecialApprovalStatus = itemldp.SpecialApprovalStatus;
                    ObjPI.PendencyReasonUpdatedOn = itemldp.PendencyReasonUpdatedOn;
                    ObjPI.BusinessCall = itemldp.BusinessCall;
                    ObjPI.UserType = itemldp.UserType;
                    ObjPI.HappyCode = itemldp.HappyCode;
                    ObjPI.ReplacementTag = itemldp.ReplacementTag;
                    PInfolist.Add(ObjPI);
                }
            }


            var sp_paraAStstus = new DynamicParameters();
            sp_paraAStstus.Add("@ServiceTicketId", ServiceTicketId);
            var lstACStatus = await _ascServiceTicketCustomerRepository.GetAllAsync<AscServiceTicketActivitiesEntity>(AscServiceTicketCustomerQueries.GetServiceTicketActivitiesHistory, sp_paraAStstus);

            List<AscServiceTicketActivitiesEntity> ACStatuslist = new List<AscServiceTicketActivitiesEntity>();
            AscServiceTicketActivitiesEntity ObjACStstus = null;

            if (lstACStatus != null)
            {
                foreach (var itemldp1 in lstACStatus)
                {

                    ObjACStstus = new AscServiceTicketActivitiesEntity();
                    ObjACStstus.UserName = itemldp1.UserName;
                    ObjACStstus.StatusName = itemldp1.StatusName;
                    ObjACStstus.CreateDate = itemldp1.CreateDate;
                    ObjACStstus.Remarks = itemldp1.Remarks;
                    ObjACStstus.TypeOfSteps = itemldp1.TypeOfSteps;

                    ACStatuslist.Add(ObjACStstus);
                }
            }




            var sp_params = new DynamicParameters();
            sp_params.Add("@ServiceTicketId", ServiceTicketId);
            var lstASCTCR = await _ascServiceTicketCustomerRepository.GetAllAsync<AscServiceTicketCustomerReportEntity>(AscServiceTicketCustomerQueries.GetServiceTicketCustomerContactedTicketHistory, sp_params);

            List<AscServiceTicketCustomerReportEntity> STClist = new List<AscServiceTicketCustomerReportEntity>();
            AscServiceTicketCustomerReportEntity ObjSTC = null;

            if (lstASCTCR != null)
            {
                foreach (var itemldp in lstASCTCR)
                {

                    ObjSTC = new AscServiceTicketCustomerReportEntity();
                    ObjSTC.AscCustomerContactedId = itemldp.AscCustomerContactedId;
                    ObjSTC.ServiceTicketId = itemldp.ServiceTicketId;
                    ObjSTC.ComplainType = itemldp.ComplainType;
                    ObjSTC.ContactDate = itemldp.ContactDate;
                    ObjSTC.STSubStatusName = itemldp.STSubStatusName;
                    ObjSTC.ServiceTicketStatusName = itemldp.ServiceTicketStatusName;
                    ObjSTC.TechnicianName = itemldp.TechnicianName;
                    ObjSTC.ApprovedName = itemldp.ApprovedName;
                    ObjSTC.Remarks = itemldp.Remarks;
                    ObjSTC.ApprovedDate = itemldp.ApprovedDate;
                    ObjSTC.ApprovedComments = itemldp.ApprovedComments;
                    ObjSTC.RejectName = itemldp.RejectName;
                    ObjSTC.RejectedDate = itemldp.RejectedDate;
                    ObjSTC.RejectedComments = itemldp.RejectedComments;
                    ObjSTC.CreatedUser = itemldp.CreatedUser;
                    ObjSTC.AppointmentTime = itemldp.AppointmentTime;
                    ObjSTC.CreatedOn = itemldp.CreatedOn;
                    ObjSTC.VisitDate = itemldp.VisitDate;

                    STClist.Add(ObjSTC);
                }
            }

            var paraPL = new DynamicParameters();
            paraPL.Add("@ServiceTicketId", ServiceTicketId);

            var lstSVPRASC = await _ascServiceTicketCustomerRepository.GetAllAsync<ASCSiteVisitAndProductReceivedEntity>(AscServiceTicketCustomerQueries.GetAscServiceTicketActivitiesGetById, paraPL);

            List<ASCSiteVisitAndProductReceivedEntity> SVPRASClist = new List<ASCSiteVisitAndProductReceivedEntity>();
            ASCSiteVisitAndProductReceivedEntity ObjASTC = null;
            if (lstSVPRASC != null)
            {

                foreach (var itemldpA in lstSVPRASC)
                {

                    ObjASTC = new ASCSiteVisitAndProductReceivedEntity();
                    ObjASTC.AscActivitiesId = itemldpA.AscActivitiesId;
                    ObjASTC.ServiceTicketId = itemldpA.ServiceTicketId;
                    ObjASTC.ComplainType = itemldpA.ComplainType;
                    ObjASTC.Date = itemldpA.Date;
                    ObjASTC.SubStatusName = itemldpA.SubStatusName;
                    ObjASTC.StatusName = itemldpA.StatusName;
                    ObjASTC.ActivityName = itemldpA.ActivityName;
                    ObjASTC.IsSubmited = itemldpA.IsSubmited;
                    ObjASTC.Remarks = itemldpA.Remarks;
                    SVPRASClist.Add(ObjASTC);
                }

            }

            ////--------------------
            var sp_paramsPI1 = new DynamicParameters();
            sp_paramsPI1.Add("@ServiceTicketId", ServiceTicketId);
            var lstProInfo1 = await _ascServiceTicketCustomerRepository.GetAllAsync<ServiceTicketPendencyReasonHistoryEntity>(AscServiceTicketCustomerQueries.GetServiceTicketPendencyInfoInfoGet, sp_paramsPI1);

            List<ServiceTicketPendencyReasonHistoryEntity> PInfolist1 = new List<ServiceTicketPendencyReasonHistoryEntity>();
            ServiceTicketPendencyReasonHistoryEntity ObjPI1 = null;

            if (lstProInfo1 != null)
            {
                foreach (var itemldp1 in lstProInfo1)
                {
                    ObjPI1 = new ServiceTicketPendencyReasonHistoryEntity();
                    ObjPI1.ActualStatusOfComplaint = itemldp1.ActualStatusOfComplaint;
                    ObjPI1.PendingWithWhom = itemldp1.PendingWithWhom;
                    ObjPI1.PendencyReasonUpdatedOn = itemldp1.PendencyReasonUpdatedOn;
                    ObjPI1.PendencyRemarks = itemldp1.PendencyRemarks;

                    PInfolist1.Add(ObjPI1);
                }
            }
            //------------------------
            var paraFir = new DynamicParameters();
            paraFir.Add("@ServiceTicketId", ServiceTicketId);

            var lstSTFir = await _ascServiceTicketCustomerRepository.GetAllAsync<AscServiceTicketFirDisplayEntity>(AscServiceTicketCustomerQueries.GetAscServiceTicketFirGetById, paraFir);

            List<AscServiceTicketFirDisplayEntity> STFirlist = new List<AscServiceTicketFirDisplayEntity>();

            AscServiceTicketFirDisplayEntity ObjStFir = null;
            if (lstSTFir != null)
            {

                foreach (var itemFir in lstSTFir)
                {

                    ObjStFir = new AscServiceTicketFirDisplayEntity();
                    ObjStFir.ServiceTicketId = itemFir.ServiceTicketId;
                    ObjStFir.SerialNo = itemFir.SerialNo;
                    ObjStFir.ProductCode = itemFir.ProductCode;
                    ObjStFir.BatchCode = itemFir.BatchCode;
                    ObjStFir.ProductGroupName = itemFir.ProductGroupName;
                    ObjStFir.DivisionName = itemFir.DivisionName;
                    ObjStFir.ProductLineName = itemFir.ProductLineName;
                    ObjStFir.ProductDescription = itemFir.ProductDescription;
                    ObjStFir.InvoiceNo = itemFir.InvoiceNo;
                    ObjStFir.InvoiceDate = itemFir.InvoiceDate;
                    ObjStFir.FailureObservation = itemFir.FailureObservation;
                    ObjStFir.DetailsOfWorkDone = itemFir.DetailsOfWorkDone;
                    ObjStFir.ReplacementTagApplied = itemFir.ReplacementTagApplied;
                    ObjStFir.ClosureStatusName = itemFir.ClosureStatusName;
                    ObjStFir.TypeOfWorkDoneId = itemFir.TypeOfWorkDoneId;
                    ObjStFir.ReplacementTagFile = itemFir.ReplacementTagFile;
                    ObjStFir.Frame = itemFir.Frame;
                    ObjStFir.Kva = itemFir.Kva;
                    ObjStFir.Hp = itemFir.Hp;
                    ObjStFir.warrantyDate = itemFir.warrantyDate;
                    ObjStFir.InvoiceFile = itemFir.InvoiceFile;
                    ObjStFir.TypeOfApplication = itemFir.TypeOfApplication;
                    ObjStFir.NoOfHours = itemFir.NoOfHours;
                    ObjStFir.ManufacturingDate = itemFir.ManufacturingDate;
                    ObjStFir.DateOfDispatch = itemFir.DateOfDispatch;
                    ObjStFir.DateOfCommissioning = itemFir.DateOfCommissioning;
                    ObjStFir.FailureReportedDate = itemFir.FailureReportedDate;
                    ObjStFir.ProductFailureDate = itemFir.ProductFailureDate;
                    ObjStFir.FrameSizeId = itemFir.FrameSizeId;

                    var paraFirDef = new DynamicParameters();
                    paraFirDef.Add("@ServiceTicketId", ServiceTicketId);
                    var lstSTFirDef = await _ascServiceTicketCustomerRepository.GetAllAsync<FIRDefectListDisplayEntity>(AscServiceTicketCustomerQueries.GetAscServiceTicketDefectFIRGetById, paraFirDef);

                    List<FIRDefectListDisplayEntity> STFirDeflist = new List<FIRDefectListDisplayEntity>();
                    FIRDefectListDisplayEntity ObjStFirdef = null;

                    if (lstSTFirDef != null)
                    {

                        foreach (var itemFirdef in lstSTFirDef)
                        {
                            ObjStFirdef = new FIRDefectListDisplayEntity();

                            ObjStFirdef.defectCategoryItem = itemFirdef.defectCategoryItem;
                            ObjStFirdef.defectItem = itemFirdef.defectItem;
                            STFirDeflist.Add(ObjStFirdef);
                        }
                    }


                    var paraFirSP = new DynamicParameters();
                    paraFirSP.Add("@ServiceTicketId", ServiceTicketId);
                    var lstSTFirSP = await _ascServiceTicketCustomerRepository.GetAllAsync<SpareDetailsDisplayEntity>(AscServiceTicketCustomerQueries.GetAscServiceTicketSpareFIRGetById, paraFirSP);

                    List<SpareDetailsDisplayEntity> STFirSPlist = new List<SpareDetailsDisplayEntity>();
                    SpareDetailsDisplayEntity ObjStFirSP = null;

                    if (lstSTFirSP != null)
                    {

                        foreach (var itemFirSp in lstSTFirSP)
                        {
                            ObjStFirSP = new SpareDetailsDisplayEntity();

                            ObjStFirSP.serialNumbers = itemFirSp.serialNumbers;
                            ObjStFirSP.SpareName = itemFirSp.SpareName;
                            ObjStFirSP.quantity = itemFirSp.quantity;
                            ObjStFirSP.SpareCost = itemFirSp.SpareCost;
                            STFirSPlist.Add(ObjStFirSP);
                        }
                    }

                    ObjStFir.DefectList = STFirDeflist;
                    ObjStFir.Sparelist = STFirSPlist;


                    STFirlist.Add(ObjStFir);
                }

            }

            //lstProInfo

            ObjASC.AscServiceTicketCustomer = STClist;
            ObjASC.ASCSiteVisitAndProductReceived = SVPRASClist;
            ObjASC.ServiceTicketInfo = PInfolist;
            ObjASC.AscServiceTicketFirlist = STFirlist;
            ObjASC.ServiceTicketActivities = ACStatuslist;
            ObjASC.AscServiceTicketPendencyHistory = PInfolist1;
            return ObjASC;
        }




        public async Task<int?> UpdateReassignedTechnicianerviceTicketAsync(int serviceTicketId, int? TechnicianId, string? Remark, string? AssignDate, string UserId, string? AppointmentTime)
        {
            var para = new DynamicParameters();
            para.Add("@ServiceTicketId", serviceTicketId);
            para.Add("@TechnicianId", TechnicianId);
            para.Add("@Remark", Remark);
            para.Add("@AssignDate", AssignDate);
            para.Add("@UserID", UserId);
            para.Add("@AppointmentTime", AppointmentTime);
            var result = await _ascServiceTicketCustomerRepository.ExecuteScalarAsync<int?>(ServiceTicketQueries.UpdateReassignedTechnicianServiceTicket, para);
            return result;
        }

        public async Task<int?> UpdateAssignedASCServiceAsync(ServiceTicketASCCodeEntity objAsc)
        {
            var para = new DynamicParameters();
            para.Add("@ServiceTicketId", objAsc.ServiceTicketId);
            para.Add("@TicketAssignedASCCode", objAsc.TicketAssignedASCCode);
            para.Add("@Remark", objAsc.Remark);
            para.Add("@UserId", objAsc.UserId);
            var result = await _ascServiceTicketCustomerRepository.ExecuteScalarAsync<int?>(ServiceTicketQueries.UpdateAssignedASCServiceTicket, para);
            return result;
        }

        public async Task<string?> UpsertAscServiceTicketActivity(string? userId, AscServiceTicketActivityEntity ObjAscActivity)
        {
            var para = new DynamicParameters();
            para.Add("@AscActivitiesId", ObjAscActivity.AscActivitiesId);
            para.Add("@ServiceTicketId", ObjAscActivity.ServiceTicketId);
            para.Add("@ComplainType", ObjAscActivity.ComplainType);
            para.Add("@Date", ObjAscActivity.Date);
            para.Add("@TypeOfActivity", ObjAscActivity.TypeOfActivity);
            para.Add("@ActiveStatusId", ObjAscActivity.ActiveStatusId);
            para.Add("@ActivitySubStatusId", ObjAscActivity.ActiveSubStatusId);
            para.Add("@Remarks", ObjAscActivity.@Remarks);
            para.Add("@UserId", userId);

            var result = await _ascServiceTicketCustomerRepository.ExecuteScalarAsync<string?>(ServiceTicketQueries.UpdateAscServiceTicketActivity, para);
            return result;
        }

        public async Task<string?> InsertServiceTicketPendencyReasonAsync(ServiceTicketPendencyReasonEntity pendencyReasonObj)
        {
            var para = new DynamicParameters();
            para.Add("@PendencyReasonId", pendencyReasonObj.PendencyReasonId);
            para.Add("@ServiceTicketId", pendencyReasonObj.ServiceTicketId);
            para.Add("@ActualStatusOfComplaintId", pendencyReasonObj.ActualStatusOfComplaintId);
            para.Add("@PendingWithWhomId", pendencyReasonObj.PendingWithWhomId);
            para.Add("@ActionRequiredId", pendencyReasonObj.ActionRequiredId);
            para.Add("@PendencyRemarks", pendencyReasonObj.PendencyRemarks);
            para.Add("@UserId", pendencyReasonObj.UserId);
            para.Add("@IsActive", pendencyReasonObj.IsActive);
            var result = await _ascServiceTicketCustomerRepository.ExecuteScalarAsync<string?>(ServiceTicketQueries.InsertServiceTicketPendencyReason, para);
            return result;
        }

        public async Task<IList<ServiceTicketPendencyReasonDisplayEntity>> GetAllServiceTicketPendencyReasonAsync(int serviceTicketId)
        {
            var para = new DynamicParameters();
            para.Add("@ServiceTicketId", serviceTicketId);

            var lstPendencyReason = await _ascServiceTicketCustomerRepository.GetAllAsync<ServiceTicketPendencyReasonDisplayEntity>(ServiceTicketQueries.GetAllPendencyReason, para);

            return lstPendencyReason.ToList();
        }

        public async Task<IList<PendingWithWhomEntity>> GetAllSTPendingWithWhomListAsync(int actualStatusOfComplaintId)
        {
            var para = new DynamicParameters();
            para.Add("@ActualStatusOfComplaintId", actualStatusOfComplaintId);

            var STPendingWithWhomLst = await _ascServiceTicketCustomerRepository.GetAllAsync<PendingWithWhomEntity>(ServiceTicketQueries.GetAllSTPendingWithWhom, para);

            return STPendingWithWhomLst.ToList();
        }

        public async Task<IList<PendencyActionRequiredEntity>> GetAllPendencyActionRequiredAsync(int pendingWithWhomId)
        {
            var para = new DynamicParameters();
            para.Add("@PendingWithWhomId", pendingWithWhomId);

            var lstPendencyActionRequired = await _ascServiceTicketCustomerRepository.GetAllAsync<PendencyActionRequiredEntity>(ServiceTicketQueries.GetAllPendencyActionRequired, para);

            return lstPendencyActionRequired.ToList();
        }

        public async Task<int?> UpdateAssignedASMServiceAsync(ServiceTicketASMCodeEntity objAsm, string? UserId)
        {
            var para = new DynamicParameters();
            para.Add("@ServiceTicketId", objAsm.ServiceTicketId);
            para.Add("@TicketAssignedASMCode", objAsm.TicketAssignedASMCode);
            para.Add("@Remark", objAsm.Remark);
            para.Add("@UserId", UserId);
            var result = await _ascServiceTicketCustomerRepository.ExecuteScalarAsync<int?>(ServiceTicketQueries.UpdateAssignedASMServiceTicket, para);
            return result;
        }


        public async Task<int?> UpdateCancelServiceAsync(ServiceTicketCancelEntity objAsm, string? UserId)
        {
            var para = new DynamicParameters();
            para.Add("@ServiceTicketId", objAsm.ServiceTicketId);
            para.Add("@Remarks", objAsm.Remark);
            para.Add("@UserId", UserId);
            var result = await _ascServiceTicketCustomerRepository.ExecuteScalarAsync<int?>(ServiceTicketQueries.UpdateCancelServiceTicket, para);
            return result;
        }

        public async Task<string?> DeleteAscServiceTicketActivityAsync(int AscActivitiesId)
        {
            var para = new DynamicParameters();
            para.Add("@AscActivitiesId", AscActivitiesId);

            return await _ascServiceTicketCustomerRepository.ExecuteScalarAsync<string?>(ServiceTicketQueries.DeleteAscServiceTicketActivity, para);
        }

    }
}
