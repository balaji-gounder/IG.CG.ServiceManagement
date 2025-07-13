using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;
using System.Data;

namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class TicketReportRepository : ITicketReportRepository
    {
        private readonly ISqlDbContext _activityRepository;
        public TicketReportRepository(ISqlDbContext activityRepository)
        {
            _activityRepository = activityRepository;
        }


        public async Task<IList<ClaimApprovalTATReportEntity>> GetAllClaimApprovalTATReportAsync(ReportFilter ReportFilter)
        {
            var para = new DynamicParameters();
            para.Add("@Region", ReportFilter.Region);
            para.Add("@Branch", ReportFilter.Branch);
            para.Add("@ASC", ReportFilter.ASC);
            para.Add("@DivisionCode", ReportFilter.DivisionCode);
            para.Add("@BusinessLine", ReportFilter.BusinessLine);
            para.Add("@ProductLine", ReportFilter.ProductLine);
            para.Add("@CallStage", ReportFilter.CallStage);
            para.Add("@DateType", ReportFilter.DateType);
            para.Add("@FromDate", ReportFilter.FromDate);
            para.Add("@ToDate", ReportFilter.ToDate);
            para.Add("@PageSize", ReportFilter.PageSize);
            para.Add("@PageNumber", ReportFilter.PageNumber);
            para.Add("@UserId", ReportFilter.UserId);
            var lstActivity = await _activityRepository.GetAllAsync<ClaimApprovalTATReportEntity>(ReportQueries.AllClaimApprovalTATReportReport, para);

            return lstActivity.ToList();
        }




        public async Task<IList<ComplaintCancelReportEntity>> GetAllCancelReportTicketAsync(ReportFilter ReportFilter)
        {
            var para = new DynamicParameters();
            para.Add("@Region", ReportFilter.Region);
            para.Add("@Branch", ReportFilter.Branch);
            para.Add("@ASC", ReportFilter.ASC);
            para.Add("@DivisionCode", ReportFilter.DivisionCode);
            para.Add("@BusinessLine", ReportFilter.BusinessLine);
            para.Add("@ProductLine", ReportFilter.ProductLine);
            para.Add("@CallStage", ReportFilter.CallStage);
            para.Add("@DateType", ReportFilter.DateType);
            para.Add("@FromDate", ReportFilter.FromDate);
            para.Add("@ToDate", ReportFilter.ToDate);
            para.Add("@PageSize", ReportFilter.PageSize);
            para.Add("@PageNumber", ReportFilter.PageNumber);
            para.Add("@UserId", ReportFilter.UserId);
            var lstActivity = await _activityRepository.GetAllAsync<ComplaintCancelReportEntity>(ReportQueries.AllCancelTicketReport, para);

            return lstActivity.ToList();
        }



        public async Task<IList<DurationTicketTatDashboardEntity>> GetAllDurationTicketTatDashboardAsync(DurationTicketFilter ReportFilter)
        {
            var para = new DynamicParameters();
            para.Add("@DivCode", ReportFilter.DivCode);
            para.Add("@ProductLineCode", ReportFilter.ProductLineCode);
            para.Add("@FromDate", ReportFilter.FromDate);
            para.Add("@ToDate", ReportFilter.ToDate);
            para.Add("@UserId", ReportFilter.UserId);
            var lstActivity = await _activityRepository.GetAllAsync<DurationTicketTatDashboardEntity>(ReportQueries.DurationTicketTatDashboard, para);

            return lstActivity.ToList();
        }


        public async Task<IList<DurationTicketTatDashboardEntity>> GetAllDurationOpenTicketTatDashboardAsync(DurationTicketFilter ReportFilter)
        {
            var para = new DynamicParameters();
            para.Add("@DivCode", ReportFilter.DivCode);
            para.Add("@ProductLineCode", ReportFilter.ProductLineCode);
            para.Add("@FromDate", ReportFilter.FromDate);
            para.Add("@ToDate", ReportFilter.ToDate);
            para.Add("@UserId", ReportFilter.UserId);
            var lstActivity = await _activityRepository.GetAllAsync<DurationTicketTatDashboardEntity>(ReportQueries.DurationOpenTicketTatDashboard, para);

            return lstActivity.ToList();
        }

        public async Task<IList<AscServiceTicketInfoComplaintReportEntity>> GetAllComplaintReportAsync(ReportFilter ReportFilter)
        {
            var para = new DynamicParameters();
            para.Add("@Region", ReportFilter.Region);
            para.Add("@Branch", ReportFilter.Branch);
            para.Add("@ASC", ReportFilter.ASC);
            para.Add("@DivisionCode", ReportFilter.DivisionCode);
            para.Add("@BusinessLine", ReportFilter.BusinessLine);
            para.Add("@ProductLine", ReportFilter.ProductLine);
            para.Add("@CallStage", ReportFilter.CallStage);
            para.Add("@DateType", ReportFilter.DateType);
            para.Add("@FromDate", ReportFilter.FromDate);
            para.Add("@ToDate", ReportFilter.ToDate);
            para.Add("@PageSize", ReportFilter.PageSize);
            para.Add("@PageNumber", ReportFilter.PageNumber);
            para.Add("@UserId", ReportFilter.UserId);
            var lstActivity = await _activityRepository.GetAllAsync<AscServiceTicketInfoComplaintReportEntity>(ReportQueries.AllComplaintReport, para, CommandType.StoredProcedure, 180);

            foreach (var item in lstActivity)
            {
                Console.WriteLine($"Ticket: {item.ServiceTicketNumber}, WebClosureDate: {item.WebClosureDate}");
            }


            return lstActivity.ToList();
        }

        public async Task<IList<ServiceTicketDefectReportEntity>> GetAllDefectReportAsync(ReportFilter ReportFilter)
        {
            //ServiceTicketDefectReportEntity ObjASC = null;
            //ObjASC = new ServiceTicketDefectReportEntity();

            List<ServiceTicketDefectReportEntity> ObjASC = new List<ServiceTicketDefectReportEntity>();
            ServiceTicketDefectReportEntity ObjDef = new ServiceTicketDefectReportEntity();

            var para = new DynamicParameters();
            para.Add("@Region", ReportFilter.Region);
            para.Add("@Branch", ReportFilter.Branch);
            para.Add("@ASC", ReportFilter.ASC);
            para.Add("@DivisionCode", ReportFilter.DivisionCode);
            para.Add("@BusinessLine", ReportFilter.BusinessLine);
            para.Add("@ProductLine", ReportFilter.ProductLine);
            para.Add("@CallStage", ReportFilter.CallStage);
            para.Add("@DateType", ReportFilter.DateType);
            para.Add("@FromDate", ReportFilter.FromDate);
            para.Add("@ToDate", ReportFilter.ToDate);
            para.Add("@PageSize", ReportFilter.PageSize);
            para.Add("@PageNumber", ReportFilter.PageNumber);
            para.Add("@UserId", ReportFilter.UserId);
            var lstProInfo = await _activityRepository.GetAllAsync<AscServiceTicketInfoDefetReportEntity>(ReportQueries.AllComplaintDefectReport, para, CommandType.StoredProcedure, 180);

            List<AscServiceTicketInfoDefetReportEntity> PInfolist = new List<AscServiceTicketInfoDefetReportEntity>();
            AscServiceTicketInfoDefetReportEntity ObjPI = null;

            if (lstProInfo != null)
            {
                foreach (var itemldp in lstProInfo)
                {
                    ObjPI = new AscServiceTicketInfoDefetReportEntity();
                    ObjPI.ProductCode = itemldp.ProductCode;
                    ObjPI.BatchNo = itemldp.BatchNo;
                    ObjPI.NoOfdefect = itemldp.NoOfdefect;
                    ObjPI.BatchNo = itemldp.BatchNo;
                    ObjPI.Distanc = itemldp.Distanc;
                    ObjPI.InvoiceNo = itemldp.InvoiceNo;
                    ObjPI.InvoiceDate = itemldp.InvoiceDate;
                    ObjPI.NoOfdefect = itemldp.NoOfdefect;
                    ObjPI.SerialNo = itemldp.SerialNo;
                    ObjPI.ProductName = itemldp.ProductName;
                    ObjPI.ProductLineName = itemldp.ProductLineName;
                    ObjPI.ProductGroupName = itemldp.ProductGroupName;
                    ObjPI.DivisionName = itemldp.DivisionName;
                    ObjPI.CustomerName = itemldp.CustomerName;
                    ObjPI.ContactPerson = itemldp.ContactPerson;
                    ObjPI.PrimaryMobileNo = itemldp.PrimaryMobileNo;
                    ObjPI.SiteAddress = itemldp.SiteAddress;
                    ObjPI.BranchName = itemldp.BranchName;
                    ObjPI.ASCName = itemldp.ASCName;
                    ObjPI.ServiceTicketNumber = itemldp.ServiceTicketNumber;
                    ObjPI.WarrantyDateStatus = itemldp.WarrantyDateStatus;
                    ObjPI.BusinessCall = itemldp.BusinessCall;
                    ObjPI.TotalRows = itemldp.TotalRows;
                    ObjPI.LoggedDate = itemldp.LoggedDate;
                    ObjPI.LoggedMonth = itemldp.LoggedMonth;
                    ObjPI.LoggedTime = itemldp.LoggedTime;
                    ObjPI.ComplaintAgedays = itemldp.ComplaintAgedays;
                    ObjPI.PinCode = itemldp.PinCode;
                    ObjPI.StateName = itemldp.StateName;
                    ObjPI.CityName = itemldp.CityName;
                    ObjPI.ApplicationType = itemldp.ApplicationType;
                    ObjPI.ServiceCost = itemldp.ServiceCost;
                    ObjPI.SpecialApprovalCost = itemldp.SpecialApprovalCost;
                    ObjPI.MaterialCost = itemldp.MaterialCost;
                    ObjPI.TotalCost = itemldp.TotalCost;
                    ObjPI.ReplacementTagApplied = itemldp.ReplacementTagApplied;
                    ObjPI.ClosureRemarks = itemldp.ClosureRemarks;
                    ObjPI.ClosureTat = itemldp.ClosureTat;
                    ObjPI.OEMName = itemldp.OEMName;
                    ObjPI.DealerName = itemldp.DealerName;
                    ObjPI.VendorName = itemldp.VendorName;
                    ObjPI.RegionName = itemldp.RegionName;
                    ObjPI.NatureOfComplaint = itemldp.NatureOfComplaint;
                    ObjPI.DistanceType = itemldp.DistanceType;
                    ObjPI.TechnicianName = itemldp.TechnicianName;
                    ObjPI.InvoiceDateStatus = itemldp.InvoiceDateStatus;
                    ObjPI.WebClosureDate = itemldp.WebClosureDate;
                    ObjPI.DefectName1 = itemldp.DefectName1;
                    ObjPI.DefectName2 = itemldp.DefectName2;
                    ObjPI.DefectName3 = itemldp.DefectName3;
                    ObjPI.DefectName4 = itemldp.DefectName4;
                    ObjPI.DefectCategoryName1 = itemldp.DefectCategoryName1;
                    ObjPI.DefectCategoryName2 = itemldp.DefectCategoryName2;
                    ObjPI.DefectCategoryName3 = itemldp.DefectCategoryName3;
                    ObjPI.DefectCategoryName4 = itemldp.DefectCategoryName4;
                    ObjPI.PartConsumptionCost = itemldp.PartConsumptionCost;
                    ObjPI.ClosureStstaus = itemldp.ClosureStstaus;
                    ObjPI.IBNNumber = itemldp.IBNNumber;
                    PInfolist.Add(ObjPI);
                }
                ObjDef.AscServiceTicketlist = PInfolist;
            }


            //------------------------
            var paradef = new DynamicParameters();
            paradef.Add("@Region", ReportFilter.Region);
            paradef.Add("@Branch", ReportFilter.Branch);
            paradef.Add("@ASC", ReportFilter.ASC);
            paradef.Add("@DivisionCode", ReportFilter.DivisionCode);
            paradef.Add("@BusinessLine", ReportFilter.BusinessLine);
            paradef.Add("@ProductLine", ReportFilter.ProductLine);
            paradef.Add("@CallStage", ReportFilter.CallStage);
            paradef.Add("@DateType", ReportFilter.DateType);
            paradef.Add("@FromDate", ReportFilter.FromDate);
            paradef.Add("@ToDate", ReportFilter.ToDate);
            paradef.Add("@UserId", ReportFilter.UserId);
            var lstSTFir = await _activityRepository.GetAllAsync<AscDefectlistEntity>(ReportQueries.AllDefectReport, paradef);

            List<AscDefectlistEntity> STDectlist = new List<AscDefectlistEntity>();

            AscDefectlistEntity Objdef = null;
            if (lstSTFir != null)
            {

                foreach (var itemFir in lstSTFir)
                {

                    Objdef = new AscDefectlistEntity();
                    Objdef.DivisionName = itemFir.DivisionName;
                    Objdef.ProductLineName = itemFir.ProductLineName;
                    Objdef.DefectCategoryName = itemFir.DefectCategoryName;
                    Objdef.DefectDesc = itemFir.DefectDesc;
                    Objdef.DefectCount = itemFir.DefectCount;

                    STDectlist.Add(Objdef);
                }
                ObjDef.AscDefectlist = STDectlist;
            }

            ////lstProInfo

            ////ObjASC.AscDefectlist. = STDectlist.ToList;
            ////ObjASC.AscServiceTicketlist = PInfolist;

            //ObjASC.Add()

            ObjASC.Add(ObjDef);
            return ObjASC;
        }



        public async Task<IList<RepeatedTicketsReportEntity>> GetAllRepeatedTicketsReportAsync(ReportFilter ReportFilter)
        {
            //ServiceTicketDefectReportEntity ObjASC = null;
            //ObjASC = new ServiceTicketDefectReportEntity();


            List<RepeatedTicketsReportEntity> ObjRepL = new List<RepeatedTicketsReportEntity>();
            RepeatedTicketsReportEntity ObjRep = new RepeatedTicketsReportEntity();


            var para = new DynamicParameters();
            para.Add("@Region", ReportFilter.Region);
            para.Add("@Branch", ReportFilter.Branch);
            para.Add("@ASC", ReportFilter.ASC);
            para.Add("@DivisionCode", ReportFilter.DivisionCode);
            para.Add("@BusinessLine", ReportFilter.BusinessLine);
            para.Add("@ProductLine", ReportFilter.ProductLine);
            para.Add("@CallStage", ReportFilter.CallStage);
            para.Add("@DateType", ReportFilter.DateType);
            para.Add("@FromDate", ReportFilter.FromDate);
            para.Add("@ToDate", ReportFilter.ToDate);
            para.Add("@PageSize", ReportFilter.PageSize);
            para.Add("@PageNumber", ReportFilter.PageNumber);
            para.Add("@UserId", ReportFilter.UserId);
            var lstProInfo = await _activityRepository.GetAllAsync<RepeatedTicketsCallsEntity>(ReportQueries.AllRepeatedTicketsReport, para);



            List<RepeatedTicketsCallsEntity> PInfolist = new List<RepeatedTicketsCallsEntity>();
            RepeatedTicketsCallsEntity ObjPI = null;

            if (lstProInfo != null)
            {
                foreach (var itemldp in lstProInfo)
                {

                    ObjPI = new RepeatedTicketsCallsEntity();
                    ObjPI.ProductCode = itemldp.ProductCode;
                    ObjPI.TotalRows = itemldp.TotalRows;
                    ObjPI.Region = itemldp.Region;

                    ObjPI.Branch = itemldp.Branch;
                    ObjPI.ProductDivision = itemldp.ProductDivision;
                    ObjPI.ProductLine = itemldp.ProductLine;

                    ObjPI.ProductGroup = itemldp.ProductGroup;


                    ObjPI.SerialNo = itemldp.SerialNo;

                    ObjPI.RepeatedCalls = itemldp.RepeatedCalls;
                    ObjPI.CustomerMobileNumber = itemldp.CustomerMobileNumber;
                    ObjPI.TicketNo = itemldp.TicketNo;

                    ObjPI.TicketCreationDate = itemldp.TicketCreationDate;

                    ObjPI.TicketClosureDate = itemldp.TicketClosureDate;
                    ObjPI.AssignedASC = itemldp.AssignedASC;
                    ObjPI.MobileNumberDiscripancy = itemldp.MobileNumberDiscripancy;


                    PInfolist.Add(ObjPI);
                }
                ObjRep.RepeatedTicketsCallslist = PInfolist;


            }


            //------------------------
            var paradef = new DynamicParameters();
            paradef.Add("@Region", ReportFilter.Region);
            paradef.Add("@Branch", ReportFilter.Branch);
            paradef.Add("@ASC", ReportFilter.ASC);
            paradef.Add("@DivisionCode", ReportFilter.DivisionCode);
            paradef.Add("@BusinessLine", ReportFilter.BusinessLine);
            paradef.Add("@ProductLine", ReportFilter.ProductLine);
            paradef.Add("@CallStage", ReportFilter.CallStage);
            paradef.Add("@DateType", ReportFilter.DateType);
            paradef.Add("@FromDate", ReportFilter.FromDate);
            paradef.Add("@ToDate", ReportFilter.ToDate);
            paradef.Add("@PageSize", ReportFilter.PageSize);
            paradef.Add("@PageNumber", ReportFilter.PageNumber);
            paradef.Add("@UserId", ReportFilter.UserId);
            var lstSTFir = await _activityRepository.GetAllAsync<RepeatedTicketsCallsSummaryEntity>(ReportQueries.AllRepeatedTicketsSummaryReport, paradef);

            List<RepeatedTicketsCallsSummaryEntity> TREPlist = new List<RepeatedTicketsCallsSummaryEntity>();

            RepeatedTicketsCallsSummaryEntity ObjTRep = null;
            if (lstSTFir != null)
            {

                foreach (var itemFir in lstSTFir)
                {

                    ObjTRep = new RepeatedTicketsCallsSummaryEntity();
                    ObjTRep.ProductCode = itemFir.ProductCode;
                    ObjTRep.TotalRows = itemFir.TotalRows;
                    ObjTRep.Region = itemFir.Region;

                    ObjTRep.Branch = itemFir.Branch;
                    ObjTRep.ProductDivision = itemFir.ProductDivision;
                    ObjTRep.ProductLine = itemFir.ProductLine;

                    ObjTRep.ProductGroup = itemFir.ProductGroup;

                    ObjTRep.SerialNo = itemFir.SerialNo;

                    ObjTRep.RepeatedCalls = itemFir.RepeatedCalls;

                    TREPlist.Add(ObjTRep);
                }
                ObjRep.RepeatedTicketsCallsSummarylist = TREPlist;
            }

            ////lstProInfo

            ////ObjASC.AscDefectlist. = STDectlist.ToList;
            ////ObjASC.AscServiceTicketlist = PInfolist;

            //ObjASC.Add()

            ObjRepL.Add(ObjRep);
            return ObjRepL;
        }



    }
}
