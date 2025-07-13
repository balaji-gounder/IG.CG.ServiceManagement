using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class LeadFollowupRepository : ILeadsFollowupListRepository
    {

        private readonly ISqlDbContext _leadFollowupRepository;
        public LeadFollowupRepository(ISqlDbContext leadFolloupRepository)
        {
            _leadFollowupRepository = leadFolloupRepository;
        }

        public async Task<IList<LeadsFollowupListEntity>> GetAllLeadFollowuplistAsync(LeadFilter leadFilter, string? userId)
        {
            var para = new DynamicParameters();
            para.Add("@BranchCode", leadFilter.BranchCode);
            para.Add("@RegionCode", leadFilter.RegionCode);
            para.Add("@DivisionCode", leadFilter.DivisionCode);
            para.Add("@FromDate", leadFilter.FromDate);
            para.Add("@ToDate", leadFilter.ToDate);
            para.Add("@StatusId", leadFilter.StatusId);
            para.Add("@ActivityStatusId", leadFilter.ActivityStatusId);
            para.Add("@PageSize", leadFilter.PageSize);
            para.Add("@PageNumber", leadFilter.PageNumber);
            para.Add("@UserId", userId);
            para.Add("@IsStatus", leadFilter.IsStatus);

            var lstLead = await _leadFollowupRepository.GetAllAsync<LeadsFollowupListEntity>(LeadQueries.AllLeadsFollowuplist, para);


            List<LeadsFollowupListEntity> Leadlist = new List<LeadsFollowupListEntity>();
            LeadsFollowupListEntity Objlead = null;
            foreach (var item in lstLead)
            {

                Objlead = new LeadsFollowupListEntity();
                Objlead.LeadId = item.LeadId;
                Objlead.LeadsCode = item.LeadsCode;
                Objlead.ServiceTicketNo = item.ServiceTicketNo;
                Objlead.CompanyContactName = item.CompanyContactName;
                Objlead.StatusName = item.StatusName;
                Objlead.CustomerCategoryName = item.CustomerCategoryName;
                Objlead.LeadTypeName = item.LeadTypeName;
                Objlead.CustomerType = item.CustomerType;
                Objlead.LeadDate = item.LeadDate;
                Objlead.Address = item.Address;
                Objlead.NoOfDayold = item.NoOfDayold;
                Objlead.TotalBudget = item.TotalBudget;
                Objlead.NextDateOfFollowup = item.NextDateOfFollowup;
                Objlead.DivisionName = item.DivisionName;
                Objlead.NoOfDayold = item.NoOfDayold;
                Objlead.ContactDetails = item.ContactDetails;
                Objlead.leadStatus = item.leadStatus;
                Objlead.LeadOverDueStatus = item.LeadOverDueStatus;
                Objlead.ExpectedConversionDate = item.ExpectedConversionDate;
                Objlead.ActualQuote = item.ActualQuote;
                Objlead.ReviseQuote = item.ReviseQuote;
                Objlead.RegionName = item.RegionName;
                Objlead.BranchName = item.BranchName;
                Objlead.ActivityRemark = item.ActivityRemark;
                Objlead.ActivityFollowupDate = item.ActivityFollowupDate;
                Objlead.PurchaseNo = item.PurchaseNo;
                Objlead.LostLeadReasonDetails = item.LostLeadReasonDetails;
                Objlead.UserName = item.UserName;

                var paraLC = new DynamicParameters();
                paraLC.Add("@LeadId", item.LeadId);
                var lstleadContact = await _leadFollowupRepository.GetAllAsync<LeadContactEntity>(LeadQueries.LeadsContactList, paraLC);

                List<LeadContactEntity> LeadConlist = new List<LeadContactEntity>();
                LeadContactEntity ObjleadCon = null;

                if (lstleadContact != null)
                {
                    foreach (var itemldp in lstleadContact)
                    {
                        ObjleadCon = new LeadContactEntity();
                        ObjleadCon.ContactPersonName = itemldp.ContactPersonName;
                        ObjleadCon.MobileNo = itemldp.MobileNo;
                        ObjleadCon.EmailId = itemldp.EmailId;
                        ObjleadCon.RoleName = itemldp.RoleName;
                        ObjleadCon.Designation = itemldp.Designation;


                        LeadConlist.Add(ObjleadCon);
                    }
                }


                //var paraL = new DynamicParameters();
                //paraL.Add("@LeadId", item.LeadId);

                //var lstFollowuplead = await _leadFollowupRepository.GetAllAsync<LeadFollowupDisplayEntity>(LeadQueries.GetLeadsFollowupById, paraL);

                //List<LeadFollowupDisplayEntity> LeadFollowuplist = new List<LeadFollowupDisplayEntity>();
                //LeadFollowupDisplayEntity ObjleadFollwup = null;

                //if (lstFollowuplead != null)
                //{

                //    foreach (var itemlFollowup in lstFollowuplead)
                //    {
                //        ObjleadFollwup = new LeadFollowupDisplayEntity();
                //        ObjleadFollwup.ActualQuote = itemlFollowup.ActualQuote;
                //        ObjleadFollwup.ReviseQuoteAmount = itemlFollowup.ReviseQuoteAmount;
                //        ObjleadFollwup.LeadId = itemlFollowup.LeadId;
                //        ObjleadFollwup.VisitDate = itemlFollowup.VisitDate;
                //        ObjleadFollwup.ConversationDetails = itemlFollowup.ConversationDetails;
                //        ObjleadFollwup.FollowupMode = itemlFollowup.FollowupMode;
                //        ObjleadFollwup.StatusName = itemlFollowup.StatusName;
                //        ObjleadFollwup.UploadDocuments = itemlFollowup.UploadDocuments;
                //        ObjleadFollwup.NextFollowupDate = itemlFollowup.NextFollowupDate;
                //        ObjleadFollwup.TotalBudget = itemlFollowup.TotalBudget;
                //        ObjleadFollwup.Remarks = itemlFollowup.Remarks;
                //        ObjleadFollwup.OrderNo = itemlFollowup.OrderNo;
                //        ObjleadFollwup.ActivityId = itemlFollowup.ActivityId;
                //        ObjleadFollwup.ActivityName = itemlFollowup.ActivityName;
                //        ObjleadFollwup.LeadNumber = itemlFollowup.LeadNumber;
                //        ObjleadFollwup.CustomerName = itemlFollowup.CustomerName;
                //        ObjleadFollwup.ReasonsOfLeasLost = itemlFollowup.ReasonsOfLeasLost;
                //        ObjleadFollwup.CreatedOn = itemlFollowup.CreatedOn;
                //        LeadFollowuplist.Add(ObjleadFollwup);
                //    }
                //}


                var paraL = new DynamicParameters();
                paraL.Add("@LeadId", item.LeadId);

                var lstFollowuplead = await _leadFollowupRepository.GetAllAsync<LeadsFollowupExcelEntity>(LeadQueries.AllLeadsFollowupExcel, paraL);


                List<LeadsFollowupExcelEntity> LeadFollowuplist = new List<LeadsFollowupExcelEntity>();
                LeadsFollowupExcelEntity ObjleadFollwup = null;
                if (lstleadContact != null)
                {
                    foreach (var itemlFollowup in lstFollowuplead)
                    {

                        ObjleadFollwup = new LeadsFollowupExcelEntity();
                        ObjleadFollwup.LeadId = itemlFollowup.LeadId;
                        ObjleadFollwup.LeadsCode = itemlFollowup.LeadsCode;
                        ObjleadFollwup.ServiceTicketNo = itemlFollowup.ServiceTicketNo;
                        ObjleadFollwup.CompanyContactName = itemlFollowup.CompanyContactName;
                        ObjleadFollwup.StatusName = itemlFollowup.StatusName;
                        ObjleadFollwup.CustomerCategoryName = itemlFollowup.CustomerCategoryName;
                        ObjleadFollwup.LeadTypeName = itemlFollowup.LeadTypeName;
                        ObjleadFollwup.CustomerType = itemlFollowup.CustomerType;
                        ObjleadFollwup.LeadDate = itemlFollowup.LeadDate;
                        ObjleadFollwup.Address = itemlFollowup.Address;
                        ObjleadFollwup.NoOfDayold = itemlFollowup.NoOfDayold;
                        ObjleadFollwup.TotalBudget = itemlFollowup.TotalBudget;
                        ObjleadFollwup.NextDateOfFollowup = itemlFollowup.NextDateOfFollowup;
                        ObjleadFollwup.DivisionName = itemlFollowup.DivisionName;
                        ObjleadFollwup.NoOfDayold = itemlFollowup.NoOfDayold;
                        ObjleadFollwup.ContactDetails = itemlFollowup.ContactDetails;
                        ObjleadFollwup.leadStatus = itemlFollowup.leadStatus;
                        ObjleadFollwup.LeadOverDueStatus = itemlFollowup.LeadOverDueStatus;
                        ObjleadFollwup.ExpectedConversionDate = itemlFollowup.ExpectedConversionDate;
                        ObjleadFollwup.ActualQuote = itemlFollowup.ActualQuote;
                        ObjleadFollwup.ReviseQuote = itemlFollowup.ReviseQuote;
                        ObjleadFollwup.RegionName = itemlFollowup.RegionName;
                        ObjleadFollwup.BranchName = itemlFollowup.BranchName;
                        ObjleadFollwup.ActivityRemark = itemlFollowup.ActivityRemark;
                        ObjleadFollwup.ActivityFollowupDate = itemlFollowup.ActivityFollowupDate;
                        ObjleadFollwup.PurchaseNo = itemlFollowup.PurchaseNo;
                        ObjleadFollwup.LostLeadReasonDetails = itemlFollowup.LostLeadReasonDetails;
                        ObjleadFollwup.UserName = itemlFollowup.UserName;

                        LeadFollowuplist.Add(ObjleadFollwup);
                    }
                }

                Objlead.LeadContactList = LeadConlist;
                Objlead.LeadFollowupList = LeadFollowuplist;
                Leadlist.Add(Objlead);
            }

            return Leadlist.ToList();
        }


        public async Task<IList<LeadActivityEntity>> GetAllLeadActivityAsync(int ActivityId)
        {
            var para = new DynamicParameters();
            para.Add("@ActivityId", ActivityId);
            var lstActivity = await _leadFollowupRepository.GetAllAsync<LeadActivityEntity>(LeadQueries.AllLeadActivity, para);
            return lstActivity.ToList();
        }

        public async Task<string?> UpsertleadFollowupAsync(LeadFollowupEntity leadObj)
        {
            var _downloadDirectory = FilePathQueries.LmsFilepath;

            var para = new DynamicParameters();
            para.Add("@FollowupId", leadObj.FollowupId);
            para.Add("@LeadId", leadObj.LeadId);
            para.Add("@VisitDate", leadObj.VisitDate);
            para.Add("@DateOfFollowup", leadObj.DateOfFollowup);
            para.Add("@ActualQuote", leadObj.ActualQuote);
            para.Add("@ReviseQuoteAmount", leadObj.ReviseQuoteAmount);
            para.Add("@FollowupModeId", leadObj.FollowupModeId);
            para.Add("@ConversationDetails", leadObj.ConversationDetails);
            para.Add("@UploadDocuments", Path.Combine(_downloadDirectory, leadObj.UploadDocuments));
            para.Add("@DocumentTypeId", leadObj.DocumentTypeId);
            para.Add("@NextFollowupDate", leadObj.NextFollowupDate);
            para.Add("@StatusId", leadObj.StatusId);
            para.Add("@UserId", leadObj.UserId);
            //para.Add("@Name", leadObj.Name);
            //para.Add("@MobileNo", leadObj.MobileNo);
            //para.Add("@EmailId", leadObj.EmailId);
            //para.Add("@Address", leadObj.Address);
            para.Add("@Remarks", leadObj.Remarks);
            para.Add("@ActivityId", leadObj.ActivityId);
            para.Add("@OrderNo", leadObj.OrderNo);
            para.Add("@ReasonsOfLeasLostId", leadObj.ReasonsOfLeasLostId);
            return await _leadFollowupRepository.ExecuteScalarAsync<string?>(LeadQueries.UpsertLeadsFollowup, para);
        }

        public async Task<LeadFollowupSelectEntity?> GetAllLeadFollowupByIdAsync(int leadId)
        {
            var sp_params = new DynamicParameters();
            sp_params.Add("@LeadId", leadId);
            var lstlead = await _leadFollowupRepository.GetAsync<LeadFollowupSelectEntity>(LeadQueries.GetLeadsById, sp_params);

            LeadFollowupSelectEntity Objlead = null;
            Objlead = new LeadFollowupSelectEntity();
            Objlead.LeadId = lstlead.LeadId;
            Objlead.LeadDate = lstlead.LeadDate;
            Objlead.TotalBudget = lstlead.TotalBudget;
            var paraLC = new DynamicParameters();
            paraLC.Add("@LeadId", leadId);
            var lstleadContact = await _leadFollowupRepository.GetAllAsync<LeadContactEntity>(LeadQueries.LeadsContactList, paraLC);

            List<LeadContactEntity> LeadConlist = new List<LeadContactEntity>();
            LeadContactEntity ObjleadCon = null;

            if (lstleadContact != null)
            {
                foreach (var itemldp in lstleadContact)
                {
                    ObjleadCon = new LeadContactEntity();
                    ObjleadCon.ContactPersonName = itemldp.ContactPersonName;
                    ObjleadCon.MobileNo = itemldp.MobileNo;
                    ObjleadCon.EmailId = itemldp.EmailId;
                    ObjleadCon.RoleName = itemldp.RoleName;
                    ObjleadCon.Designation = itemldp.Designation;

                    LeadConlist.Add(ObjleadCon);
                }
            }


            var paraL = new DynamicParameters();
            paraL.Add("@LeadId", leadId);

            var lstFollowuplead = await _leadFollowupRepository.GetAllAsync<LeadFollowupDisplayEntity>(LeadQueries.GetLeadsFollowupById, paraL);

            List<LeadFollowupDisplayEntity> LeadFollowuplist = new List<LeadFollowupDisplayEntity>();
            LeadFollowupDisplayEntity ObjleadFollwup = null;

            if (lstFollowuplead != null)
            {

                foreach (var itemlFollowup in lstFollowuplead)
                {
                    ObjleadFollwup = new LeadFollowupDisplayEntity();
                    ObjleadFollwup.ActualQuote = itemlFollowup.ActualQuote;
                    ObjleadFollwup.ReviseQuoteAmount = itemlFollowup.ReviseQuoteAmount;
                    ObjleadFollwup.LeadId = itemlFollowup.LeadId;
                    ObjleadFollwup.VisitDate = itemlFollowup.VisitDate;
                    ObjleadFollwup.ConversationDetails = itemlFollowup.ConversationDetails;
                    ObjleadFollwup.FollowupMode = itemlFollowup.FollowupMode;
                    ObjleadFollwup.StatusName = itemlFollowup.StatusName;
                    ObjleadFollwup.UploadDocuments = itemlFollowup.UploadDocuments;
                    ObjleadFollwup.NextFollowupDate = itemlFollowup.NextFollowupDate;
                    ObjleadFollwup.TotalBudget = itemlFollowup.TotalBudget;
                    ObjleadFollwup.Remarks = itemlFollowup.Remarks;
                    ObjleadFollwup.OrderNo = itemlFollowup.OrderNo;
                    ObjleadFollwup.ActivityId = itemlFollowup.ActivityId;
                    ObjleadFollwup.ActivityName = itemlFollowup.ActivityName;
                    ObjleadFollwup.LeadNumber = itemlFollowup.LeadNumber;
                    ObjleadFollwup.CustomerName = itemlFollowup.CustomerName;
                    ObjleadFollwup.ReasonsOfLeasLost = itemlFollowup.ReasonsOfLeasLost;
                    LeadFollowuplist.Add(ObjleadFollwup);
                }
            }

            Objlead.LeadFollowupList = LeadFollowuplist;
            Objlead.LeadContactList = LeadConlist;
            return Objlead;
        }


    }
}
