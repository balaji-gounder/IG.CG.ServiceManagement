using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IG.CG.ServiceManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "LoginRequired")]
    public class SpareController : Controller
    {
        private readonly ILogger<SpareController> _logger;
        private readonly ISpareService _spareService;
        public SpareController(ISpareService spareService, ILogger<SpareController> logger)
        {
            _spareService = spareService;
            _logger = logger;

        }

        [HttpPost("UpsertSpare")]
        public async Task<ActionResult> UpsertSpare(SpareModel spareModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var Spare = await _spareService.UpsertSpareAsync(spareModel, User?.Identity?.Name);
                return Ok(Spare);
            }
        }

        [HttpGet("GetSpareById")]
        public async Task<ActionResult<SpareModel>> GetSpareById(int SpareId)
        {
            var Spare = await _spareService.GetSpareByIdAsync(SpareId);
            if (Spare is null)
            {
                return NotFound();

            }
            else
            {
                return Ok(Spare);

            }
        }

        [HttpGet("GetAllSpare")]
        public async Task<ActionResult<IEnumerable<SpareDisplayModel>>> GetAllSpare([FromQuery] SpareFilter spareFilter)
        {
            var Spare = await _spareService.GetAllSpareAsync(spareFilter);
            if (Spare is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Spare);
            }
        }

        [HttpDelete("DeleteSpare")]
        public async Task<ActionResult> RemoveSpare(int SpareId, int isActive)
        {
            var DeleteSpare = await _spareService.DeleteSpareAsync(SpareId, User?.Identity?.Name, isActive);
            return Ok(DeleteSpare);
        }
    }
}
