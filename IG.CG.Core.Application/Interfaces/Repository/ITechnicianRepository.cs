using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;


namespace IG.CG.Core.Application.Interfaces.Repository
{
    public interface ITechnicianRepository
    {
        Task<IList<TechnicianDisplayEntity>> GetAllTechnicianAsync(TechnicianFilter technicianFilter, string? userId);
        Task<TechnicianDisplayEntity?> GetTechnicianByIdAsync(int technicianId);
        Task<string?> UpsertTechnicianAsync(TechnicianEntity technicianObj);
        Task<string?> DeleteTechnicianAsync(int technicianId, string userId, int isActive);
        Task<IList<MasterEntity>> GetTechnicianWishSkillMstByTechnicianIdAsync(MasterFilter TechnicianId);
        Task<IList<AscWiseTechnicianEntity>> GetAscWiseTechnicianAsync(string ascCode);



    }
}
