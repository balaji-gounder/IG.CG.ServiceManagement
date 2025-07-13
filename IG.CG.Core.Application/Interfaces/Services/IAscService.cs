using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;

namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface IAscService
    {
        Task<IList<AscDisplayModel>> GetAllAscAsync(ASCFilter AscFilter, string? userId);
        Task<AscDisplayModel> GetAscByIdAsync(int ascId);
        Task<string?> UpsertAscAsync(AscModel ascModel, string? userId, string DocumentPath);
        Task<string?> DeleteAscAsync(int ascId, string? userId, int isActive);

        Task<IList<ParaTypeModel>> GetAllAscWishDivisionAsync(string AscCode);
        Task<IList<ParaTypeModel>> GetAllAscDivisionWishProductlineAsync(string AscCode, string DivCode);
        Task<IList<ParaTypeModel>> GetAllAscWishPinCodeAsync(string AscCode);

        Task<string?> UpsertAscApprovalAsync(AscApprovalModel ascModel, string? userId);

        Task<IList<AscModel>> GetAllProductlineWishAscAsync(string ProductlineCode);
        Task<IList<AscListModel>> GetAllAscListAsync();
        Task<IList<AscWiseProductLineModel>> GetAllAscWiseProductlineAsync(string AscCode);
        Task<IList<UserWiseDivisionModel>> GetUserWiseDivisionAsync(string? UserCode);
        Task<IList<DivisionWiseProductLineModel>> GetDivisionWiseProductLineAsync(string? DivisionCode, string? UserCode);
        Task<IList<AscListModel>> GetUserWiseAscAsync(string? UserCode);


    }
}
