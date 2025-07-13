using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Interfaces.Repository
{
    public interface IServiceTicketRepository
    {
        Task<IList<ServiceTicketDetailsEntity?>> GetServiceTicketDetailsByIdAsync(string? ServiceTickeId);

        Task<IList<ServiceTicketDetailsEntity?>> GetServiceTicketCreateByIdAsync(int ServiceTickeId);
        Task<IList<ServiceTicketInfoDisplayEntity>> GetAllServiceTicketInfoAsync(ServiceTicketInfoFilter serviceTicketInfoFilter);
        Task<IList<SerialWiseServiceTicketInfoEntity?>> GetAllSerialWiseServiceTicketInfoAsync(SerialWiseServiceTicketInfoFilter serialWiseServiceTicketInfoFilter);
        Task<int?> UpdateAcknowledgmentServiceTicketAsync(int serviceTicketId, bool isAcknowledgment, string? StatusName, string? Remark, string UserId);
        Task<IList<ServiceTicketDetailsEntity?>> GetServiceTicketByIdAsync(int ServiceTickeId);
        Task<int?> GetServiceRequestNoOfDays(string productCode);

        Task<IList<SerialWiseServiceTicketInfoEntity?>> GetAllSerialWiseServiceTicketInfoFIRAsync(SerialWiseServiceTicketInfoFilter serialWiseServiceTicketInfoFilter);

        Task<IList<SerialWiseServiceTicketInfoEntity?>> GetServiceTicketJobsheetIdAsync(int ServiceTickeId);
        Task<IList<SpareDetailEntity?>> GetServiceTicketSpareAsync(int ServiceTickeId);
        Task<int?> UpdateServiceTickeBusinessCall(string? serviceTicketId, string? businessCallId);

        Task<int?> UpdateServiceTickeHappyCode(string? serviceTicketId, string? ServiceTicketNumber);


        Task<string?> ReplacementTagGet(string? ServiceTicketId, string? DivCode, string? ProductLineCode);


    }
}
