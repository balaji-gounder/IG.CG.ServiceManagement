using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IG.CG.ServiceManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "LoginRequired")]
    public class ASCWisePinCodeController : Controller
    {
        private readonly ILogger<ASCWisePinCodeController> _logger;
        private readonly IASCWisePinCodeService _AscPinService;
        public ASCWisePinCodeController(IASCWisePinCodeService AscPinService, ILogger<ASCWisePinCodeController> logger)
        {
            _AscPinService = AscPinService;
            _logger = logger;
        }

        [HttpPost("UpsertASCWisePinCode")]
        public async Task<ActionResult> InsertASCWisePinCode(ASCWisePinCodeModel AscpincodeModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var ASCPincode = await _AscPinService.UpsertASCWisePinCodeAsync(AscpincodeModel, User?.Identity?.Name);
                return Ok(ASCPincode);
            }

        }



        [HttpGet("GetAllASCWisePinCode")]
        public async Task<ActionResult<IEnumerable<ASCWisePinCodeDisplayModel>>> GetAsc([FromQuery] ASCWisePinCodeFilter ascFilter)
        {
            var asc = await _AscPinService.GetAllASCWisePinCodeAsync(ascFilter);
            if (asc is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(asc);
            }
        }

        [HttpGet("GetASCWisePinCodeById")]
        public async Task<ActionResult<ASCWisePinCodeDisplayModel>> GetAscById(string? ascCode)
        {
            var asc = await _AscPinService.GetASCWisePinCodeByIdAsync(ascCode);
            if (asc is null)
            {
                return NotFound();

            }
            else
            {
                return Ok(asc);

            }
        }

        [HttpDelete("DeleteASCWisePinCode")]
        public async Task<ActionResult> RemoveAscSCWisePinCode(string? ascCode, int isActive)
        {
            var asc = await _AscPinService.DeleteASCWisePinCodeAsync(ascCode, User?.Identity?.Name, isActive);
            return Ok(asc);
        }

    }
}
