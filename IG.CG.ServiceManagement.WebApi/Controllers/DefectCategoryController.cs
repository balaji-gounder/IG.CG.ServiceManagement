using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace IG.CG.ServiceManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "LoginRequired")]
    public class DefectCategoryController : Controller
    {
        private readonly ILogger<DefectCategoryController> _logger;
        private readonly IDefectCategoryService _defectCategoryService;
        public DefectCategoryController(IDefectCategoryService defectCategoryService, ILogger<DefectCategoryController> logger)
        {
            _defectCategoryService = defectCategoryService;
            _logger = logger;
        }


        /// <summary>
        /// Retrieves all Defect Category Detail List.
        /// </summary>
        /// <remarks>
        /// This endpoint returns a list of all active Defect Category available in the database.
        /// </remarks>
        /// <returns>Returns a collection of order objects.</returns>
        [HttpGet("GetAllDefectCategory")]
        public async Task<ActionResult<IEnumerable<DefectCategoryModel>>> GetDefectCategory([FromQuery] DefectCategoryFilter defectCategoryFilter)
        {
            var DefectCategory = await _defectCategoryService.GetAllDefectCategoryAsync(defectCategoryFilter);
            if (DefectCategory is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(DefectCategory);
            }
        }



        /// <summary>
        /// Retrieve Defect Category Data by BranchId.
        /// </summary>
        /// <remarks>
        /// Based on Defect Category id,this endpoint returns a matching active Defect Category available in the database.
        /// </remarks>
        /// <returns>Returns a single Defect Category objects.</returns>
        [HttpGet("GetDefectCategoryById")]
        public async Task<ActionResult<DefectCategoryModel>> GetDefectCategoryById(int defectCategoryId)
        {
            var defectCategory = await _defectCategoryService.GetDefectCategoryByIdAsync(defectCategoryId);
            if (defectCategory is null)
            {
                return NotFound();

            }
            else
            {
                return Ok(defectCategory);

            }

        }



        /// <summary>
        /// Insert & Update Defect Category Information.
        /// </summary>
        /// <remarks>
        /// Insert & Update Defect Category into the database.
        /// </remarks>
        /// <returns>Returns a last saved positive Defect Category id if insert or update successfully completed
        /// If it's 1000 then Defect Category name already exists 
        /// </returns>
        [HttpPost("UpsertDefectCategory")]
        public async Task<ActionResult> InsertDefectCategory(DefectCategoryModel defectCategoryModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var DefectCategory = await _defectCategoryService.UpsertDefectCategoryAsync(defectCategoryModel, User?.Identity?.Name);
                return Ok(DefectCategory);
            }

        }


        /// <summary>
        /// Remove Defect Category data.
        /// </summary>
        /// <remarks>
        /// Remove Defect Category from the database.
        /// </remarks>
        /// <returns>
        ///  Returns a removed Defect Category id.
        /// </returns>
        [HttpDelete("DeleteDefectCategory")]
        public async Task<ActionResult> RemoveDefectCategory(int defectCategoryId, int isActive)
        {
            var DefectCategory = await _defectCategoryService.DeleteDefectCategoryAsync(defectCategoryId, User?.Identity?.Name, isActive);
            return Ok(DefectCategory);
        }

        [HttpGet("GetAllDefectCategoryByProduct")]
        public async Task<ActionResult<IEnumerable<DefectCategoryModel>>> GetDefectCategoryByProduct(string? divisionCode, string? productLineCode, string? productGroupCode)
        {
            var DefectCategory = await _defectCategoryService.GetAllDefectCategoryByProductAsync(divisionCode, productLineCode, productGroupCode);
            if (DefectCategory is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(DefectCategory);
            }
        }
    }
}
