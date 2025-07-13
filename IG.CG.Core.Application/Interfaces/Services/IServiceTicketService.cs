using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;

namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface IServiceTicketService
    {
        Task<IList<ServiceTicketDetailsModel?>> GetServiceTicketDetailsByIdAsync(string? ServiceTickeId);
        Task<IList<ServiceTicketDetailsModel?>> GetServiceTicketCreateByIdAsync(int ServiceTickeId);
        Task<IList<ServiceTicketInfoDisplayModel>> GetAllServiceTicketInfoAsync(ServiceTicketInfoFilter serviceTicketInfoFilter);
        Task<IList<SerialWiseServiceTicketInfoModel?>> GetAllSerialWiseServiceTicketInfoAsync(SerialWiseServiceTicketInfoFilter serialWiseServiceTicketInfoFilter);
        Task<int?> UpdateAcknowledgmentServiceTicketAsync(int serviceTicketId, bool isAcknowledgment, string? StatusName, string? Remark, string UserId);
        Task<IList<ServiceTicketDetailsModel?>> GetServiceTicketByIdAsync(int ServiceTickeId);
        Task<int?> GetServiceRequestNoOfDays(string productCode);

        Task<IList<SerialWiseServiceTicketInfoModel?>> GetAllSerialWiseServiceTicketInfoFIRAsync(SerialWiseServiceTicketInfoFilter serialWiseServiceTicketInfoFilter);
        Task<IList<SerialWiseServiceTicketInfoModel?>> GetServiceTicketJobsheetIdAsync(int ServiceTickeId);
        Task<IList<SpareDetailModel?>> GetServiceTicketSpareAsync(int ServiceTickeId);

        Task<int?> UpdateServiceTickeBusinessCall(string? serviceTicketId, string? businessCallId);

        Task<int?> UpdateServiceTickeHappyCode(string? serviceTicketId, string? ServiceTicketNumber);

        Task<string?> ReplacementTagGet(string? ServiceTicketId, string? DivCode, string? ProductLineCode);



    }
}
