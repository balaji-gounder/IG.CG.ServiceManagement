using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace IG.CG.ServiceManagement.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class DefectController : Controller
    {

        private readonly ILogger<DefectController> _logger;
        private readonly IDefectService _defectService;
        public DefectController(IDefectService defectService, ILogger<DefectController> logger)
        {
            _defectService = defectService;
            _logger = logger;
        }

        /// <summary>
        /// Retrieves all Defect Detail List.
        /// </summary>
        /// <remarks>
        /// This endpoint returns a list of all active Defect available in the database.
        /// </remarks>
        /// <returns>Returns a collection of order objects.</returns>

        [Authorize(Policy = "LoginRequired")]
        [HttpGet("GetAllDefect")]
        public async Task<ActionResult<IEnumerable<DefectDisplayModel>>> GetDefect([FromQuery] DefectFilter defectFilter)
        {
            var defect = await _defectService.GetAllDefectAsync(defectFilter);
            if (defect is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(defect);
            }
        }

        /// <summary>
        /// Retrieve Defect Data by DefectId.
        /// </summary>
        /// <remarks>
        /// Based on Defect id,this endpoint returns a matching active Defect available in the database.
        /// </remarks>
        /// <returns>Returns a single Defect objects.</returns>

        [Authorize(Policy = "LoginRequired")]
        [HttpGet("GetDefectById")]
        public async Task<ActionResult<DefectModel>> GetDefectById(int defectId)
        {
            var defect = await _defectService.GetDefectByIdAsync(defectId);
            if (defect is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(defect);
            }

        }


        /// <summary>
        /// Insert & Update Defect Information.
        /// </summary>
        /// <remarks>
        /// Insert & Update Defect into the database.
        /// </remarks>
        /// <returns>Returns a last saved positive Defect id if insert or update successfully completed
        /// If it's 1000 then Defect name already exists 
        /// </returns>


        [Authorize(Policy = "LoginRequired")]
        [HttpPost("UpsertDefect")]
        public async Task<ActionResult> InsertDefect(DefectModel defectModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var defect = await _defectService.UpsertDefectAsync(defectModel, User?.Identity?.Name);
                return Ok(defect);
            }

        }




        /// <summary>
        /// Remove Defect data.
        /// </summary>
        /// <remarks>
        /// Remove Defect from the database.
        /// </remarks>
        /// <returns>
        ///  Returns a removed Defect id.
        /// </returns>


        [Authorize(Policy = "LoginRequired")]
        [HttpDelete("DeleteDefect")]
        public async Task<ActionResult> RemoveDefectAsync(int defectId, int isActive)
        {
            var defect = await _defectService.DeleteDefectAsync(defectId, User?.Identity?.Name, isActive);
            return Ok(defect);
        }

        [HttpGet("GetDefectByProductLine")]
        public async Task<ActionResult<IEnumerable<DefectDisplayModel>>> GetDefectByProductLineAsync(string? ProductLineCode)
        {
            var defect = await _defectService.GetAllDefectByProductLineAsync(ProductLineCode);
            if (defect is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(defect);
            }
        }
    }
}
