using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IG.CG.Core.Application.Interfaces.Repository
{
    public interface IApprovalLevelRepository
    {
        Task<string?> UpsertApprovalLevelAsync(ApprovalLevelEntity ApprovalLevelObj);
        Task<IList<ApprovalLevelDisplayEntity>> GetAllApprovalLevelAsync(ApprovalLevelFilter approvalLevelFilter);
        Task<IList<ApprovalLevelUsersEntity>> GetAllApprovalLevelUsersAsync(ApprovalLevelFilter approvalLevelFilter);


    }
}
