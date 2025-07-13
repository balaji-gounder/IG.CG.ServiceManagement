using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace IG.CG.ServiceManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    ///[Authorize(Policy = "LoginRequired")]
    public class ParaValController : ControllerBase
    {
        private readonly ILogger<ParaValController> _logger;
        private readonly IParaValService _paraValService;
        public ParaValController(IParaValService paraValService, ILogger<ParaValController> logger)
        {
            _paraValService = paraValService;
            _logger = logger;
        }


        [HttpGet("GetAllParaVal")]
        [Authorize(Policy = "LoginRequired")]
        public async Task<IActionResult> GetParaVal([FromQuery] ParaValFilter paraFilter)
        {
            var paraVal = await _paraValService.GetAllParaValAsync(paraFilter);
            if (paraVal is null)
            {
                return NoContent();
            }
            else
            {
                return Ok(paraVal);
            }
        }





        [HttpGet("GetParaValByType")]
        [Authorize(Policy = "LoginRequired")]
        public async Task<IActionResult> GetParaValByType(string parameterType)
        {
            var paraVal = await _paraValService.GetAllParaByTypeAsync(parameterType);
            if (paraVal is null)
            {
                return NoContent();
            }
            else
            {
                return Ok(paraVal);
            }
        }



        [HttpGet("GetParaValByTypeUnauthorize")]
        public async Task<IActionResult> GetParaValByTypeUnauthorize(string parameterType)
        {
            var paraVal = await _paraValService.GetAllParaByTypeAsync(parameterType);
            if (paraVal is null)
            {
                return NoContent();
            }
            else
            {
                return Ok(paraVal);
            }
        }





        [HttpGet("GetParaValById")]
        [Authorize(Policy = "LoginRequired")]
        public async Task<IActionResult> GetParaVal(int paraValId)
        {
            var paraVal = await _paraValService.GetParaValByIdAsync(paraValId);
            if (paraVal is null)
            {
                return NoContent();
            }
            else
            {
                return Ok(paraVal);
            }
        }
        [HttpPost("UpsertParaVal")]
        [Authorize(Policy = "LoginRequired")]
        public async Task<IActionResult> InsertParaVal([BindRequired] int ParameterTypeId, List<ParaValModel> paraValModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var paraValResult = await _paraValService.UpsertParaValAsync(ParameterTypeId, paraValModel, User?.Identity?.Name);
                return Ok(paraValResult);
            }
        }
        [HttpDelete("DeleteParaVal")]
        [Authorize(Policy = "LoginRequired")]
        public async Task<IActionResult> RemoveParaVal(int paraValId, int isActive)
        {
            var paraValResult = await _paraValService.DeleteParaValAsync(paraValId, User?.Identity?.Name, isActive);
            return Ok(paraValResult);
        }

        [HttpGet("GetAllParaType")]
        [Authorize(Policy = "LoginRequired")]
        public async Task<IActionResult> GetAllParaType(int mode)
        {
            var paraTypeResult = await _paraValService.GetAllParaTypeAsync(mode);
            return Ok(paraTypeResult);
        }

    }
}
