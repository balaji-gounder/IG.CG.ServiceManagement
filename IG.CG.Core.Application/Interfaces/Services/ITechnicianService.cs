
using IG.CG.Core.Application.Models;

namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface ITechnicianService
    {
        Task<IList<TechnicianDisplayModel>> GetAllTechnicianAsync(TechnicianFilter technicianFilter, string? userId);
        Task<TechnicianDisplayModel> GetTechnicianByIdAsync(int technicianId);
        Task<string?> UpsertTechnicianAsync(TechnicianModel technicianModel, string? userId);
        Task<string?> DeleteTechnicianAsync(int technicianId, string? userId, int isActive);
        Task<IList<MasterModel>> GetTechnicianWishSkillMstByTechnicianIdAsync(MasterFilter TechnicianId);
        Task<IList<AscWiseTechnicianModel>> GetAscWiseTechnicianAsync(string ascCode);


    }
}
