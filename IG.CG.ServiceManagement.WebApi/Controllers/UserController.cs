using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace IG.CG.ServiceManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "LoginRequired")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        /// <summary>
        /// Retrieves all User detail List.
        /// </summary>
        /// <remarks>
        /// This endpoint returns a list of all active User available in the database.
        /// </remarks>
        /// <returns>Returns a collection of order objects.</returns>
        [HttpGet("GetAllUser")]
        public async Task<ActionResult<IEnumerable<UserDisplayModel>>> GetUser([FromQuery] UserFilter userFilter)
        {
            var user = await _userService.GetAllUserAsync(userFilter);
            if (user is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user);
            }
        }


        /// <summary>
        /// Retrieve User Data by UserId.
        /// </summary>
        /// <remarks>
        /// Based on User id,this endpoint returns a matching active User available in the database.
        /// </remarks>
        /// <returns>Returns a single User objects.</returns>
        [HttpGet("GetUserById")]
        public async Task<ActionResult<UserModel>> GetUserById(string userId)
        {
            var user = await _userService.GetUserByIdAsync(userId);
            if (user is null)
            {
                return NotFound();

            }
            else
            {
                return Ok(user);

            }

        }

        /// <summary>
        /// Insert & Update User Information.
        /// </summary>
        /// <remarks>
        /// Insert & Update User into the database.
        /// </remarks>
        /// <returns>Returns a last saved positive User id if insert or update successfully completed
        /// If it's 1000 then User name already exists 
        /// </returns>
        [HttpPost("UpsertUser")]
        public async Task<ActionResult<string>> InsertUser(UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var user = await _userService.UpsertUserAsync(userModel, User?.Identity?.Name);
                return Ok(user);
            }

        }

        /// <summary>
        /// Remove User data.
        /// </summary>
        /// <remarks>
        /// Remove User from the database.
        /// </remarks>
        /// <returns>
        ///  Returns a removed User id.
        /// </returns>
        [HttpDelete("DeleteUser")]
        public async Task<ActionResult<UserModel>> RemoveUser(int userAutoId, int isActive)
        {
            var user = await _userService.DeleteUserAsync(userAutoId, User?.Identity?.Name, isActive);
            return Ok(user);
        }



        /// <summary>
        /// Retrieves all User Wish Master Detsil List.
        /// </summary>
        /// <remarks>
        /// This endpoint returns a list of all active User Wish Master available in the database.
        /// </remarks>
        /// <returns>Returns a collection of Mode=2 (User Wise Branch) / Mode=3 (User Wise Product Line) / Mode=4 (User Wise Division) objects.</returns>
        [HttpGet("GetAllWishMstUser")]
        public async Task<ActionResult<IEnumerable<MasterModel>>> GetUserWishMst([FromQuery] MasterFilter userFilter)
        {
            var userWishMst = await _userService.GetAllUserWishMstByUserIdAsync(userFilter);
            if (userWishMst is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(userWishMst);
            }
        }

    }
}
