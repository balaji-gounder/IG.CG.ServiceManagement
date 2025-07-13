using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IG.CG.ServiceManagement.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "LoginRequired")]
    public class RegionController : ControllerBase
    {
        private readonly ILogger<RegionController> _logger;
        private readonly IRegionService _regionService;
        public RegionController(IRegionService regionService, ILogger<RegionController> logger)
        {
            _regionService = regionService;
            _logger = logger;
        }
        /// <summary>
        /// Retrieves all Regions.
        /// </summary>
        /// <remarks>
        /// This endpoint returns a list of all active Regions available in the database.
        /// </remarks>
        /// <returns>Returns a collection of regions objects.</returns>
        [HttpGet("GetAllRegions")]
        public async Task<ActionResult<IEnumerable<RegionModel>>> GetRegion([FromQuery] RegionFilter regionFilter)
        {
            var Region = await _regionService.GetAllRegionAsync(regionFilter);
            if (Region is null)
            {

                return NotFound();

            }
            else
            {

                return Ok(Region);

            }
        }

        [HttpGet("GetAllUserwiseRegion")]
        public async Task<ActionResult<IEnumerable<RegionModel>>> GetAllUserwiseRegionAsync()
        {
            var Region = await _regionService.GetAllUserwiseRegionAsync(User?.Identity?.Name);
            if (Region is null)
            {

                return NotFound();

            }
            else
            {

                return Ok(Region);

            }
        }


        /// <summary>
        /// Retrieve Region Data by regionId.
        /// </summary>
        /// <remarks>
        /// Based on Region id,this endpoint returns a matching active region available in the database.
        /// </remarks>
        /// <returns>Returns a single region objects.</returns>
        [HttpGet("GetRegionById")]
        public async Task<ActionResult<RegionModel>> GetRegionById(int regionId)
        {
            var Region = await _regionService.GetRegionByIdAsync(regionId);
            if (Region is null)
            {
                return NotFound();

            }
            else
            {
                return Ok(Region);

            }

        }

        /// <summary>
        /// Insert & Update Region Information.
        /// </summary>
        /// <remarks>
        /// Insert & Update Region into the database.
        /// </remarks>
        /// <returns>Returns a last saved positive Region id if insert or update successfully completed
        /// If it's 1000 then region name already exists 
        /// </returns>
        [HttpPost("UpsertRegion")]
        public async Task<ActionResult> InsertRegion(RegionModel regionModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var region = await _regionService.UpsertRegionAsync(regionModel, User?.Identity?.Name);
                return Ok(region);
            }
        }


        /// <summary>
        /// Remove Region data.
        /// </summary>
        /// <remarks>
        /// Remove Region from the database.
        /// </remarks>
        /// <returns>
        ///  Returns a removed regionId.
        /// </returns>
        [HttpDelete("DeleteRegion")]
        public async Task<ActionResult> RemoveRegion(int regionId, int isActive)
        {
            var region = await _regionService.DeleteRegionAsync(regionId, User?.Identity?.Name, isActive);
            return Ok(region);
        }
    }
}
