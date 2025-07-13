using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Interfaces.Repository
{
    public interface ICityPincodeMappingRepository
    {

        Task<IList<CityPincodeMappingEntity>> GetAllCityPincodeMapping(string? CityId, string DivisionCode, string Mode);
        Task<IList<CityPincodeMappingEntity>> GetAllPincodeMappingAsc(string? Pincode);

        Task<IList<CityPincodeMappingEntity>> GetAllPincodeMappingUser(string? Pincode,string? ProductLineCode);
    }
}
