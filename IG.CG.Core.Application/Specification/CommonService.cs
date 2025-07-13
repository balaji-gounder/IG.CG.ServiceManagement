using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;

namespace IG.CG.Core.Application.Specification
{
    public class CommonService : ICommonService
    {
        private readonly IMapper _mapper;
        private readonly ICommonRepository _commonRepository;
        public CommonService(IMapper mapper, ICommonRepository commonRepository)
        {
            _mapper = mapper;
            _commonRepository = commonRepository;
        }


        public async Task<IList<ParaTypeModel>> GetAllCommonAsync(int Mode, int Id, string Code)
        {
            var common = await _commonRepository.GetAllCommonAsync(Mode, Id, Code);
            var commonModel = _mapper.Map<List<ParaTypeModel>>(common?.ToList());
            return commonModel;
        }



        public async Task<IList<ParaTypeModel>> GetAllActivityStatusAsync(int ServiceTicketId, int ActivityType, string DivisionCode)
        {
            var common = await _commonRepository.GetAllActivityStatusAsync(ServiceTicketId, ActivityType, DivisionCode);
            var commonModel = _mapper.Map<List<ParaTypeModel>>(common?.ToList());
            return commonModel;
        }

        public async Task<IList<ParaTypeModel>> GetAllActivitySubStatusAsync(int ServiceTicketId, int ActivityStatusId)
        {
            var common = await _commonRepository.GetAllActivitySubStatusAsync(ServiceTicketId, ActivityStatusId);
            var commonModel = _mapper.Map<List<ParaTypeModel>>(common?.ToList());
            return commonModel;
        }

        public async Task<IList<ParaTypeModel>> GetAllClaimDeviationAsync(int ServiceTicketId, string DivisionCode)
        {
            var common = await _commonRepository.GetAllClaimDeviationAsync(ServiceTicketId, DivisionCode);
            var commonModel = _mapper.Map<List<ParaTypeModel>>(common?.ToList());
            return commonModel;


        }



        public async Task<IList<ProductLineFrontModel>> GetAllProductLineFrontAsync(int? ProductLineFrontId)
        {
            var common = await _commonRepository.GetAllProductLineFrontAsync(ProductLineFrontId);
            var commonModel = _mapper.Map<List<ProductLineFrontModel>>(common?.ToList());
            return commonModel;
        }
    }
}
