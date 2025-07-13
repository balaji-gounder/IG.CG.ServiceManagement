using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface IApprovalLevelService
    {
        Task<string?> UpsertApprovalLevelAsync(ApprovalLevelModel approvalLevelModel, string? userId);
        Task<IList<ApprovalLevelDisplayModel>> GetAllApprovalLevelAsync(ApprovalLevelFilter approvalLevelFilter);
        Task<IList<ApprovalLevelUsersModel>> GetAllApprovalLevelUsersAsync(ApprovalLevelFilter approvalLevelFilter);


    }
}
