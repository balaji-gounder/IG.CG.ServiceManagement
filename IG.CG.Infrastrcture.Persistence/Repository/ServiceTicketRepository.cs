using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class ServiceTicketRepository : IServiceTicketRepository
    {
        private readonly ISqlDbContext _DbRepository;
        public ServiceTicketRepository(ISqlDbContext DbRepository)
        {
            _DbRepository = DbRepository;
        }

        public async Task<IList<ServiceTicketDetailsEntity>> GetServiceTicketDetailsByIdAsync(string? ServiceTickeId)
        {
            var sp_params = new DynamicParameters();
            sp_params.Add("@ServiceTicketId", ServiceTickeId);
            var lstAsc = await _DbRepository.GetAllAsync<ServiceTicketDetailsEntity>(ServiceTicketQueries.GetServiceTicketById, sp_params);
            return lstAsc.ToList();


        }





        public async Task<IList<ServiceTicketDetailsEntity>> GetServiceTicketCreateByIdAsync(int ServiceTickeId)
        {
            var sp_params = new DynamicParameters();
            sp_params.Add("@ServiceTicketId", ServiceTickeId);
            var lstAsc = await _DbRepository.GetAllAsync<ServiceTicketDetailsEntity>(ServiceTicketQueries.GetServiceTicketCreateById, sp_params);
            return lstAsc.ToList();


        }

        public async Task<IList<ServiceTicketInfoDisplayEntity>> GetAllServiceTicketInfoAsync(ServiceTicketInfoFilter serviceTicketInfoFilter)
        {
            var para = new DynamicParameters();
            para.Add("@ServiceTicketNumber", serviceTicketInfoFilter.ServiceTicketNumber);
            para.Add("@SerialNo", serviceTicketInfoFilter.SerialNo);
            para.Add("@DivsionCode", serviceTicketInfoFilter.DivsionCode);
            para.Add("@ProductCode", serviceTicketInfoFilter.ProductCode);
            para.Add("@CustomerName", serviceTicketInfoFilter.CustomerName);
            para.Add("@PageSize", serviceTicketInfoFilter.PageSize);
            para.Add("@PageNumber", serviceTicketInfoFilter.PageNumber);
            var lstServiceTicketInfo = await _DbRepository.GetAllAsync<ServiceTicketInfoDisplayEntity>(ServiceTicketQueries.GetAllServiceTicketInfo, para);

            return lstServiceTicketInfo.ToList();
        }

        public async Task<IList<SerialWiseServiceTicketInfoEntity>> GetAllSerialWiseServiceTicketInfoAsync(SerialWiseServiceTicketInfoFilter serialWiseServiceTicketInfoFilter)
        {
            var para = new DynamicParameters();
            para.Add("@SerialNo", serialWiseServiceTicketInfoFilter.SerialNo);
            para.Add("@ProductCode", serialWiseServiceTicketInfoFilter.ProductCode);
            para.Add("@InvoiceDate", serialWiseServiceTicketInfoFilter.InvoiceDate);
            para.Add("@DivisionCode", serialWiseServiceTicketInfoFilter.DivisionCode);
            var lstAsc = await _DbRepository.GetAllAsync<SerialWiseServiceTicketInfoEntity>(ServiceTicketQueries.GetSerialWiseServiceTicketInfo, para);
            return lstAsc.ToList();
        }


        public async Task<IList<SerialWiseServiceTicketInfoEntity>> GetAllSerialWiseServiceTicketInfoFIRAsync(SerialWiseServiceTicketInfoFilter serialWiseServiceTicketInfoFilter)
        {
            var para = new DynamicParameters();
            para.Add("@SerialNo", serialWiseServiceTicketInfoFilter.SerialNo);
            para.Add("@ProductCode", serialWiseServiceTicketInfoFilter.ProductCode);
            para.Add("@InvoiceDate", serialWiseServiceTicketInfoFilter.InvoiceDate);
            para.Add("@DivisionCode", serialWiseServiceTicketInfoFilter.DivisionCode);
            var lstAsc = await _DbRepository.GetAllAsync<SerialWiseServiceTicketInfoEntity>(ServiceTicketQueries.GetSerialWiseServiceTicketFIRInfo, para);
            return lstAsc.ToList();
        }


        public async Task<IList<SerialWiseServiceTicketInfoEntity>> GetServiceTicketJobsheetIdAsync(int ServiceTickeId)
        {
            var para = new DynamicParameters();
            para.Add("@ServiceTickeId", ServiceTickeId);
            var lstAsc = await _DbRepository.GetAllAsync<SerialWiseServiceTicketInfoEntity>(ServiceTicketQueries.GetSSerialWiseServiceTicketJobsheet, para);
            return lstAsc.ToList();
        }


        public async Task<int?> UpdateAcknowledgmentServiceTicketAsync(int serviceTicketId, bool isAcknowledgment, string? StatusName, string? Remark, string UserId)
        {
            var para = new DynamicParameters();
            para.Add("@ServiceTicketId", serviceTicketId);
            para.Add("@IsAcknowledgment", isAcknowledgment);
            para.Add("@StatusName", StatusName);
            para.Add("@Remark", Remark);
            para.Add("@UserId", UserId);

            var result = await _DbRepository.ExecuteScalarAsync<int?>(ServiceTicketQueries.UpdateIsAcknowledgment, para);
            return result;
        }


        public async Task<IList<ServiceTicketDetailsEntity>> GetServiceTicketByIdAsync(int ServiceTickeId)
        {
            var sp_params = new DynamicParameters();
            sp_params.Add("@ServiceTicketId", ServiceTickeId);
            var lstAsc = await _DbRepository.GetAllAsync<ServiceTicketDetailsEntity>(ServiceTicketQueries.ServiceTicketDetailsById, sp_params);
            return lstAsc.ToList();
        }

        public async Task<int?> GetServiceRequestNoOfDays(string productCode)
        {
            var para = new DynamicParameters();
            para.Add("@ProductCode", productCode);
            var result = await _DbRepository.ExecuteScalarAsync<int?>(ServiceTicketQueries.GetServiceRequestNoOfDays, para);
            return result;
        }

        public async Task<IList<SpareDetailEntity>> GetServiceTicketSpareAsync(int ServiceTickeId)
        {
            var para = new DynamicParameters();
            para.Add("@ServiceTickeId", ServiceTickeId);
            var lstAsc = await _DbRepository.GetAllAsync<SpareDetailEntity>(ServiceTicketQueries.GetServiceTicketSpareDetail, para);
            return lstAsc.ToList();
        }


        public async Task<int?> UpdateServiceTickeBusinessCall(string? serviceTicketId, string? businessCallId)
        {
            var para = new DynamicParameters();
            para.Add("@ServiceTicketId", serviceTicketId);
            para.Add("@BusinessCall", businessCallId);
            var result = await _DbRepository.ExecuteScalarAsync<int?>(ServiceTicketQueries.UpdateServiceTickeBusinessCall, para);
            return result;
        }

        public async Task<int?> UpdateServiceTickeHappyCode(string? serviceTicketId, string? ServiceTicketNumber)
        {
            var para = new DynamicParameters();
            para.Add("@ServiceTicketId", serviceTicketId);
            para.Add("@ServiceTicketNumber", ServiceTicketNumber);
            var result = await _DbRepository.ExecuteScalarAsync<int?>(ServiceTicketQueries.UpdateServiceTicketHappyCodeUpdate, para);
            return result;
        }


        //public async Task<string?> ReplacementTagGet(string? ServiceTicketId, string? DivCode, string? ProductLineCode)
        //{
        //    var para = new DynamicParameters();
        //    para.Add("@ServiceTicketId", ServiceTicketId);
        //    para.Add("@DivCode", DivCode);
        //    para.Add("@ProductLineCode", ProductLineCode);
        //    var result = await _DbRepository.ExecuteScalarAsync<string?>(ServiceTicketQueries.ReplacementTagGet, para);
        //    return result;
        //}

        public async Task<string?> ReplacementTagGet(string? ServiceTicketId, string? DivCode, string? ProductLineCode)
        {
            var para = new DynamicParameters();
            para.Add("@ServiceTicketId", ServiceTicketId);
            para.Add("@DivCode", DivCode);
            para.Add("@ProductLineCode", ProductLineCode);
            var result = await _DbRepository.ExecuteScalarAsync<string?>(ServiceTicketQueries.ReplacementTagGet, para);
            return result;
        }



    }
}

