using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Interfaces.Repository
{

    public interface IASCRepository
    {
        Task<IList<AscDisplayEntity>> GetAllAscAsync(ASCFilter ascFilter, string? UserId);
        Task<AscDisplayEntity?> GetAscByIdAsync(int ascId);
        Task<string?> UpsertAscAsync(AscEntity ascObj);
        Task<string?> DeleteAscAsync(int ascId, string userId, int isActive);

        Task<IList<ParaTypeEntity>> GetAllAscWishDivisionAsync(string AscCode);
        Task<IList<ParaTypeEntity>> GetAllAscDivisionWishProductlineAsync(string AscCode, string DivCode);

        Task<IList<ParaTypeEntity>> GetAllAscWishPinCodeAsync(string AscCode);

        Task<string?> UpsertAscApprovalAsync(AscApprovalEnitity ascObj);

        Task<IList<AscEntity>> GetAllProductlineWishAscAsync(string ProductlineCode);
        Task<IList<AscListEntity>> GetAllAscListAsync();
        Task<IList<AscWiseProductLineEntity>> GetAllAscWiseProductlineAsync(string AscCode);
        Task<IList<UserWiseDivisionEntity>> GetUserWiseDivisionAsync(string? UserCode);
        Task<IList<DivisionWiseProductLineEntity>> GetDivisionWiseProductLineAsync(string? DivisionCode, string? UserCode);
        Task<IList<AscListEntity>> GetUserWiseAscAsync(string? UserCode);


    }

}
