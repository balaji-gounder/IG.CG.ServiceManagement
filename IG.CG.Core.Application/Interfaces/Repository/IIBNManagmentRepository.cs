using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Interfaces.Repository
{
    public interface IIBNManagmentRepository
    {
        Task<IList<IBNManagmentEntity>> GetIBNManagmentAsync(IBNManagmentFilter IBNManagmentFilter, string? UserId);
    }
}
