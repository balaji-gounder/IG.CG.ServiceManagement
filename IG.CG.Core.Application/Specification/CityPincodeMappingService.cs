using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;

namespace IG.CG.Core.Application.Specification
{
    public class CityPincodeMappingService : ICityPincodeMappingService
    {
        private readonly IMapper _mapper;
        private readonly ICityPincodeMappingRepository _CityPincodeMappingRepository;
        public CityPincodeMappingService(IMapper mapper, ICityPincodeMappingRepository CityPincodeMappingRepository)
        {
            _mapper = mapper;
            _CityPincodeMappingRepository = CityPincodeMappingRepository;
        }

        public async Task<IList<CityPincodeMappingModel>> GetAllCityPincodeMapping(string? CityId, string DivisionCode, string Mode)
        {
            var CityPincode = await _CityPincodeMappingRepository.GetAllCityPincodeMapping(CityId, DivisionCode, Mode);
            var CityPincodeModel = _mapper.Map<List<CityPincodeMappingModel>>(CityPincode.ToList());
            return CityPincodeModel;
        }
        public async Task<IList<CityPincodeMappingModel>> GetAllPincodeMappingAsc(string? Pincode)
        {
            var CityPincode = await _CityPincodeMappingRepository.GetAllPincodeMappingAsc(Pincode);
            var CityPincodeModel = _mapper.Map<List<CityPincodeMappingModel>>(CityPincode.ToList());
            return CityPincodeModel;
        }

        public async Task<IList<CityPincodeMappingModel>> GetAllPincodeMappingUser(string? Pincode, string? ProductLineCode)
        {
            var CityPincode = await _CityPincodeMappingRepository.GetAllPincodeMappingUser(Pincode, ProductLineCode);
            var CityPincodeModel = _mapper.Map<List<CityPincodeMappingModel>>(CityPincode.ToList());
            return CityPincodeModel;
        }

    }
}
