using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IG.CG.Core.Application.Interfaces.Repository
{
    public interface IProductDeviationRepository
    {
        Task<IList<ProductDeviationDisplayEntity>> GetAllProductDeviationAsync( ProductDeviationFilter productDeviationFilter);
        Task<ProductDeviationEntity?> GetProductDeviationByIdAsync(int productDeviationId);
        Task<string?> UpsertProductDeviationAsync(ProductDeviationEntity productDeviationObj);
        Task<string?> DeleteProductDeviationAsync(int productDeviationId, string? userId, int isActive);
    }
}
