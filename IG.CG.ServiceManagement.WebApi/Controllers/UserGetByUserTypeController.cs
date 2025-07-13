using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IG.CG.ServiceManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "LoginRequired")]
    public class UserGetByUserTypeController : Controller
    {
        private readonly ILogger<UserGetByUserTypeController> _logger;
        private readonly IUserGetByUserTypeService _userGetByUserTypeService;
        public UserGetByUserTypeController(IUserGetByUserTypeService userGetByUserTypeService, ILogger<UserGetByUserTypeController> logger)
        {
            _userGetByUserTypeService = userGetByUserTypeService;
            _logger = logger;
        }



        /// <summary>
        /// Retrieves all User Detsil List.
        /// </summary>
        /// <remarks>
        /// This endpoint returns a list of all active User available in the database.
        /// </remarks>
        /// <returns>Returns a collection of order objects.</returns>
        [HttpGet("GetUserGetByUserType")]
        public async Task<ActionResult<IEnumerable<UserGetByUserTypeModel>>> GetUserGetByUserType([FromQuery] UserGetByUserTypeFilter userTypeFilter)
        {
            var user = await _userGetByUserTypeService.GetAllUserGetByUserTypeAsync(userTypeFilter);
            if (user is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user);
            }
        }



    }
}
