using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Interfaces.Repository
{
    public interface ITemplateMailAndSmsRepository
    {
        Task<IList<TemplateMailAndSmsEntity>> GetAllTemplateAsync(TemplateMailAndSmsFilter MSFilter);
        Task<TemplateMailAndSmsEntity?> GetTemplateByIdAsync(int TemplateId);
        Task<string?> UpsertTemplateAsync(TemplateMailAndSmsEntity TemplateObj);
        Task<string?> DeleteTemplateAsync(int TemplateId, string? userId, int isActive);

    }
}
