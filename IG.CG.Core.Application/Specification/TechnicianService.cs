using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;


namespace IG.CG.Core.Application.Specification
{
    public class TechnicianService : ITechnicianService
    {
        private readonly IMapper _mapper;
        private readonly ITechnicianRepository _technicianRepository;
        public TechnicianService(IMapper mapper, ITechnicianRepository technicianRepository)
        {
            _mapper = mapper;
            _technicianRepository = technicianRepository;
        }


        public async Task<IList<TechnicianDisplayModel>> GetAllTechnicianAsync(TechnicianFilter technicianFilter, string? userId)
        {
            var technician = await _technicianRepository.GetAllTechnicianAsync(technicianFilter, userId);
            var technicianModel = _mapper.Map<List<TechnicianDisplayModel>>(technician.ToList());
            return technicianModel;
        }


        public async Task<TechnicianDisplayModel> GetTechnicianByIdAsync(int technicianId)
        {
            var technician = await _technicianRepository.GetTechnicianByIdAsync(technicianId);
            var technicianModel = _mapper.Map<TechnicianDisplayModel>(technician);
            return technicianModel;
        }

        public async Task<string?> UpsertTechnicianAsync(TechnicianModel technicianModel, string? userId)
        {
            TechnicianEntity technicianObj = _mapper.Map<TechnicianEntity>(technicianModel);
            technicianObj.UserId = userId;
            return await _technicianRepository.UpsertTechnicianAsync(technicianObj);
        }
        public async Task<string?> DeleteTechnicianAsync(int technicianId, string? userId, int isActive)
        {
            return await _technicianRepository.DeleteTechnicianAsync(technicianId, userId, isActive);
        }

        public async Task<IList<MasterModel>> GetTechnicianWishSkillMstByTechnicianIdAsync(MasterFilter userFilter)
        {
            var userWishMst = await _technicianRepository.GetTechnicianWishSkillMstByTechnicianIdAsync(userFilter);
            var userWishMstModel = _mapper.Map<List<MasterModel>>(userWishMst.ToList());
            return userWishMstModel;
        }

        public async Task<IList<AscWiseTechnicianModel>> GetAscWiseTechnicianAsync(string ascCode)
        {
            var ascWiseTechnician = await _technicianRepository.GetAscWiseTechnicianAsync(ascCode);
            var ascWiseTechnicianModel = _mapper.Map<List<AscWiseTechnicianModel>>(ascWiseTechnician.ToList());
            return ascWiseTechnicianModel;
        }

    }
}
