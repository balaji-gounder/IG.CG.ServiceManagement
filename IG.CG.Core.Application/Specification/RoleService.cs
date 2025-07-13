using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Specification
{
    public class RoleService : IRoleService
    {
        private readonly IMapper _mapper;
        private readonly IRoleRepository _roleRepository;
        public RoleService(IMapper mapper, IRoleRepository roleRepository)
        {
            _mapper = mapper;
            _roleRepository = roleRepository;
        }
        public async Task<IList<RoleModel>> GetAllRoleAsync(RoleFilter roleFilter)
        {
            var role = await _roleRepository.GetAllRoleAsync(roleFilter);
            var roleModel = _mapper.Map<List<RoleModel>>(role.ToList());
            return roleModel;
        }
        public async Task<RoleModel> GetRoleByIdAsync(int roleId)
        {
            var role = await _roleRepository.GetRoleByIdAsync(roleId);
            var roleModel = _mapper.Map<RoleModel>(role);
            return roleModel;
        }
        public async Task<string?> UpsertRoleAsync(RoleModel roleModel, string? userId)
        {
            RoleEntity roleObj = _mapper.Map<RoleEntity>(roleModel);
            roleObj.UserId = userId;
            return await _roleRepository.UpsertRoleAsync(roleObj);
        }
        public async Task<string?> DeleteRoleAsync(int roleId, string? userId, int isActive)
        {
            return await _roleRepository.DeleteRoleAsync(roleId, userId, isActive);
        }


        public async Task<IList<RoleModel>> GetAllRoleByUserTypeAsync(string UserTypeId)
        {
            var role = await _roleRepository.GetAllRoleByUserTypeAsync(UserTypeId);
            var roleModel = _mapper.Map<List<RoleModel>>(role.ToList());
            return roleModel;
        }
    }
}
