using IG.CG.Core.Application.Models;

namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface ICityPincodeMappingService
    {
        Task<IList<CityPincodeMappingModel>> GetAllCityPincodeMapping(string? CityId, string DivisionCode, string Mode);

        Task<IList<CityPincodeMappingModel>> GetAllPincodeMappingAsc(string? Pincode);

        Task<IList<CityPincodeMappingModel>> GetAllPincodeMappingUser(string? Pincode, string? ProductLineCode);
    }
}
