using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IG.CG.Core.Application.Interfaces.Repository
{
    public interface IUAddRightsRepository
    {
        Task<string?> UpsertUAddRightsAsync(UserAdditionalRightsEntity uAddRightsObj);
        Task<string?> DeleteUAddRightsAsync(int UAddAutoId, string? userId, int isActive);
        Task<IList<UserAdditionalRightsEntity>> GetAllUAddRightsAsync(UAddRightsFilter uaddRightsFilter);
    }
}
