using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Interfaces.Repository
{
    public interface IASCWisePinCodeRepository
    {
        Task<string?> UpsertASCWisePinCodeAsync(ASCWisePinCodeEntity AscPincodeObj);
        Task<IList<ASCWisePinCodeDisplayEntity>> GetAllASCWisePinCodeAsync(ASCWisePinCodeFilter ascFilter);
        Task<ASCWisePinCodeDisplayEntity?> GetASCWisePinCodeByIdAsync(string ascCode);

        Task<string?> DeleteASCWisePinCodeAsync(string ascCode, string userId, int isActive);
    }
}
