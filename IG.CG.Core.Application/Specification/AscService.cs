using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Specification
{
    public class AscService : IAscService
    {
        private readonly IMapper _mapper;
        private readonly IASCRepository _ascRepository;
        public AscService(IMapper mapper, IASCRepository ascRepository)
        {
            _mapper = mapper;
            _ascRepository = ascRepository;
        }
        public async Task<IList<AscDisplayModel>> GetAllAscAsync(ASCFilter ascFilter, string? UserId)
        {
            var asc = await _ascRepository.GetAllAscAsync(ascFilter, UserId);
            var ascModel = _mapper.Map<List<AscDisplayModel>>(asc.ToList());
            return ascModel;
        }
        public async Task<AscDisplayModel> GetAscByIdAsync(int ascId)
        {
            var asc = await _ascRepository.GetAscByIdAsync(ascId);
            var ascModel = _mapper.Map<AscDisplayModel>(asc);
            return ascModel;
        }
        public async Task<string?> UpsertAscAsync(AscModel ascModel, string? userId, string? DocumentPath)
        {
            AscEntity ascObj = _mapper.Map<AscEntity>(ascModel);
            ascObj.UserId = userId;
            ascObj.DocumentPath = DocumentPath;
            return await _ascRepository.UpsertAscAsync(ascObj);
        }
        public async Task<string?> DeleteAscAsync(int ascId, string? userId, int isActive)
        {
            return await _ascRepository.DeleteAscAsync(ascId, userId, isActive);
        }


        public async Task<IList<ParaTypeModel>> GetAllAscWishDivisionAsync(string AscCode)
        {
            var common = await _ascRepository.GetAllAscWishDivisionAsync(AscCode);
            var commonModel = _mapper.Map<List<ParaTypeModel>>(common?.ToList());
            return commonModel;
        }






        public async Task<IList<ParaTypeModel>> GetAllAscDivisionWishProductlineAsync(string AscCode, string DivCode)
        {
            var common = await _ascRepository.GetAllAscDivisionWishProductlineAsync(AscCode, DivCode);
            var commonModel = _mapper.Map<List<ParaTypeModel>>(common?.ToList());
            return commonModel;
        }

        public async Task<IList<ParaTypeModel>> GetAllAscWishPinCodeAsync(string AscCode)
        {
            var common = await _ascRepository.GetAllAscWishPinCodeAsync(AscCode);
            var commonModel = _mapper.Map<List<ParaTypeModel>>(common?.ToList());
            return commonModel;
        }

        public async Task<string?> UpsertAscApprovalAsync(AscApprovalModel ascModel, string? userId)
        {
            AscApprovalEnitity ascObj = _mapper.Map<AscApprovalEnitity>(ascModel);
            ascObj.UserId = userId;
            return await _ascRepository.UpsertAscApprovalAsync(ascObj);

        }

        public async Task<IList<AscModel>> GetAllProductlineWishAscAsync(string ProductlineCode)
        {
            var common = await _ascRepository.GetAllProductlineWishAscAsync(ProductlineCode);
            var commonModel = _mapper.Map<List<AscModel>>(common?.ToList());
            return commonModel;
        }

        public async Task<IList<AscListModel>> GetAllAscListAsync()
        {
            var asc = await _ascRepository.GetAllAscListAsync();
            var ascModel = _mapper.Map<List<AscListModel>>(asc.ToList());
            return ascModel;
        }

        public async Task<IList<AscWiseProductLineModel>> GetAllAscWiseProductlineAsync(string AscCode)
        {
            var ascWiseProductLine = await _ascRepository.GetAllAscWiseProductlineAsync(AscCode);
            var ascWiseProductLineModel = _mapper.Map<List<AscWiseProductLineModel>>(ascWiseProductLine.ToList());
            return ascWiseProductLineModel;
        }

        public async Task<IList<UserWiseDivisionModel>> GetUserWiseDivisionAsync(string? UserCode)
        {
            var userWiseDivision = await _ascRepository.GetUserWiseDivisionAsync(UserCode);
            var userWiseDivisionModel = _mapper.Map<List<UserWiseDivisionModel>>(userWiseDivision.ToList());
            return userWiseDivisionModel;
        }

        public async Task<IList<DivisionWiseProductLineModel>> GetDivisionWiseProductLineAsync(string? DivisionCode, string? UserCode)
        {
            var DivisionWiseProductLine = await _ascRepository.GetDivisionWiseProductLineAsync(DivisionCode, UserCode);
            var DivisionWiseProductLineModel = _mapper.Map<List<DivisionWiseProductLineModel>>(DivisionWiseProductLine.ToList());
            return DivisionWiseProductLineModel;
        }

        public async Task<IList<AscListModel>> GetUserWiseAscAsync(string? UserCode)
        {
            var UserWiseAsc = await _ascRepository.GetUserWiseAscAsync(UserCode);
            var UserWiseAscModel = _mapper.Map<List<AscListModel>>(UserWiseAsc.ToList());
            return UserWiseAscModel;
        }
    }
}
