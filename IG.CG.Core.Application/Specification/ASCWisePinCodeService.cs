using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Specification
{
    public class ASCWisePinCodeService : IASCWisePinCodeService
    {

        private readonly IMapper _mapper;
        private readonly IASCWisePinCodeRepository _ASCWisePinCodeRepository;
        public ASCWisePinCodeService(IMapper mapper, IASCWisePinCodeRepository ASCWisePinCodeRepository)
        {
            _mapper = mapper;
            _ASCWisePinCodeRepository = ASCWisePinCodeRepository;

        }
        public async Task<string?> UpsertASCWisePinCodeAsync(ASCWisePinCodeModel AscPinModel, string? userId)
        {
            ASCWisePinCodeEntity AscPinObj = _mapper.Map<ASCWisePinCodeEntity>(AscPinModel);
            AscPinObj.UserId = userId;
            return await _ASCWisePinCodeRepository.UpsertASCWisePinCodeAsync(AscPinObj);
        }

        public async Task<IList<ASCWisePinCodeDisplayModel>> GetAllASCWisePinCodeAsync(ASCWisePinCodeFilter ascFilter)
        {
            var asc = await _ASCWisePinCodeRepository.GetAllASCWisePinCodeAsync(ascFilter);
            var ascModel = _mapper.Map<List<ASCWisePinCodeDisplayModel>>(asc.ToList());
            return ascModel;
        }
        public async Task<ASCWisePinCodeDisplayModel> GetASCWisePinCodeByIdAsync(string ascCode)
        {
            var asc = await _ASCWisePinCodeRepository.GetASCWisePinCodeByIdAsync(ascCode);
            var ascModel = _mapper.Map<ASCWisePinCodeDisplayModel>(asc);
            return ascModel;
        }

        public async Task<string?> DeleteASCWisePinCodeAsync(string? ascCode, string? userId, int isActive)
        {
            return await _ASCWisePinCodeRepository.DeleteASCWisePinCodeAsync(ascCode, userId, isActive);
        }

    }
}
