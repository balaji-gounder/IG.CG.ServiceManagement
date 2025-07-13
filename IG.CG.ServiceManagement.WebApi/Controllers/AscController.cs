using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Enums;
using IG.CG.Core.Domain.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace IG.CG.ServiceManagement.WebApi.Controllers
{
    [Authorize(Policy = "LoginRequired")]
    [Route("api/[controller]")]
    [ApiController]

    public class AscController : ControllerBase
    {
        private readonly ILogger<AscController> _logger;
        private readonly IAscService _ascService;
        public AscController(IAscService ascService, ILogger<AscController> logger)
        {
            _ascService = ascService;
            _logger = logger;
        }

        [HttpGet("GetAllAsc")]
        public async Task<ActionResult<IEnumerable<AscDisplayModel>>> GetAsc([FromQuery] ASCFilter ascFilter)
        {
            var asc = await _ascService.GetAllAscAsync(ascFilter, User?.Identity?.Name);
            if (asc is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(asc);
            }
        }

        [HttpGet("GetAscById")]
        public async Task<ActionResult<AscDisplayModel>> GetAscById(int AscId)
        {
            var asc = await _ascService.GetAscByIdAsync(AscId);
            if (asc is null)
            {
                return NotFound();

            }
            else
            {
                return Ok(asc);

            }
        }

        [HttpPost("UpsertAsc")]
        public async Task<ActionResult> InsertAsc([FromForm] AscModel ascModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                //List<string> ImageList = new List<string>();
                string DocumentPath = "";
                UploadDocument objUp = new UploadDocument(Request);

                DocumentPath = objUp.UploadImages1(ascModel.DocumentPath, DocumentTypes.Document);


                var asc = await _ascService.UpsertAscAsync(ascModel, User?.Identity?.Name, DocumentPath);
                return Ok(asc);


            }

        }

        [HttpDelete("DeleteAsc")]
        public async Task<ActionResult> RemoveAsc(int ascId, int isActive)
        {
            var asc = await _ascService.DeleteAscAsync(ascId, User?.Identity?.Name, isActive);
            return Ok(asc);
        }



        [HttpGet("GetAscWiseDivision")]
        public async Task<IActionResult> GetAllAscWiseDivision(string? ascCode)
        {
            var paraTypeResult = await _ascService.GetAllAscWishDivisionAsync(ascCode);
            return Ok(paraTypeResult);
        }


        [HttpGet("GetAscDivisionWiseProductline")]
        public async Task<IActionResult> GetAllAscDivisionWiseProductline(string? ascCode, string? divCode)
        {
            var paraTypeResult = await _ascService.GetAllAscDivisionWishProductlineAsync(ascCode, divCode);
            return Ok(paraTypeResult);
        }

        [HttpGet("GetAscWisePinCode")]
        public async Task<IActionResult> GetAscWisePinCode(string? ascCode)
        {
            var paraTypeResult = await _ascService.GetAllAscWishPinCodeAsync(ascCode);
            return Ok(paraTypeResult);
        }


        [HttpPost("UpsertApprovalAsc")]
        public async Task<ActionResult> InsertAscApproval(AscApprovalModel ascModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var asc = await _ascService.UpsertAscApprovalAsync(ascModel, User?.Identity?.Name);
                return Ok(asc);
            }
        }


        [HttpGet("GetProductlineWiseASC")]
        public async Task<IActionResult> GetAllProductlineWishAscAsync(string? ProductlineCode)
        {
            var paraTypeResult = await _ascService.GetAllProductlineWishAscAsync(ProductlineCode);
            return Ok(paraTypeResult);
        }

        [HttpGet("GetAllAscList")]
        public async Task<ActionResult<IEnumerable<AscListModel>>> GetAscList()
        {
            var ascList = await _ascService.GetAllAscListAsync();
            if (ascList is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ascList);
            }
        }

        [HttpGet("GetAscWiseProductline")]
        public async Task<ActionResult<IEnumerable<AscWiseProductLineModel>>> GetAllAscWiseProductline(string ascCode)
        {
            var ascWiseProductLine = await _ascService.GetAllAscWiseProductlineAsync(ascCode);
            if (ascWiseProductLine is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ascWiseProductLine);
            }
        }

        [HttpGet("GetUserWiseDivision")]
        public async Task<ActionResult<IEnumerable<UserWiseDivisionModel>>> GetUserWiseDivision(string? UserCode)
        {
            var userWiseDivision = await _ascService.GetUserWiseDivisionAsync(UserCode);
            if (userWiseDivision is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(userWiseDivision);
            }
        }

        [HttpGet("GetUserDivisionWiseProductLine")]
        public async Task<ActionResult<IEnumerable<DivisionWiseProductLineModel>>> GetDivisionWiseProductLine(string? DivisionCode, string? UserCode)
        {
            var DivisionWiseProductLine = await _ascService.GetDivisionWiseProductLineAsync(DivisionCode, UserCode);
            if (DivisionWiseProductLine is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(DivisionWiseProductLine);
            }
        }

        [HttpGet("GetUserWiseAsc")]
        public async Task<ActionResult<IEnumerable<AscListModel>>> GetUserWiseAsc(string? UserCode)
        {
            var UserWiseAsc = await _ascService.GetUserWiseAscAsync(UserCode);
            if (UserWiseAsc is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(UserWiseAsc);
            }
        }

    }
}
