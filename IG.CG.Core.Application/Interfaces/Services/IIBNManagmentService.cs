using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IG.CG.Core.Application.Models;

namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface IIBNManagmentService
    {
        Task<IList<IBNManagmentModel>> GetIBNManagmentAsync(IBNManagmentFilter IBNManagmentFilter,string? userid);
    }
}
