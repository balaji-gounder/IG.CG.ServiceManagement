using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;


namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class ASCServiceRequestRepository : IASCServiceRequestRepository
    {

        private readonly ISqlDbContext _ascServiceRequestRepository;
        public ASCServiceRequestRepository(ISqlDbContext ascServiceRequestRepository)
        {
            _ascServiceRequestRepository = ascServiceRequestRepository;
        }
        public async Task<IList<ASCServiceRequestEntity>> GetAllASCServiceRequestAsync(ASCServiceRequestFilter ascServiceRequestFilter, string? userId)
        {
            var para = new DynamicParameters();
            para.Add("@DivisionCode", ascServiceRequestFilter.DivisionCode);
            para.Add("@ProductLineCode", ascServiceRequestFilter.ProductLineCode);
            para.Add("@IssueStatus", ascServiceRequestFilter.IssueStatus);
            para.Add("@Warranty", ascServiceRequestFilter.WarrantyStatus);
            para.Add("@ServiceTicketNo", ascServiceRequestFilter.ServiceTicketNo);
            para.Add("@UserId", userId);
            para.Add("@FromDate", ascServiceRequestFilter.FromDate);
            para.Add("@ToDate", ascServiceRequestFilter.ToDate);
            para.Add("@ASCA", ascServiceRequestFilter.ASCA);
            para.Add("@SerialNo", ascServiceRequestFilter.SerialNo);
            para.Add("@PrimaryMobileNo", ascServiceRequestFilter.PrimaryMobileNo);
            para.Add("@PageSize", ascServiceRequestFilter.PageSize);
            para.Add("@PageNumber", ascServiceRequestFilter.PageNumber);
            var lstASCServiceRequest = await _ascServiceRequestRepository.GetAllAsync<ASCServiceRequestEntity>(ASCServiceRequestQueries.AllASCServiceRequest, para);

            return lstASCServiceRequest.ToList();
        }



        public async Task<IList<SerialNoWiseTicketEntity>> GetAlSerialNoWiseTicketAsync(string? SrNo,string? ServiceTicketnumber)
        {
            var para = new DynamicParameters();
            para.Add("@SrNo", SrNo);
            para.Add("@ServiceTicketNumber", ServiceTicketnumber);
            var lstASCServiceRequest = await _ascServiceRequestRepository.GetAllAsync<SerialNoWiseTicketEntity>(ASCServiceRequestQueries.AllSerialNoWiseTicket, para);
            return lstASCServiceRequest.ToList();
        }



        public async Task<IList<ASCServiceRequestEntity>> GetAllCallCenterRequestOpenTicketAsync(CallCenterRequestOpenTicketFilter ascServiceRequestFilter, string? userId)
        {
            var para = new DynamicParameters();
            para.Add("@DivisionCode", ascServiceRequestFilter.DivisionCode);
            para.Add("@ProductLineCode", ascServiceRequestFilter.ProductLineCode);
            para.Add("@PrimaryMobileNo", ascServiceRequestFilter.PrimaryMobileNo);
            para.Add("@Warranty", ascServiceRequestFilter.WarrantyStatus);
            para.Add("@ServiceTicketNo", ascServiceRequestFilter.ServiceTicketNo);
            para.Add("@IssueStatus", ascServiceRequestFilter.IssueStatus);
            para.Add("@UserId", userId);
            para.Add("@FromDate", ascServiceRequestFilter.FromDate);
            para.Add("@ToDate", ascServiceRequestFilter.ToDate);
            para.Add("@PageSize", ascServiceRequestFilter.PageSize);
            para.Add("@PageNumber", ascServiceRequestFilter.PageNumber);
            var lstASCServiceRequest = await _ascServiceRequestRepository.GetAllAsync<ASCServiceRequestEntity>(ASCServiceRequestQueries.AllCallCenterRequestOpenTicket, para);

            return lstASCServiceRequest.ToList();
        }



        public async Task<IList<ASCServiceRequestTotalCountEntity>> GetAllASCServiceRequestTotalCountAsync(ASCServiceRequestFilter ascServiceRequestFilter, string? userId)
        {
            var para = new DynamicParameters();
            para.Add("@DivisionCode", ascServiceRequestFilter.DivisionCode);
            para.Add("@ProductLineCode", ascServiceRequestFilter.ProductLineCode);
            para.Add("@ServiceTicketNo", ascServiceRequestFilter.ServiceTicketNo);
            para.Add("@UserId", userId);
            para.Add("@FromDate", ascServiceRequestFilter.FromDate);
            para.Add("@ToDate", ascServiceRequestFilter.ToDate);

            var lstASCServiceRequest = await _ascServiceRequestRepository.GetAllAsync<ASCServiceRequestTotalCountEntity>(ASCServiceRequestQueries.AllASCServiceRequestTotalCount, para);

            return lstASCServiceRequest.ToList();
        }



        public async Task<IList<ASCServiceRequestEntity>> GetAllASMServiceRequestAsync(ASCServiceRequestFilter asmServiceRequestFilter, string? userId)
        {
            var para = new DynamicParameters();
            para.Add("@DivisionCode", asmServiceRequestFilter.DivisionCode);
            para.Add("@ProductLineCode", asmServiceRequestFilter.ProductLineCode);
            para.Add("@IssueStatus", asmServiceRequestFilter.IssueStatus);
            para.Add("@Warranty", asmServiceRequestFilter.WarrantyStatus);
            para.Add("@ServiceTicketNo", asmServiceRequestFilter.ServiceTicketNo);
            para.Add("@UserId", userId);
            para.Add("@FromDate", asmServiceRequestFilter.FromDate);
            para.Add("@ToDate", asmServiceRequestFilter.ToDate);
            para.Add("@ASCA", asmServiceRequestFilter.ASCA);
            para.Add("@PageSize", asmServiceRequestFilter.PageSize);
            para.Add("@PageNumber", asmServiceRequestFilter.PageNumber);
            var lstASMServiceRequest = await _ascServiceRequestRepository.GetAllAsync<ASCServiceRequestEntity>(ASCServiceRequestQueries.AllASMServiceRequest, para);

            return lstASMServiceRequest.ToList();
        }

        public async Task<IList<ASCServiceRequestEntity>> GetAllASCServiceRequestViewAsync(ASCServiceRequestViewAllFilter ascServiceRequestFilter)
        {
            var para = new DynamicParameters();
            para.Add("@DivisionCode", ascServiceRequestFilter.DivisionCode);
            para.Add("@ProductLineCode", ascServiceRequestFilter.ProductLineCode);
            para.Add("@IssueStatus", ascServiceRequestFilter.IssueStatus);
            para.Add("@Warranty", ascServiceRequestFilter.WarrantyStatus);
            para.Add("@IssueStatus", ascServiceRequestFilter.IssueStatus);
            para.Add("@FromDate", ascServiceRequestFilter.FromDate);
            para.Add("@ToDate", ascServiceRequestFilter.ToDate);
            para.Add("@PhoneOrServiceTicketNo", ascServiceRequestFilter.PhoneOrServiceTicketNo);
            para.Add("@PageSize", ascServiceRequestFilter.PageSize);
            para.Add("@PageNumber", ascServiceRequestFilter.PageNumber);
            var lstASCServiceRequest = await _ascServiceRequestRepository.GetAllAsync<ASCServiceRequestEntity>(ASCServiceRequestQueries.AllASCServiceRequestView, para);

            return lstASCServiceRequest.ToList();
        }

        public async Task<IList<ASCServiceRequestEntity>> GetAllASCServiceRequestCancelledAsync(ASCServiceRequestFilter ascServiceRequestFilter, string? userId)
        {
            var para = new DynamicParameters();
            para.Add("@DivisionCode", ascServiceRequestFilter.DivisionCode);
            para.Add("@ProductLineCode", ascServiceRequestFilter.ProductLineCode);
            para.Add("@IssueStatus", ascServiceRequestFilter.IssueStatus);
            para.Add("@Warranty", ascServiceRequestFilter.WarrantyStatus);
            para.Add("@IssueStatus", ascServiceRequestFilter.IssueStatus);
            para.Add("@TicketStatus", ascServiceRequestFilter.TicketStatus);
            para.Add("@ServiceTicketNo", ascServiceRequestFilter.ServiceTicketNo);
            para.Add("@UserId", userId);
            para.Add("@FromDate", ascServiceRequestFilter.FromDate);
            para.Add("@ToDate", ascServiceRequestFilter.ToDate);
            para.Add("@PageSize", ascServiceRequestFilter.PageSize);
            para.Add("@PageNumber", ascServiceRequestFilter.PageNumber);
            var lstASCServiceRequestCancelled = await _ascServiceRequestRepository.GetAllAsync<ASCServiceRequestEntity>(ASCServiceRequestQueries.AllASCServiceRequestCancelled, para);

            return lstASCServiceRequestCancelled.ToList();
        }


    }
}
