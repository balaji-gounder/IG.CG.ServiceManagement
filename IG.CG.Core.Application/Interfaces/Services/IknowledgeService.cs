using IG.CG.Core.Application.Models;

namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface IknowledgeService
    {
        Task<IList<knowledgelistModel>> GetAllknowledgeAsync(string? userId);
        Task<knowledgelistModel> GetknowledgeByIdAsync(string? knowledgeId);
        Task<string?> UpsertknowledgeAsync(knowledgeInfoDetailslistModel KnowlegeModel, string? userId);
        Task<string?> DeleteknowledgeAsync(string? knowledgeId, string? userId, int isActive);

    }
}
