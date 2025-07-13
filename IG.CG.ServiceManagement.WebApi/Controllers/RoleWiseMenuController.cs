using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace IG.CG.ServiceManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "LoginRequired")]
    public class RoleWiseMenuController : ControllerBase
    {
        private readonly ILogger<RoleWiseMenuController> _logger;
        private readonly IRoleWiseMenuService _roleWiseMenuService;
        public RoleWiseMenuController(IRoleWiseMenuService roleWiseMenuService, ILogger<RoleWiseMenuController> logger)
        {
            _roleWiseMenuService = roleWiseMenuService;
            _logger = logger;
        }
        //[BindRequired, Range(1, 6)]int number
        [HttpGet("GetRoleWiseMenu")]
        public async Task<IActionResult> GetRoleWiseMenu([FromQuery][BindRequired] string roleCode)
        {
            var rolesWiseMenu = await _roleWiseMenuService.GetAllRoleWiseMenu(roleCode);
            if (rolesWiseMenu is null)
            {
                return NoContent();
            }
            else
            {
                return Ok(rolesWiseMenu);
            }
        }
        [HttpGet("GetRoleWiseMenuByUser")]
        public async Task<IActionResult> GetRoleWiseMenuByUser([FromQuery][BindRequired] string roleCode)
        {
            var rolesWiseMenu = await _roleWiseMenuService.GetRoleWiseMenuByUser(roleCode);
            if (rolesWiseMenu is null)
            {
                return NoContent();
            }
            else
            {
                return Ok(rolesWiseMenu);
            }
        }
        [HttpPost("AddRoleWiseMenu")]
        public async Task<IActionResult> InsertRoleWiseMenu([BindRequired] string roleCode, List<RoleWiseMenuModel> lstroleWiseMenus)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var roleWiseMenu = await _roleWiseMenuService.AddRoleWiseMenu(roleCode, User?.Identity?.Name, lstroleWiseMenus);
                return Ok(roleWiseMenu);
            }

        }


        [HttpGet("GetRoleWiseMenuSelect")]
        public async Task<IActionResult> GetRoleWiseMenuSelect([FromQuery][BindRequired] string roleCode)
        {
            var rolesWiseMenu = await _roleWiseMenuService.GetRoleWiseMenuByUserSelect(roleCode);
            if (rolesWiseMenu is null)
            {
                return NoContent();
            }
            else
            {
                return Ok(rolesWiseMenu);
            }
        }
    }
}
