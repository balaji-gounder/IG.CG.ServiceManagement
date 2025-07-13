using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;

namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface ITemplateMailAndSmsService
    {

        Task<IList<TemplateMailAndSmsModel>> GetAllTemplateAsync(TemplateMailAndSmsFilter MSFilter);
        Task<TemplateMailAndSmsModel> GetTemplateByIdAsync(int TemplateId);
        Task<string?> UpsertTemplateAsync(TemplateMailAndSmsModel TemplateModel, string? userId);
        Task<string?> DeleteTemplateAsync(int TemplateId, string? userId, int isActive);
    }
}
