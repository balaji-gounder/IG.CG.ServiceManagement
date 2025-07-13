using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IG.CG.ServiceManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "LoginRequired")]
    public class TechnicianController : Controller
    {
        private readonly ILogger<TechnicianController> _logger;
        private readonly ITechnicianService _technicianService;
        public TechnicianController(ITechnicianService technicianService, ILogger<TechnicianController> logger)
        {
            _technicianService = technicianService;
            _logger = logger;
        }

        /// <summary>
        /// Retrieves all Technician details List.
        /// </summary>
        /// <remarks>
        /// This endpoint returns a list of all active Technician available in the database.
        /// </remarks>
        /// <returns>Returns a collection of order objects.</returns>
        [HttpGet("GetAllTechnician")]
        public async Task<ActionResult<IEnumerable<TechnicianDisplayModel>>> GetTechnician([FromQuery] TechnicianFilter technicianFilter)
        {
            var technician = await _technicianService.GetAllTechnicianAsync(technicianFilter, User?.Identity?.Name);
            if (technician is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(technician);
            }
        }


        /// <summary>
        /// Retrieve Technician Data by TechnicianId.
        /// </summary>
        /// <remarks>
        /// Based on Technician id,this endpoint returns a matching active Technician available in the database.
        /// </remarks>
        /// <returns>Returns a single Technician objects.</returns>
        [HttpGet("GetTechnicianById")]
        public async Task<ActionResult<TechnicianDisplayModel>> GetTechnicianById(int technicianId)
        {
            var technician = await _technicianService.GetTechnicianByIdAsync(technicianId);
            if (technician is null)
            {
                return NotFound();

            }
            else
            {
                return Ok(technician);

            }

        }



        /// <summary>
        /// Insert & Update Technician Information.
        /// </summary>
        /// <remarks>
        /// Insert & Update Technician into the database.
        /// </remarks>
        /// <returns>Returns a last saved positive Technician id if insert or update successfully completed
        /// If it's TECHEXISTS then Technician name already exists 
        /// </returns>
        [HttpPost("UpsertTechnician")]
        public async Task<ActionResult<TechnicianModel>> InsertTechnician(TechnicianModel technicianModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var technician = await _technicianService.UpsertTechnicianAsync(technicianModel, User?.Identity?.Name);
                return Ok(technician);
            }

        }


        /// <summary>
        /// Remove Technician data.
        /// </summary>
        /// <remarks>
        /// Remove Technician from the database.
        /// </remarks>
        /// <returns>
        ///  Returns a removed Technician id.
        /// </returns>
        [HttpDelete("DeleteTechnician")]
        public async Task<ActionResult<TechnicianModel>> RemoveTechnician(int technicianId, int isActive)
        {
            var technician = await _technicianService.DeleteTechnicianAsync(technicianId, User?.Identity?.Name, isActive);
            return Ok(technician);
        }




        /// <summary>
        /// Retrieves all User Wish Master details List.
        /// </summary>
        /// <remarks>
        /// This endpoint returns a list of all active User Wish Master available in the database.
        /// </remarks>
        /// <returns>Returns a collection of Mode=2 (Technician Wish Skill)</returns>
        [HttpGet("GetTechnicianWishSkill")]
        public async Task<ActionResult<IEnumerable<MasterModel>>> GetTechnicianWishSkill([FromQuery] MasterFilter userFilter)
        {
            var userWishMst = await _technicianService.GetTechnicianWishSkillMstByTechnicianIdAsync(userFilter);
            if (userWishMst is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(userWishMst);
            }
        }


        [HttpGet("GetAscWiseTechnician")]
        public async Task<ActionResult<IEnumerable<AscWiseTechnicianModel>>> GetAscWiseTechnician(string ascCode)
        {
            var ascWiseTechnician = await _technicianService.GetAscWiseTechnicianAsync(ascCode);
            if (ascWiseTechnician is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ascWiseTechnician);
            }
        }

    }
}
