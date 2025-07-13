using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace IG.CG.ServiceManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DivisionController : Controller
    {

        private readonly ILogger<DivisionController> _logger;
        private readonly IDivisionService _divisionService;
        public DivisionController(IDivisionService divisionService, ILogger<DivisionController> logger)
        {
            _divisionService = divisionService;
            _logger = logger;
        }

        /// <summary>
        /// Retrieves all Division Detail List.
        /// </summary>
        /// <remarks>
        /// This endpoint returns a list of all active Division available in the database.
        /// </remarks>
        /// <returns>Returns a collection of order objects.</returns>

        [Authorize(Policy = "LoginRequired")]
        [HttpGet("GetAllDivision")]
        public async Task<ActionResult<IEnumerable<DivisionModel>>> GetDivision([FromQuery] DivisionFilter divisionFilter)
        {
            var Division = await _divisionService.GetAllDivisionAsync(divisionFilter);
            if (Division is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Division);
            }
        }



        /// <summary>
        /// Retrieve Division Data by DivisionId.
        /// </summary>
        /// <remarks>
        /// Based on Division id,this endpoint returns a matching active division available in the database.
        /// </remarks>
        /// <returns>Returns a single role objects.</returns>

        [Authorize(Policy = "LoginRequired")]
        [HttpGet("GetDivisionById")]
        public async Task<ActionResult<DivisionModel>> GetDivisionById(int divisionId)
        {
            var Division = await _divisionService.GetDivisionByIdAsync(divisionId);
            if (Division is null)
            {
                return NotFound();

            }
            else
            {
                return Ok(Division);

            }

        }


        /// <summary>
        /// Insert & Update Division Information.
        /// </summary>
        /// <remarks>
        /// Insert & Update Division into the database.
        /// </remarks>
        /// <returns>Returns a last saved positive Division id if insert or update successfully completed
        /// If it's 1000 then role name already exists 
        /// </returns>

        [Authorize(Policy = "LoginRequired")]
        [HttpPost("UpsertDivision")]
        public async Task<ActionResult> InsertDivision(DivisionModel divisionModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var division = await _divisionService.UpsertDivisionAsync(divisionModel, User?.Identity?.Name);
                return Ok(division);
            }

        }


        /// <summary>
        /// Remove Division data.
        /// </summary>
        /// <remarks>
        /// Remove Division from the database.
        /// </remarks>
        /// <returns>
        ///  Returns a removed Division id.
        /// </returns>

        [Authorize(Policy = "LoginRequired")]
        [HttpDelete("DeleteDivision")]
        public async Task<ActionResult> RemoveDivision(int divisionId, int isActive)
        {
            var division = await _divisionService.DeleteDivisionAsync(divisionId, User?.Identity?.Name, isActive);
            return Ok(division);
        }


        /// <summary>
        /// Retrieves all SAP Division Detail List.
        /// </summary>
        /// <remarks>
        /// This endpoint returns a list of all active SAP Division available in the database.
        /// </remarks>
        /// <returns>Returns a collection of order objects.</returns>

        [Authorize(Policy = "LoginRequired")]
        [HttpGet("GetAllSAPDivision")]
        public async Task<ActionResult<IEnumerable<DivisionModel>>> GetSAPDivision([FromQuery] SAPCommonFilter SapFilter)
        {
            var Division = await _divisionService.GetAllSAPDivisionAsync(SapFilter);
            if (Division is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Division);
            }
        }


        [HttpGet("GetAllProductType")]
        public async Task<ActionResult<IEnumerable<ProductTypeModel>>> GetProductType()
        {
            var Division = await _divisionService.GetAllProductTypeAsync();
            if (Division is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Division);
            }
        }

        [Authorize(Policy = "LoginRequired")]
        [HttpGet("GetAllProductTypeAuthorize")]
        public async Task<ActionResult<IEnumerable<ProductTypeModel>>> GetProductTypeAuthorize()
        {
            var Division = await _divisionService.GetAllProductTypeAsync();
            if (Division is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Division);
            }
        }
    }
}
