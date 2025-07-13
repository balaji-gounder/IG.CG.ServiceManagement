using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Specification
{
    public class RoleWiseMenuService : IRoleWiseMenuService
    {
        private readonly IMapper _mapper;
        private readonly IRoleWiseMenuRepository _roleWiseRepository;
        public RoleWiseMenuService(IMapper mapper, IRoleWiseMenuRepository roleWiseRepository)
        {
            _mapper = mapper;
            _roleWiseRepository = roleWiseRepository;
        }

        public async Task<int?> AddRoleWiseMenu(string roleCode, string? userId, List<RoleWiseMenuModel> lstroleWiseMenus)
        {
            int? result = null;
            var lstRoleWiseMenuModel = _mapper.Map<List<RoleWiseMenuEntity>>(lstroleWiseMenus);

            await _roleWiseRepository.DeleteRoleWiseMenu(roleCode);


            foreach (var roleWiseMenu in lstRoleWiseMenuModel)
            {
                result = await _roleWiseRepository.AddRoleWiseMenu(roleCode, userId, roleWiseMenu);
            }
            return result;
        }

        public async Task<IList<RoleWiseMenuModel>> GetAllRoleWiseMenu(string roleCode, int parentId = 0)
        {
            var roleWiseMenu = await _roleWiseRepository.GetAllRoleWiseMenu(roleCode, parentId);
            var roleWiseMenuModel = _mapper.Map<List<RoleWiseMenuModel>>(roleWiseMenu.ToList());
            return roleWiseMenuModel;
        }
        public async Task<IList<RoleWiseMenuModel>> GetRoleWiseMenuByUser(string roleCode, int parentId = 0)
        {
            var roleWiseMenu = await _roleWiseRepository.GetRoleWiseMenuByUser(roleCode, parentId);
            var roleWiseMenuModel = _mapper.Map<List<RoleWiseMenuModel>>(roleWiseMenu.ToList());
            return roleWiseMenuModel;
        }

        public async Task<IList<RoleWiseMenuModel>> GetRoleWiseMenuByUserSelect(string roleCode, int parentId = 0)
        {
            var roleWiseMenu = await _roleWiseRepository.GetRoleWiseMenuByUserSelect(roleCode, parentId);
            var roleWiseMenuModel = _mapper.Map<List<RoleWiseMenuModel>>(roleWiseMenu.ToList());
            return roleWiseMenuModel;
        }
    }
}
