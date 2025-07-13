using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Interfaces.Repository
{
    public interface IknowledgeRepository
    {

        Task<IList<knowledgelistEntity>> GetAllknowledgeAsync(string? userId);
        Task<knowledgelistEntity?> GetknowledgeByIdAsync(string? knowledgeId);
        Task<string?> UpsertknowledgeAsync(knowledgeInfoDetailslistEntity regionObj, string? FilePath);

        Task<string?> DeleteknowledgeAsync(string? knowledgeId, string? userId, int isActive);

    }
}
