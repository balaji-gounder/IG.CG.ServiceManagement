using IG.CG.Core.Application.Models;

namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface IASCWisePinCodeService
    {
        Task<string?> UpsertASCWisePinCodeAsync(ASCWisePinCodeModel AscPincodeObj, string? userId);
        Task<IList<ASCWisePinCodeDisplayModel>> GetAllASCWisePinCodeAsync(ASCWisePinCodeFilter AscFilter);
        Task<ASCWisePinCodeDisplayModel> GetASCWisePinCodeByIdAsync(string ascCode);

        Task<string?> DeleteASCWisePinCodeAsync(string ascCode, string? userId, int isActive);


    }
}
