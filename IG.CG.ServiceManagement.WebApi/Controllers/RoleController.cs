using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IG.CG.ServiceManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "LoginRequired")]
    public class RoleController : ControllerBase
    {
        private readonly ILogger<RoleController> _logger;
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService, ILogger<RoleController> logger)
        {
            _roleService = roleService;
            _logger = logger;
        }
        /// <summary>
        /// Retrieves all roles.
        /// </summary>
        /// <remarks>
        /// This endpoint returns a list of all active roles available in the database.
        /// </remarks>
        /// <returns>Returns a collection of roles objects.</returns>
        [HttpGet("GetAllRoles")]
        public async Task<ActionResult<IEnumerable<RoleModel>>> GetRoles([FromQuery] RoleFilter roleFilter)
        {
            var roles = await _roleService.GetAllRoleAsync(roleFilter);
            if (roles is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(roles);
            }
        }

        /// <summary>
        /// Retrieve role by Id.
        /// </summary>
        /// <remarks>
        /// Based on role id,this endpoint returns a matching active role available in the database.
        /// </remarks>
        /// <returns>Returns a single role objects.</returns>
        [HttpGet("GetRoleById")]
        public async Task<ActionResult<RoleModel>> GetRolesById(int roleId)
        {
            var role = await _roleService.GetRoleByIdAsync(roleId);
            return Ok(role);
        }
        /// <summary>
        /// Insert & Update Role Information.
        /// </summary>
        /// <remarks>
        /// Insert & Update role into the database.
        /// </remarks>
        /// <returns>Returns a last saved positive role id if insert or update successfully completed
        /// If it's 1001 then role name already exists 
        /// </returns>
        [HttpPost("UpsertRole")]
        public async Task<ActionResult> InsertRole(RoleModel roleModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var role = await _roleService.UpsertRoleAsync(roleModel, User?.Identity?.Name);
                return Ok(role);
            }

        }
        /// <summary>
        /// Remove Role data.
        /// </summary>
        /// <remarks>
        /// Remove role from the database.
        /// </remarks>
        /// <returns>Returns a removed role id.
        ///  if it's 2001 then role is attached to user , first remove it from user role
        /// </returns>
        [HttpDelete("DeleteRole")]
        public async Task<ActionResult> RemoveRole(int roleId, int isActive)
        {
            var role = await _roleService.DeleteRoleAsync(roleId, User?.Identity?.Name, isActive);
            return Ok(role);
        }

        [HttpGet("GetAllRolesByUserType")]
        public async Task<ActionResult<IEnumerable<RoleModel>>> GetRolesByUserType(string userTypeid)
        {
            var roles = await _roleService.GetAllRoleByUserTypeAsync(userTypeid);
            if (roles is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(roles);
            }
        }
    }
}
