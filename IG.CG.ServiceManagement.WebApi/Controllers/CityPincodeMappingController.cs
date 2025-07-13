using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IG.CG.ServiceManagement.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CityPincodeMappingController : Controller
    {
        private readonly ILogger<CityPincodeMappingController> _logger;
        private readonly ICityPincodeMappingService _CityPincodeMappingService;
        public CityPincodeMappingController(ICityPincodeMappingService CityPincodeMappingService, ILogger<CityPincodeMappingController> logger)
        {
            _CityPincodeMappingService = CityPincodeMappingService;
            _logger = logger;
        }

        [HttpGet("GetAllCityPincodeMapping")]
        public async Task<ActionResult<IEnumerable<CityPincodeMappingModel>>> GetCityPincodeMapping(string? CityId, string DivisionCode, string Mode)
        {
            var CityPincodeMapping = await _CityPincodeMappingService.GetAllCityPincodeMapping(CityId, DivisionCode, Mode);
            if (CityPincodeMapping is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(CityPincodeMapping);
            }
        }


        [Authorize(Policy = "LoginRequired")]
        [HttpGet("GetAllPinCodeUserGetAsc")]
        public async Task<ActionResult<IEnumerable<CityPincodeMappingModel>>> GetPinCodeUserGetAsc(string? Pincode)
        {
            var CityPincodeMapping = await _CityPincodeMappingService.GetAllPincodeMappingAsc(Pincode);
            if (CityPincodeMapping is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(CityPincodeMapping);
            }
        }


        [HttpGet("GetAllPinCodeUserUnauthorizeGetAsc")]
        public async Task<ActionResult<IEnumerable<CityPincodeMappingModel>>> GetAllPinCodeUserUnauthorizeGetAsc(string? Pincode)
        {
            var CityPincodeMapping = await _CityPincodeMappingService.GetAllPincodeMappingAsc(Pincode);
            if (CityPincodeMapping is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(CityPincodeMapping);
            }
        }


        [Authorize(Policy = "LoginRequired")]
        [HttpGet("GetAllPinCodeUserGetUser")]
        public async Task<ActionResult<IEnumerable<CityPincodeMappingModel>>> GetPinCodeUserGetUser(string? Pincode, string? ProductLineCode)
        {
            var CityPincodeMapping = await _CityPincodeMappingService.GetAllPincodeMappingUser(Pincode, ProductLineCode);
            if (CityPincodeMapping is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(CityPincodeMapping);
            }
        }



        [HttpGet("GetAllPinCodeUserGetUserUnauthorize")]
        public async Task<ActionResult<IEnumerable<CityPincodeMappingModel>>> GetPinCodeUserGetUserUnauthorize(string? Pincode, string? ProductLineCode)
        {
            var CityPincodeMapping = await _CityPincodeMappingService.GetAllPincodeMappingUser(Pincode, ProductLineCode);
            if (CityPincodeMapping is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(CityPincodeMapping);
            }
        }






    }
}
