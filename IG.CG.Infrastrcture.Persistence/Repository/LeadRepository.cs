using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class LeadRepository : ILeadRepository
    {

        private readonly ISqlDbContext _leadRepository;
        public LeadRepository(ISqlDbContext leadRepository)
        {
            _leadRepository = leadRepository;
        }


        public async Task<IList<LeadDisplayEntity>> GetAllLeadAsync(LeadFilter leadFilter, string? userId)
        {
            var para = new DynamicParameters();
            para.Add("@BranchCode", leadFilter.BranchCode);
            para.Add("@RegionCode", leadFilter.RegionCode);
            para.Add("@FromDate", leadFilter.FromDate);
            para.Add("@DivisionCode", leadFilter.DivisionCode);
            para.Add("@StatusId", leadFilter.StatusId);
            para.Add("@ActivityStatusId", leadFilter.ActivityStatusId);
            para.Add("@ToDate", leadFilter.ToDate);
            para.Add("@PageSize", leadFilter.PageSize);
            para.Add("@PageNumber", leadFilter.PageNumber);
            para.Add("@UserId", userId);
            var lstlead = await _leadRepository.GetAllAsync<LeadDisplayEntity>(LeadQueries.AllLeads, para);


            List<LeadDisplayEntity> Leadlist = new List<LeadDisplayEntity>();
            LeadDisplayEntity Objlead = null;
            foreach (var item in lstlead)
            {
                Objlead = new LeadDisplayEntity();
                Objlead.CompanyContactName = item.CompanyContactName;
                Objlead.SourceName = item.SourceName;
                Objlead.LeadsCode = item.LeadsCode;
                Objlead.ProductSrNo = item.ProductSrNo;
                Objlead.LeadTypeName = item.LeadTypeName;
                Objlead.CustomerTypeName = item.CustomerTypeName;
                Objlead.CustomerCategoryName = item.CustomerCategoryName;
                Objlead.Status = item.Status;
                Objlead.leadStatus = item.leadStatus;
                Objlead.LeadId = item.LeadId;
                Objlead.SourceId = item.SourceId;
                Objlead.LeadTypeId = item.LeadTypeId;
                Objlead.CustomerTypeId = item.CustomerTypeId;
                Objlead.SegmentId = item.SegmentId;
                Objlead.CustomerCategoryId = item.CustomerCategoryId;
                Objlead.ServiceTicketNo = item.ServiceTicketNo;
                Objlead.LeadDate = item.LeadDate;
                Objlead.CompanyContactName = item.CompanyContactName;
                Objlead.IsActive = item.IsActive;

                Objlead.CustomerAddress = item.CustomerAddress;

                Objlead.Rating = item.Rating;
                Objlead.TotalBudget = item.TotalBudget;
                Objlead.ProbabilityOfWin = item.ProbabilityOfWin;
                Objlead.ProjectStateId = item.ProjectStateId;
                Objlead.ProjectCityId = item.ProjectCityId;

                Objlead.ProjectPincodeId = item.ProjectPincodeId;
                Objlead.Conversation = item.Conversation;
                Objlead.BranchCode = item.BranchCode;
                Objlead.DivisionCode = item.DivisionCode;
                Objlead.DivisionName = item.DivisionName;
                Objlead.RegionCode = item.RegionCode;

                Objlead.RegionName = item.RegionName;
                Objlead.BranchName = item.BranchName;
                Objlead.UserName = item.UserName;
                Objlead.ContactDetails = item.ContactDetails;
                Objlead.nextFollowupDate = item.nextFollowupDate;
                Objlead.LeadOverDueStatus = item.LeadOverDueStatus;
                Objlead.ExpectedConversionDate = item.ExpectedConversionDate;
                Objlead.ActualQuote = item.ActualQuote;
                Objlead.ReviseQuote = item.ReviseQuote;
                Objlead.ActivityRemark = item.ActivityRemark;
                Objlead.PurchaseNo = item.PurchaseNo;
                Objlead.LostLeadReasonDetails = item.LostLeadReasonDetails;

                Objlead.CreatedOn = item.CreatedOn;
                Objlead.FollowupConversationDetails = item.FollowupConversationDetails;
                Objlead.DeleteRemark = item.DeleteRemark;
                Objlead.Conversation = item.Conversation;
                Objlead.ProjectCityIdName = item.ProjectCityIdName;
                Objlead.ProjectStateName = item.ProjectStateName;
                Objlead.SubLeadTypeName = item.SubLeadTypeName;
                var paraL = new DynamicParameters();
                paraL.Add("@LeadId", item.LeadId);
                var lstDivProlead = await _leadRepository.GetAllAsync<LeadsDivisionProductDisplayEntity>(LeadQueries.LeadsDivisionProductGroup, paraL);

                List<LeadsDivisionProductDisplayEntity> LeadDPGlist = new List<LeadsDivisionProductDisplayEntity>();
                LeadsDivisionProductDisplayEntity ObjleadDiv = null;

                if (lstDivProlead != null)
                {
                    foreach (var itemldp in lstDivProlead)
                    {
                        ObjleadDiv = new LeadsDivisionProductDisplayEntity();
                        ObjleadDiv.TotalNoOfProducts = itemldp.TotalNoOfProducts;
                        //ObjleadDiv.ProductGroupCode = itemldp.ProductGroupCode;
                        ObjleadDiv.DivisionCode = itemldp.DivisionCode;
                        ObjleadDiv.ProductGroupName = itemldp.ProductGroupName;
                        ObjleadDiv.ProductLineCode = itemldp.ProductLineCode;
                        ObjleadDiv.ProductLineName = itemldp.ProductLineName;
                        ObjleadDiv.DivisionName = itemldp.DivisionName;
                        ObjleadDiv.ServiceOfferingName = itemldp.ServiceOfferingName;
                        ObjleadDiv.DivisionLeadId = itemldp.DivisionLeadId;
                        LeadDPGlist.Add(ObjleadDiv);
                    }
                }

                var paraLC = new DynamicParameters();
                paraLC.Add("@LeadId", item.LeadId);
                var lstleadContact = await _leadRepository.GetAllAsync<LeadContactEntity>(LeadQueries.LeadsContactList, paraLC);

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
                        ObjleadCon.RoleId = itemldp.RoleId;
                        ObjleadCon.IsPrimaryContact = itemldp.IsPrimaryContact;
                        LeadConlist.Add(ObjleadCon);
                    }
                }
                Objlead.LeadContactList = LeadConlist;
                Objlead.LeadsDivisionProductDisplay = LeadDPGlist;
                Leadlist.Add(Objlead);

            }


            return Leadlist.ToList();
        }
        public async Task<string?> UpsertLeadAsync(LeadEntity leadObj)
        {
            var leadId = 0;

            var LeadNo = 0;
            var paraLDNo = new DynamicParameters();

            LeadNo = Convert.ToInt32(await _leadRepository.ExecuteScalarAsync<int?>(LeadQueries.LeadMAXNoGet, paraLDNo));

            var para = new DynamicParameters();
            para.Add("@LeadId", leadObj.LeadId);
            para.Add("@SourceId", leadObj.SourceId);
            para.Add("@LeadTypeId", leadObj.LeadTypeId);
            para.Add("@SubLeadTypeId", leadObj.SubLeadTypeId);
            para.Add("@CustomerTypeId", leadObj.CustomerTypeId);
            para.Add("@SegmentId", leadObj.SegmentId);
            para.Add("@CustomerCategoryId", leadObj.CustomerCategoryId);
            para.Add("@ServiceTicketNo", leadObj.ServiceTicketNo);
            para.Add("@LeadDate", leadObj.LeadDate);
            para.Add("@CompanyContactName", leadObj.CompanyContactName);
            para.Add("@ProductSrNo", leadObj.ProductSrNo);
            para.Add("@CustomerAddress", leadObj.CustomerAddress);
            para.Add("@Rating", leadObj.Rating);
            para.Add("@TotalBudget", leadObj.TotalBudget);
            para.Add("@ProbabilityOfWin", leadObj.ProbabilityOfWin);
            para.Add("@ProjectStateId", leadObj.ProjectStateId);
            para.Add("@ProjectCityId", leadObj.ProjectCityId);
            para.Add("@ProjectPincodeId", leadObj.ProjectPincodeId);
            para.Add("@Conversation", leadObj.Conversation);
            para.Add("@BranchCode", leadObj.BranchCode);
            para.Add("@DivisionCode", leadObj.DivisionCode);
            para.Add("@RegionCode", leadObj.RegionCode);
            para.Add("@IsActive", leadObj.IsActive);
            para.Add("@UserId", leadObj.UserId);
            para.Add("@ExpectedConversionDate", leadObj.ExpectedConversionDate);
            para.Add("@IsNewlead", leadObj.IsNewlead);
            para.Add("@LeadNo", LeadNo);
            leadId = Convert.ToInt32(await _leadRepository.ExecuteScalarAsync<int?>(LeadQueries.UpsertLeads, para));


            if (leadId > 0)
            {
                if (leadObj.LeadsDivisionProductList.Count > 0)
                {

                    var paraLDP = new DynamicParameters();
                    paraLDP.Add("@LeadId", leadId);
                    await _leadRepository.ExecuteScalarAsync<int?>(LeadQueries.DeleteDivisionProductGroup, paraLDP);


                    for (int i = 0; i < leadObj.LeadsDivisionProductList.Count; i++)
                    {
                        var paraLP = new DynamicParameters();
                        paraLP.Add("@LeadId", leadId);
                        paraLP.Add("@DivisionCode", leadObj.LeadsDivisionProductList[i].DivisionCode);
                        //paraLP.Add("@ProductGroupCode", leadObj.LeadsDivisionProductList[i].ProductGroupCode);
                        paraLP.Add("@ProductLineCode", leadObj.LeadsDivisionProductList[i].ProductLineCode);
                        paraLP.Add("@TotalNoOfProducts", leadObj.LeadsDivisionProductList[i].TotalNoOfProducts);
                        paraLP.Add("@ServiceOfferingId", leadObj.LeadsDivisionProductList[i].ServiceOfferingId);

                        await _leadRepository.ExecuteScalarAsync<int?>(LeadQueries.UpsertLeadsDivision, paraLP);
                    }
                }
            }


            if (leadId > 0)
            {
                if (leadObj.LeadContactList.Count > 0)
                {

                    var paraLDP = new DynamicParameters();
                    paraLDP.Add("@LeadId", leadId);
                    await _leadRepository.ExecuteScalarAsync<int?>(LeadQueries.DeleteLeadContact, paraLDP);


                    for (int i = 0; i < leadObj.LeadContactList.Count; i++)
                    {
                        var paraLP = new DynamicParameters();
                        paraLP.Add("@LeadId", leadId);
                        paraLP.Add("@ContactPersonName", leadObj.LeadContactList[i].ContactPersonName);
                        paraLP.Add("@MobileNo", leadObj.LeadContactList[i].MobileNo);
                        paraLP.Add("@EmailId", leadObj.LeadContactList[i].EmailId);
                        paraLP.Add("@Designation", leadObj.LeadContactList[i].Designation);
                        paraLP.Add("@RoleId", leadObj.LeadContactList[i].RoleId);
                        paraLP.Add("@IsPrimaryContact", leadObj.LeadContactList[i].IsPrimaryContact);
                        await _leadRepository.ExecuteScalarAsync<int?>(LeadQueries.UpsertLeadsContact, paraLP);
                    }
                }
            }

            return leadId.ToString();
        }

        public async Task<string?> DeleteLeadAsync(int? leadId, string? userId, int? isActive, string? DeleteRemark)
        {
            var para = new DynamicParameters();
            para.Add("@LeadId", leadId);
            para.Add("@UserId", userId);
            para.Add("@isActive", isActive);
            para.Add("@DeleteRemark", DeleteRemark);
            return await _leadRepository.ExecuteScalarAsync<string?>(LeadQueries.DeleteLeads, para);
        }

        public async Task<LeadDisplayEntity?> GetLeadByIdAsync(int leadId)
        {
            var sp_params = new DynamicParameters();
            sp_params.Add("@LeadId", leadId);
            var lstlead = await _leadRepository.GetAsync<LeadDisplayEntity>(LeadQueries.GetLeadsById, sp_params);

            List<LeadDisplayEntity> Leadlist = new List<LeadDisplayEntity>();
            LeadDisplayEntity Objlead = null;


            Objlead = new LeadDisplayEntity();
            Objlead.CompanyContactName = lstlead.CompanyContactName;

            Objlead.LeadId = lstlead.LeadId;
            Objlead.SourceId = lstlead.SourceId;
            Objlead.LeadTypeId = lstlead.LeadTypeId;
            Objlead.CustomerTypeId = lstlead.CustomerTypeId;
            Objlead.ProductSrNo = lstlead.ProductSrNo;
            Objlead.SegmentId = lstlead.SegmentId;

            Objlead.CustomerCategoryId = lstlead.CustomerCategoryId;
            Objlead.ServiceTicketNo = lstlead.ServiceTicketNo;
            Objlead.LeadDate = lstlead.LeadDate;
            Objlead.CompanyContactName = lstlead.CompanyContactName;
            Objlead.IsActive = lstlead.IsActive;

            Objlead.CustomerAddress = lstlead.CustomerAddress;

            Objlead.Rating = lstlead.Rating;
            Objlead.TotalBudget = lstlead.TotalBudget;
            Objlead.ProbabilityOfWin = lstlead.ProbabilityOfWin;
            Objlead.ProjectStateId = lstlead.ProjectStateId;
            Objlead.ProjectCityId = lstlead.ProjectCityId;
            Objlead.Conversation = lstlead.Conversation;
            Objlead.ProjectPincodeId = lstlead.ProjectPincodeId;

            Objlead.BranchCode = lstlead.BranchCode;
            Objlead.DivisionCode = lstlead.DivisionCode;
            Objlead.RegionCode = lstlead.RegionCode;
            Objlead.SubLeadTypeId = lstlead.SubLeadTypeId;
            Objlead.ExpectedConversionDate = lstlead.ExpectedConversionDate;
            Objlead.IsNewlead = lstlead.IsNewlead;
            Objlead.ProjectStateName = lstlead.ProjectStateName;
            Objlead.ProjectCityIdName = lstlead.ProjectCityIdName;
            Objlead.ProjectPincodeIdName = lstlead.ProjectPincodeIdName;

            Objlead.CustomerTypeName = lstlead.CustomerTypeName;
            Objlead.CustomerCategoryName = lstlead.CustomerCategoryName;
            Objlead.LeadTypeName = lstlead.LeadTypeName;
            Objlead.SegmentName = lstlead.SegmentName;
            Objlead.SubLeadTypeName = lstlead.SubLeadTypeName;
            Objlead.SourceName = lstlead.SourceName;
            var paraL = new DynamicParameters();
            paraL.Add("@LeadId", lstlead.LeadId);

            var lstDivProlead = await _leadRepository.GetAllAsync<LeadsDivisionProductDisplayEntity>(LeadQueries.LeadsDivisionProductGroup, paraL);

            List<LeadsDivisionProductDisplayEntity> LeadDPGlist = new List<LeadsDivisionProductDisplayEntity>();
            LeadsDivisionProductDisplayEntity ObjleadDiv = null;

            if (lstDivProlead != null)
            {
                foreach (var itemldp in lstDivProlead)
                {
                    ObjleadDiv = new LeadsDivisionProductDisplayEntity();
                    ObjleadDiv.TotalNoOfProducts = itemldp.TotalNoOfProducts;
                    /// ObjleadDiv.ProductGroupCode = itemldp.ProductGroupCode;
                    ObjleadDiv.DivisionCode = itemldp.DivisionCode;
                    ObjleadDiv.ProductGroupName = itemldp.ProductGroupName;
                    ObjleadDiv.ProductLineCode = itemldp.ProductLineCode;
                    ObjleadDiv.ProductLineName = itemldp.ProductLineName;
                    ObjleadDiv.DivisionName = itemldp.DivisionName;
                    ObjleadDiv.ServiceOfferingName = itemldp.ServiceOfferingName;
                    ObjleadDiv.ServiceOfferingId = itemldp.ServiceOfferingId;
                    ObjleadDiv.DivisionLeadId = itemldp.DivisionLeadId;




                    // ----------------------------------------- Product Line --------------

                    var paraPL = new DynamicParameters();
                    paraPL.Add("@Leadid", leadId);
                    paraPL.Add("@DivisionLeadId", itemldp.DivisionLeadId);

                    var lstProLineUser = await _leadRepository.GetAllAsync<ParaTypeEntity>(LeadQueries.AllLeadsWishProductLine, paraPL);

                    List<ParaTypeEntity> ProductLinelist = new List<ParaTypeEntity>();
                    ParaTypeEntity ObjPL = null;
                    if (lstProLineUser != null)
                    {
                        foreach (var itemlPL in lstProLineUser)
                        {
                            ObjPL = new ParaTypeEntity();
                            ObjPL.ParameterTypeId = itemlPL.ParameterTypeId;
                            ObjPL.ParameterType = itemlPL.ParameterType;

                            ProductLinelist.Add(ObjPL);
                        }



                    }

                    ObjleadDiv.ProductLineCodeList = ProductLinelist;

                    LeadDPGlist.Add(ObjleadDiv);
                }
            }


            var paraLC = new DynamicParameters();
            paraLC.Add("@LeadId", lstlead.LeadId);
            var lstleadContact = await _leadRepository.GetAllAsync<LeadContactEntity>(LeadQueries.LeadsContactList, paraLC);

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
                    ObjleadCon.RoleId = itemldp.RoleId;
                    ObjleadCon.IsPrimaryContact = itemldp.IsPrimaryContact;
                    LeadConlist.Add(ObjleadCon);
                }
            }

            Objlead.LeadContactList = LeadConlist;


            Objlead.LeadsDivisionProductDisplay = LeadDPGlist;

            return Objlead;
        }





        public async Task<string?> DeleteLeadProductAsync(int divisionLeadId)
        {
            var para = new DynamicParameters();
            para.Add("@divisionLeadId", divisionLeadId);

            return await _leadRepository.ExecuteScalarAsync<string?>(LeadQueries.DeleteLeadsDivProductlist, para);
        }

        public async Task<IList<LeadsDashboardEntity>> GetLeadsDashboardAsync(LeadsDashboardFilter leadFilter, string? userId)
        {
            var para = new DynamicParameters();
            para.Add("@BranchCode", leadFilter.BranchCode);
            para.Add("@RegionCode", leadFilter.RegionCode);
            para.Add("@DivisionCode", leadFilter.DivisionCode);
            para.Add("@FromDate", leadFilter.FromDate);
            para.Add("@ToDate", leadFilter.ToDate);
            para.Add("@UserId", userId);
            para.Add("@Mode", "1");
            var lstRegion = await _leadRepository.GetAllAsync<LeadsDashboardEntity>(LeadQueries.AllLeadsDashboardGet, para);
            return lstRegion.ToList();
        }


        public async Task<IList<LeadsDashboardChartEntity>> GetMonthWishLeadsLineChartAsync(LeadsDashboardFilter leadFilter, string? userId)
        {
            var para = new DynamicParameters();
            para.Add("@BranchCode", leadFilter.BranchCode);
            para.Add("@RegionCode", leadFilter.RegionCode);
            para.Add("@DivisionCode", leadFilter.DivisionCode);
            para.Add("@FromDate", leadFilter.FromDate);
            para.Add("@ToDate", leadFilter.ToDate);
            para.Add("@UserId", userId);
            para.Add("@Mode", "2");
            var lstRegion = await _leadRepository.GetAllAsync<LeadsDashboardChartEntity>(LeadQueries.AllLeadsDashboardGet, para);
            return lstRegion.ToList();

        }


        public async Task<IList<LeadsDashboardChartEntity>> GetLeadActivityStatusPieChartAsync(LeadsDashboardFilter leadFilter, string? userId)
        {
            var para = new DynamicParameters();
            para.Add("@BranchCode", leadFilter.BranchCode);
            para.Add("@RegionCode", leadFilter.RegionCode);
            para.Add("@DivisionCode", leadFilter.DivisionCode);
            para.Add("@FromDate", leadFilter.FromDate);
            para.Add("@ToDate", leadFilter.ToDate);
            para.Add("@UserId", userId);
            para.Add("@Mode", "3");
            var lstRegion = await _leadRepository.GetAllAsync<LeadsDashboardChartEntity>(LeadQueries.AllLeadsDashboardGet, para);
            return lstRegion.ToList();

        }
    }
}
